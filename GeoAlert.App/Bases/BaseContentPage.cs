namespace GeoAlert.App.Bases;

using GeoAlert.App.Services.AppLog;
using ReactiveUI;
using ReactiveUI.Maui;
using System.Reactive.Disposables;
using System.Reactive.Linq;

public class BaseContentPage<TViewModel> : ReactiveContentPage<TViewModel> where TViewModel : BasePageViewModel
{
	private static readonly BindableProperty ActivatedProperty = BindableProperty.Create(nameof(Activated), typeof(bool), typeof(BaseContentPage<TViewModel>));
	private static readonly BindableProperty AppearedProperty = BindableProperty.Create(nameof(Appeared), typeof(bool), typeof(BaseContentPage<TViewModel>));
	private readonly ILogService logService;

	public BaseContentPage(TViewModel viewModel, ILogService logService)
	{
		ViewModel = viewModel;
		ViewModel.Dispatcher = Dispatcher;

		this.WhenActivated(d => OnActivated(d));
		this.logService = logService;
	}



	public bool Activated
	{
		get => (bool)GetValue(ActivatedProperty);
		set => SetValue(ActivatedProperty, value);
	}

	public bool Appeared
	{
		get => (bool)GetValue(AppearedProperty);
		set => SetValue(AppearedProperty, value);
	}


	protected override void OnAppearing()
	{
		base.OnAppearing();
		ViewModel?.OnAppearingAsync();
		Appeared = true;
	}

	protected override void OnDisappearing()
	{
		Appeared = false;
		ViewModel?.OnDisappearingAsync();
		base.OnDisappearing();
	}

	protected virtual CompositeDisposable OnActivated(CompositeDisposable disposables)
	{
		if (Activated || ViewModel is null)
			return disposables;
		Activated = true;

		ViewModel.OnActivated(disposables);

		disposables.Add(ViewModel.WhenAnyValue(vm => vm.Loading)
								 .Skip(1)
								 .Do(loading => Dispatcher.Dispatch(() => IsBusy = !string.IsNullOrEmpty(loading)), logService.LogError)
								 .Catch<string, Exception>(ex =>
								 {
									 logService.LogError(ex);
									 return Observable.Return(ViewModel.Loading);
								 })
								 .Subscribe());
		return disposables;
	}
}
