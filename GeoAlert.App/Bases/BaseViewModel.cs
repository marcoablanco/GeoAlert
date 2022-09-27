namespace GeoAlert.App.Bases;

using GeoAlert.App.Services.AppLog;
using ReactiveUI;
using System.Reactive.Linq;

public class BaseViewModel : ReactiveObject
{
	private readonly ILogService logService;
	private string loading;

	public BaseViewModel(ILogService logService)
	{
		this.logService = logService;
		loading = string.Empty;
		NameViewModel = GetType().Name;

		logService.LogLine($"{NameViewModel} created.");
	}

	public IDispatcher? Dispatcher { get; set; }

	protected string NameViewModel { get; }



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
