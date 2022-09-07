namespace GeoAlert.App.UnitTests;

using GeoAlert.App.Bases;
using GeoAlert.App.Services.AppLog;
using GeoAlert.App.Services.Preferences;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Diagnostics.CodeAnalysis;

[TestCategory("ViewModel Unit Test")]
public abstract class BaseViewModelTests<TViewModel> where TViewModel : BaseViewModel
{

	public BaseViewModelTests()
	{
		MockLogService = new Mock<ILogService>();
		MockPreferencesService = new Mock<IPreferencesService>();
		MockApplication = new Mock<Application>();

		InitViewModel();
		Application.Current = MockApplication.Object;
		Assert.IsNotNull(ViewModel);
	}

	protected virtual TViewModel ViewModel { get; set; }

	protected Mock<Application> MockApplication { get; }
	protected Mock<ILogService> MockLogService { get; }
	protected Mock<IPreferencesService> MockPreferencesService { get; }

	public abstract void InitViewModel();

	[TestCleanup]
	public virtual void Reset()
	{
		MockLogService.Reset();
		InitViewModel();
	}

	[TestMethod("_Init ViewModel.")]
	public virtual void GivenViewModel_ThenOk()
	{
		Assert.IsNotNull(ViewModel);
	}
}