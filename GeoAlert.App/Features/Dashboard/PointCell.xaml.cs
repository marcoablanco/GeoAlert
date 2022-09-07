namespace GeoAlert.App.Features.Dashboard;

using GeoAlert.App.Models;

public partial class PointCell
{
	public PointCell()
	{
		InitializeComponent();
	}

	protected override void OnBindingContextChanged()
	{
		base.OnBindingContextChanged();
		if (BindingContext is PointModel model)
		{
			LblTitle.Text = model.Name;
			LblCoordinates.Text = model.GetLocationString();
		}
	}
}