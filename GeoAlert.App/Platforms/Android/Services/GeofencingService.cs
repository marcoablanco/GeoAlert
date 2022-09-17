namespace GeoAlert.App.Platforms.Android.Services;

using GeoAlert.App.Models;
using GeoAlert.App.Platforms.Android.Broadcasts;
using GeoAlert.App.Services.Geofencing;
using global::Android.App;
using global::Android.Content;
using global::Android.Gms.Extensions;
using global::Android.Gms.Location;
using Microsoft.Maui.Devices.Sensors;
using System.Threading.Tasks;

internal class GeofencingService : IGeofencingService
{
	private readonly GeofencingClient geofencingClient;
	private PendingIntent? geofencePendingIntent;

	public GeofencingService()
	{
		geofencingClient = LocationServices.GetGeofencingClient(MainActivity.MainContext);
	}

	public async Task AddGeofencingAsync(PointModel pointModel)
	{
		GeofenceBuilder builder = new GeofenceBuilder();
		builder = builder.SetRequestId(pointModel.Name)
						 .SetCircularRegion(pointModel.Latitude, pointModel.Longitude, pointModel.Ratio)
						 .SetLoiteringDelay(5 * 1000)
						 
						 .SetExpirationDuration((long)365 * 24 * 60 * 60 * 1000);
		if (pointModel.WatchEnter && pointModel.WatchExit && pointModel.WatchDwell)
			builder.SetTransitionTypes(Geofence.GeofenceTransitionEnter | Geofence.GeofenceTransitionExit | Geofence.GeofenceTransitionDwell);
		else if (pointModel.WatchEnter && pointModel.WatchExit)
			builder.SetTransitionTypes(Geofence.GeofenceTransitionEnter | Geofence.GeofenceTransitionExit);
		else if (pointModel.WatchEnter && pointModel.WatchDwell)
			builder.SetTransitionTypes(Geofence.GeofenceTransitionEnter | Geofence.GeofenceTransitionDwell);
		else if (pointModel.WatchExit && pointModel.WatchDwell)
			builder.SetTransitionTypes(Geofence.GeofenceTransitionExit | Geofence.GeofenceTransitionDwell);
		else if (pointModel.WatchEnter)
			builder.SetTransitionTypes(Geofence.GeofenceTransitionEnter);
		else if (pointModel.WatchExit)
			builder.SetTransitionTypes(Geofence.GeofenceTransitionExit);
		else if (pointModel.WatchDwell)
			builder.SetTransitionTypes(Geofence.GeofenceTransitionDwell);

		IGeofence geofence = builder.Build();

		GeofencingRequest.Builder requestBuilder = new GeofencingRequest.Builder();
		GeofencingRequest request = requestBuilder.AddGeofences(new List<IGeofence> { geofence })
												  .Build();

		await geofencingClient.AddGeofences(request, GetGeofencePendingIntent());
	}

	private PendingIntent GetGeofencePendingIntent()
	{
		if (geofencePendingIntent != null)
			return geofencePendingIntent;

		Intent intent = new Intent(MainActivity.MainContext, Java.Lang.Class.FromType(typeof(GeofenceBroadcastReceiver)));
		// We use FLAG_UPDATE_CURRENT so that we get the same pending intent back when calling addGeofences() and removeGeofences().
		geofencePendingIntent = PendingIntent.GetBroadcast(MainActivity.MainContext, 0, intent, PendingIntentFlags.UpdateCurrent);
		return geofencePendingIntent;
	}
}