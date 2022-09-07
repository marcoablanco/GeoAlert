namespace GeoAlert.App.Features.AddPoint;

using GeoAlert.App.Services.AppLog;

public partial class AddPointPage
{
	public AddPointPage(AddPointViewModel viewModel, ILogService logService) : base(viewModel, logService)
	{
		InitializeComponent();
	}
}