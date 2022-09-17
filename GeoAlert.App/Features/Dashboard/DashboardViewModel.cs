namespace GeoAlert.App.Features.Dashboard;

using GeoAlert.App.Bases;
using GeoAlert.App.Models;
using GeoAlert.App.Services.AppLog;
using GeoAlert.App.Services.Preferences;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

public class DashboardViewModel : BasePageViewModel
{
	private readonly IPreferencesService preferencesService;
	private ObservableCollection<PointModel> points;

	public DashboardViewModel(IPreferencesService preferencesService, ILogService logService) : base(logService)
	{
		points = new ObservableCollection<PointModel>();
		this.preferencesService = preferencesService;
	}

	public ObservableCollection<PointModel> Points
	{
		get => points;
		set => this.RaiseAndSetIfChanged(ref points, value);
	}

	public override async Task OnAppearingAsync()
	{
		await base.OnAppearingAsync();

		await LoadDataAsync();
	}

	private async Task LoadDataAsync()
	{
		List<PointModel> list = await preferencesService.GetAllPointsAsync();

		Dispatch(() => Points = new ObservableCollection<PointModel>(list), true);
		Dispatch(() => Loading = string.Empty);
	}
}
