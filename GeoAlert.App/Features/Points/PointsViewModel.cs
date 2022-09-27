namespace GeoAlert.App.Features.Points;

using GeoAlert.App.Bases;
using GeoAlert.App.Features.Main;
using GeoAlert.App.Models;
using GeoAlert.App.Resources.Translations;
using GeoAlert.App.Services.AppLog;
using GeoAlert.App.Services.Loading;
using GeoAlert.App.Services.Preferences;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;

public class PointsViewModel : BasePageViewModel
{
	private readonly ILoadingService<PointsViewModel> loadingService;
	private readonly ILogService logService;
	private readonly IPreferencesService preferencesService;
	private ObservableCollection<PointModel> points;

	public PointsViewModel(ILoadingService<PointsViewModel> loadingService, ILogService logService, IPreferencesService preferencesService) : base(logService)
	{
		points = new ObservableCollection<PointModel>();
		this.loadingService = loadingService;
		this.logService = logService;
		this.preferencesService = preferencesService;

		AddPointCommand = ReactiveCommand.CreateFromTask(AddPointCommandExecuteAsync, loadingService.IsNotLoading);
	}



	public ObservableCollection<PointModel> Points
	{
		get => points;
		set => this.RaiseAndSetIfChanged(ref points, value);
	}

	public ReactiveCommand<Unit, Unit> AddPointCommand { get; }



	public override async Task OnAppearingAsync()
	{
		await base.OnAppearingAsync();

		await LoadDataAsync();
	}

	private async Task LoadDataAsync()
	{
		loadingService.Add(MainText.LoadingPoints);
		try
		{
			List<PointModel> list = await preferencesService.GetAllPointsAsync();

			Dispatch(() => Points = new ObservableCollection<PointModel>(list), true);
		}
		catch (Exception ex)
		{
			logService.LogError(ex);
		}
		loadingService.Remove(MainText.LoadingPoints);
	}

	private async Task AddPointCommandExecuteAsync()
	{
		if (Application.Current?.MainPage is MainShell mainShell)
		{
			await mainShell.NavigateToAddPointCommand.Execute();
		}
	}


}
