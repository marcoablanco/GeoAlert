namespace GeoAlert.App.Features.Settings;
using GeoAlert.App.Services.AppLog;

public partial class SettingsPage
{
	public SettingsPage(SettingsViewModel viewModel, ILogService logService) : base(viewModel, logService)
	{
		InitializeComponent();
	}
}