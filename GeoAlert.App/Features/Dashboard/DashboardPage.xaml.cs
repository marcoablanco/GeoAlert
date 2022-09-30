namespace GeoAlert.App.Features.Dashboard;

using GeoAlert.App.Bases;
using GeoAlert.App.Services.AppLog;
using GeoAlert.App.Services.Loading;
using ReactiveUI;
using System.Reactive.Disposables;

public partial class DashboardPage
{
	private readonly ILoadingService<DashboardViewModel> loadingService;

	public DashboardPage(DashboardViewModel viewModel, ILoadingService<DashboardViewModel> loadingService, ILogService logService) : base(viewModel, logService)
	{
		InitializeComponent();
		this.loadingService = loadingService;
	}

	protected override CompositeDisposable OnActivated(CompositeDisposable disposables)
	{
		base.OnActivated(disposables);

		disposables.Add(this.OneWayBind(ViewModel, vm => vm.Points, v => v.ListResume.ItemsSource));
		disposables.Add(this.BindCommand(ViewModel, vm => vm.AddPointCommand, v => v.BtnAdd));
		disposables.Add(this.BindCommand(ViewModel, vm => vm.AddPointCommand, v => v.ToolbarAdd));

		disposables.Add(loadingService.IsLoading.Subscribe(isLoading => ListResume.IsRefreshing = isLoading));

		return disposables;
	}
}