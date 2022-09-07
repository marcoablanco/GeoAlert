namespace GeoAlert.App.Features.Points;

using GeoAlert.App.Bases;
using GeoAlert.App.Features.Main;
using GeoAlert.App.Models;
using GeoAlert.App.Services.AppLog;
using GeoAlert.App.Services.Preferences;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

public class PointsViewModel : BasePageViewModel
{
	private readonly IPreferencesService preferencesService;
	private ObservableCollection<PointModel> points;

	public PointsViewModel(IPreferencesService preferencesService, ILogService logService) : base(logService)
	{
		points = new ObservableCollection<PointModel>();
		this.preferencesService = preferencesService;

		AddPointCommand = ReactiveCommand.CreateFromTask(AddPointCommandExecuteAsync, IsNotLoadingObservable);
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
		List<PointModel> list = await preferencesService.GetAllPointsAsync();

		Dispatch(() => Points = new ObservableCollection<PointModel>(list), true);
		Dispatch(() => IsLoading = false);
	}

	private async Task AddPointCommandExecuteAsync()
	{
		if (Application.Current?.MainPage is MainShell mainShell)
		{
			await mainShell.NavigateToAddPoint();
		}
	}


}
