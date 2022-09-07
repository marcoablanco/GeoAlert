namespace GeoAlert.App.Features.Dashboard;

using GeoAlert.App.Bases;
using GeoAlert.App.Services.AppLog;
using ReactiveUI;
using System.Reactive.Disposables;

public partial class DashboardPage
{
	public DashboardPage(DashboardViewModel viewModel, ILogService logService) : base(viewModel, logService)
	{
		InitializeComponent();
	}

	protected override CompositeDisposable OnActivated(CompositeDisposable disposables)
	{
		base.OnActivated(disposables);

		disposables.Add(this.OneWayBind(ViewModel, vm => vm.Points, v => v.ListResume.ItemsSource));
		disposables.Add(this.OneWayBind(ViewModel, vm => vm.IsLoading, v => v.ListResume.IsRefreshing));

		return disposables;
	}
}