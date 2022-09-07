namespace GeoAlert.App.UnitTests.ViewModels;

using GeoAlert.App.Features.Points;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PointsViewModelTest : BaseViewModelTests<PointsViewModel>
{
	public override void InitViewModel()
	{
		ViewModel = new PointsViewModel(MockPreferencesService.Object, MockLogService.Object);
	}
}
