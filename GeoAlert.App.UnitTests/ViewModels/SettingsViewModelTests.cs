namespace GeoAlert.App.UnitTests.ViewModels;

using GeoAlert.App.Features.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
internal class SettingsViewModelTests : BaseViewModelTests<SettingsViewModel>
{
	public override void InitViewModel()
	{
		ViewModel = new SettingsViewModel(MockLogService.Object);
	}
}
