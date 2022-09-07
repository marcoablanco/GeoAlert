namespace GeoAlert.App.Bases;

using GeoAlert.App.Services.AppLog;
using ReactiveUI;
using System.Reactive.Linq;

public class BaseViewModel : ReactiveObject
{
	private readonly ILogService logService;
	private bool isLoading;

	public BaseViewModel(ILogService logService)
	{
		this.logService = logService;
		isLoading = true;
		IsNotLoadingObservable = this.WhenAnyValue(vm => vm.IsLoading).Select(x => !x);
	}

	public IDispatcher? Dispatcher { get; set; }

	public IObservable<bool> IsNotLoadingObservable { get; }

	public bool IsLoading
	{
		get => isLoading;
		set => this.RaiseAndSetIfChanged(ref isLoading, value);
	}

	protected virtual void Dispatch(Action action, bool secure = false)
	{
		if (secure)
		{
			try
			{
				if (Dispatcher is null)
					action?.Invoke();
				else
				{
					Dispatcher.Dispatch(() =>
					{
						try
						{
							action.Invoke();
						}
						catch (Exception ex)
						{
							logService.LogError(ex);
						}
					});
				}
			}
			catch (Exception ex)
			{
				logService.LogError(ex);
			}
		}
		else
		{
			if (Dispatcher is null)
				action?.Invoke();
			else
				Dispatcher.Dispatch(action);
		}
	}
}
