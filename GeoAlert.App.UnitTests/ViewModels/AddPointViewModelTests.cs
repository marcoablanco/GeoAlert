namespace GeoAlert.App.UnitTests.ViewModels;

using GeoAlert.App.Features.AddPoint;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class AddPointViewModelTests : BaseViewModelTests<AddPointViewModel>
{
	public override void InitViewModel()
	{
		ViewModel = new AddPointViewModel(MockLogService.Object);
	}
}
