namespace GeoAlert.App.Bases;

using GeoAlert.App.Services.AppLog;
using GeoAlert.App.Services.Loading;
using ReactiveUI;
using ReactiveUI.Maui;
using System;
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

		return disposables;
	}

	protected IDisposable SetBindingIsBusy(ILoadingService loadingService)
	{
		return loadingService.IsLoading
							 .Do(isLoading => Dispatcher.Dispatch(() => IsBusy = isLoading), logService.LogError)
							 .Catch<bool, Exception>(ex =>
							 {
								 logService.LogError(ex);
								 return loadingService.IsLoading;
							 })
							 .Subscribe();
	}
}
