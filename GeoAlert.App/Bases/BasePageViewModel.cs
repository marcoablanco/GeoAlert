namespace GeoAlert.App.Bases;

using GeoAlert.App.Services.AppLog;
using System.Reactive.Disposables;

public class BasePageViewModel : BaseViewModel
{
	private readonly ILogService logService;

	public BasePageViewModel(ILogService logService):base(logService)
	{
		this.logService = logService;
	}


	public virtual CompositeDisposable OnActivated(CompositeDisposable disposables)
	{
		return disposables;
	}

	public virtual Task OnAppearingAsync()
	{
		return Task.CompletedTask;
	}

	public virtual Task OnDisappearingAsync()
	{
		return Task.CompletedTask;
	}
}