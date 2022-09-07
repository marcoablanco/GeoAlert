namespace GeoAlert.App.UnitTests;

using GeoAlert.App.Models;

internal static class MockData
{
	public static List<PointModel> GetPointModels()
	{
		return new List<PointModel>
		{
			new PointModel { Name = "TEST01", Latitude = 10.101, Longitude = 10.101 },
			new PointModel { Name = "TEST02", Latitude = 20.101, Longitude = 20.101 },
			new PointModel { Name = "TEST03", Latitude = 30.101, Longitude = 30.101 },
			new PointModel { Name = "TEST04", Latitude = 40.101, Longitude = 40.101 },
			new PointModel { Name = "TEST05", Latitude = 50.101, Longitude = 50.101 }
		};
	}

}
