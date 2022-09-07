namespace GeoAlert.App.Services.Preferences;

using GeoAlert.App.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

internal class MockPreferencesService : IPreferencesService
{
	private List<PointModel> points = new List<PointModel>();

	public Task<List<PointModel>> GetAllPointsAsync()
	{
		if (points.Count == 0)
		{
			points.Add(new PointModel { Name = "TEST01", Latitude = 10.101, Longitude = 10.101 });
			points.Add(new PointModel { Name = "TEST02", Latitude = 20.101, Longitude = 20.101 });
			points.Add(new PointModel { Name = "TEST03", Latitude = 30.101, Longitude = 30.101 });
			points.Add(new PointModel { Name = "TEST04", Latitude = 40.101, Longitude = 40.101 });
			points.Add(new PointModel { Name = "TEST05", Latitude = 50.101, Longitude = 50.101 });
		}
		return Task.FromResult(points);
	}

	public Task InsertAllPointAsync(IEnumerable<PointModel> placeModels)
	{
		points.AddRange(placeModels);
		return Task.CompletedTask;
	}

	public Task InsertPersonalPointAsync(PointModel placeModel)
	{
		points.Add(placeModel);
		return Task.CompletedTask;
	}
}
