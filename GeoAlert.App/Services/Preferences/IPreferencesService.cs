namespace GeoAlert.App.Services.Preferences;

using GeoAlert.App.Models;
using System.Collections.Generic;

public interface IPreferencesService
{
	Task InsertPersonalPointAsync(PointModel pointModel);
	Task InsertAllPointAsync(IEnumerable<PointModel> pointModels);

	Task<List<PointModel>> GetAllPointsAsync();
}