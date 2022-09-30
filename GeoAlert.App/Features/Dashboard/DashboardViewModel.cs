namespace GeoAlert.App.Features.Dashboard;

using GeoAlert.App.Bases;
using GeoAlert.App.Configuration;
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
using System.Threading.Tasks;

public class DashboardViewModel : BasePageViewModel
{
	private readonly ILoadingService<DashboardViewModel> loadingService;
	private readonly IPreferencesService preferencesService;
	private ObservableCollection<PointModel> points;

	public DashboardViewModel(ILoadingService<DashboardViewModel> loadingService, IPreferencesService preferencesService, ILogService logService) : base(logService)
	{
		points = new ObservableCollection<PointModel>();
		this.loadingService = loadingService;
		this.preferencesService = preferencesService;
		AddPointCommand = ReactiveCommand.CreateFromTask(AddPointCommandExecuteAsync);
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
		List<PointModel> list = await preferencesService.GetAllPointsAsync();

		Dispatch(() => Points = new ObservableCollection<PointModel>(list), true);
		loadingService.Remove(MainText.LoadingPoints);
	}

	private async Task AddPointCommandExecuteAsync()
	{
		MainShell? mainShell = DependencyResolve.Get<MainShell>();
		if (mainShell is not null)
			await mainShell.NavigateToAddPointCommand.Execute();
	}
}
