namespace GeoAlert.App.UnitTests.ViewModels;

using GeoAlert.App.Features.Dashboard;
using GeoAlert.App.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
public class DashboardViewModelTests : BaseViewModelTests<DashboardViewModel>
{
	public override void InitViewModel()
	{
		ViewModel = new DashboardViewModel(MockPreferencesService.Object, MockLogService.Object);
	}


	[TestMethod("If appearing ok.")]
	public async Task GivenInitializedViewModel_WhenOnAppearing_ThenLoadDataAsync()
	{
		MockPreferencesService.Setup(p => p.GetAllPointsAsync()).ReturnsAsync(MockData.GetPointModels());

		await ViewModel.OnAppearingAsync();

		Assert.IsNotNull(ViewModel.Points, "List never should be null.");
		Assert.IsTrue(ViewModel.Points.Any(), "Points should be filled here.");
		Assert.IsFalse(ViewModel.IsLoading, "IsLoading should be false when Load finish.");
	}


	[TestMethod("If load is empty.")]
	public async Task GivenViewModelAppearing_WhenLoadDataEmptyReturns_ThenAppNotCrashAsync()
	{
		MockPreferencesService.Setup(p => p.GetAllPointsAsync()).ReturnsAsync(new List<PointModel>());

		await ViewModel.OnAppearingAsync();

		Assert.IsNotNull(ViewModel.Points, "List never should be null.");
		Assert.IsFalse(ViewModel.Points.Any(), "Points should be empty here.");
		Assert.IsFalse(ViewModel.IsLoading, "IsLoading should be false when Load finish.");
	}
}
