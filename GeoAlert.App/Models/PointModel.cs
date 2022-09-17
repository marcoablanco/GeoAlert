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

	public const string PersonalCategory = "Personal";

	/// <summary>
	/// Unique. Used as identifier.
	/// </summary>
	public string Name { get; set; }
	public string ShortDescription { get; set; }
	public string Description { get; set; }
	public string Category { get; set; }

	public double Latitude { get; set; }
	public double Longitude { get; set; }
	public float Ratio { get; set; }
	public bool WatchDwell { get; internal set; }
	public bool WatchExit { get; internal set; }
	public bool WatchEnter { get; internal set; }

	public string GetLocationString()
	{
		return $"{Latitude}, {Longitude}";
	}
}