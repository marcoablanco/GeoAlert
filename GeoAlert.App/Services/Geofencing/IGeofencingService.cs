namespace GeoAlert.App.Services.Geofencing;

using GeoAlert.App.Models;
using System.Threading.Tasks;

public interface IGeofencingService
{
	Task AddGeofencingAsync(PointModel pointModel);
}
