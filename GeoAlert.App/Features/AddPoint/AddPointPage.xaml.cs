namespace GeoAlert.App.Features.AddPoint;

using GeoAlert.App.Services.AppLog;
using ReactiveUI;
using ReactiveUI.Validation.Extensions;
using System.Reactive.Disposables;

public partial class AddPointPage
{
	public AddPointPage(AddPointViewModel viewModel, ILogService logService) : base(viewModel, logService)
	{
		InitializeComponent();
	}

	protected override CompositeDisposable OnActivated(CompositeDisposable disposables)
	{
		base.OnActivated(disposables);

		disposables.Add(this.Bind(ViewModel, vm => vm.Name, v => v.TxtName.Text));
		disposables.Add(this.Bind(ViewModel, vm => vm.ShortDescription, v => v.TxtShortDescription.Text));
		disposables.Add(this.Bind(ViewModel, vm => vm.Description, v => v.TxtDescription.Text));
		disposables.Add(this.Bind(ViewModel, vm => vm.Radious, v => v.TxtRadious.Text));

		disposables.Add(this.Bind(ViewModel, vm => vm.WatchEnter, v => v.CheckEnter.IsChecked));
		disposables.Add(this.Bind(ViewModel, vm => vm.WatchExit, v => v.CheckExit.IsChecked));
		disposables.Add(this.Bind(ViewModel, vm => vm.WatchDwell, v => v.CheckDwell.IsChecked));

		disposables.Add(this.BindValidation(ViewModel, vm => vm.Name, v => v.TxtName.ValidationMessage));
		disposables.Add(this.BindValidation(ViewModel, vm => vm.Radious, v => v.TxtRadious.ValidationMessage));

		return disposables;
	}
}