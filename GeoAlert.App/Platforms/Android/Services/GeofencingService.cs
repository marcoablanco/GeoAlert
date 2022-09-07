namespace GeoAlert.App.Platforms.Android.Services;

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

	public async Task AddGeofencingAsync(string idGeofence, Location location, float ratio)
	{
		GeofenceBuilder builder = new GeofenceBuilder();
		IGeofence geofence = builder.SetRequestId(idGeofence)
									.SetCircularRegion(location.Latitude, location.Longitude, ratio)
									.SetLoiteringDelay(5 * 1000)
									.SetTransitionTypes(Geofence.GeofenceTransitionEnter | Geofence.GeofenceTransitionExit | Geofence.GeofenceTransitionDwell)
									.SetExpirationDuration((long)365 * 24 * 60 * 60 * 1000)
									.Build();

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