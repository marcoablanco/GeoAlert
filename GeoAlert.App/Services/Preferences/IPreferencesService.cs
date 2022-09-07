namespace GeoAlert.App.Services.Preferences;

using GeoAlert.App.Models;
using System.Collections.Generic;

public interface IPreferencesService
{
	Task InsertPersonalPointAsync(PointModel point);
	Task InsertAllPointAsync(IEnumerable<PointModel> points);

	Task<List<PointModel>> GetAllPointsAsync();
}