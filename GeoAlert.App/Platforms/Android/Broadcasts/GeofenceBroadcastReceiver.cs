namespace GeoAlert.App.Platforms.Android.Broadcasts;

using global::Android.Content;
using global::Android.Gms.Location;
using GeoAlert.App.Resources.Translations;
using GeoAlert.App.Platforms.Android.Services;

[BroadcastReceiver()]
internal class GeofenceBroadcastReceiver : BroadcastReceiver
{
	public override void OnReceive(Context? context, Intent? intent)
	{
		GeofencingEvent geofencingEvent = GeofencingEvent.FromIntent(intent);
		if (geofencingEvent.HasError)
		{
			string error = GeofenceStatusCodes.GetStatusCodeString(geofencingEvent.ErrorCode);
			Console.WriteLine($"Error Code: {geofencingEvent.ErrorCode}. Error: {error}");
			return;
		}

		// Get the transition type.
		int geofenceTransition = geofencingEvent.GeofenceTransition;
		// Get the geofences that were triggered. A single event can trigger
		// multiple geofences.
		IList<IGeofence> triggeringGeofences = geofencingEvent.TriggeringGeofences;
		NotificationsService notificationsService = new NotificationsService(context);

		switch (geofenceTransition)
		{
			case Geofence.GeofenceTransitionEnter:
				notificationsService.SendNotification(MainText.BroadcastInTitle, MainText.BroadcastInMessage, 10000);
				break;
			case Geofence.GeofenceTransitionExit:
				notificationsService.SendNotification(MainText.BroadcastOutTitle, MainText.BroadcastOutMessage, 10000);
				break;
			case Geofence.GeofenceTransitionDwell:
				notificationsService.SendNotification(MainText.BroadcastDwellTitle, MainText.BroadcastDwellMessage, 10000);
				break;
			default:
				// Log the error.
				Console.WriteLine("Broadcast not implemented.");
				break;
		}
	}
}