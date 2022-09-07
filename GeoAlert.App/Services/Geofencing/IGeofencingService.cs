namespace GeoAlert.App.Services.Geofencing;

using System.Threading.Tasks;

public interface IGeofencingService
{
	Task AddGeofencingAsync(string idGeofence, Location location, float ratio);
}
