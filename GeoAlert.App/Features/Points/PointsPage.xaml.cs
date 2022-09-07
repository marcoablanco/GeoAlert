namespace GeoAlert.App.Features.Points;

using GeoAlert.App.Features.Points;
using GeoAlert.App.Services.AppLog;

public partial class PointsPage
{
	public PointsPage(PointsViewModel viewModel, ILogService logService) : base(viewModel, logService)
	{
		InitializeComponent();
	}
}