namespace GeoAlert.App.Services.Preferences;

using GeoAlert.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

internal class PreferencesService : IPreferencesService
{
	private readonly IPreferences preferences;

	public PreferencesService(IPreferences preferences)
	{
		this.preferences = preferences;
	}

	public async Task<List<PointModel>> GetAllPointsAsync()
	{
		List<PointModel> places = preferences.Get(Keys.PointsPersonal, new List<PointModel>(), Keys.PointsCategory);
		return await Task.FromResult(places ?? new List<PointModel>());
	}

	public async Task InsertPersonalPointAsync(PointModel placeModel)
	{
		List<PointModel> places = await GetAllPointsAsync();
		places.Add(placeModel);
		preferences.Set(Keys.PointsPersonal, places, Keys.PointsCategory);
	}

	public async Task InsertAllPointAsync(IEnumerable<PointModel> placeModels)
	{
		List<PointModel> places = await GetAllPointsAsync();
		places.AddRange(placeModels);
		preferences.Set(Keys.PointsPersonal, places, Keys.PointsCategory);
	}
}
