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
		disposables.Add(this.BindValidation(ViewModel, vm => vm.Name, v => v.TxtName.ValidationMessage));

		return disposables;
	}
}