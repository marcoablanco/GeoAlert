namespace GeoAlert.App.Models;

public class PointModel
{
	public PointModel()
	{
		Name = string.Empty;
		ShortDescription = string.Empty;
		Description = string.Empty;
		Category = string.Empty;
	}

	public string Name { get; set; }
	public string ShortDescription { get; set; }
	public string Description { get; set; }
	public string Category { get; set; }

	public double Latitude { get; set; }
	public double Longitude { get; set; }

	public string GetLocationString()
	{
		return $"{Latitude}, {Longitude}";
	}
}