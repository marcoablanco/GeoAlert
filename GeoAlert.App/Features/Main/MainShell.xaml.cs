namespace GeoAlert.App.Features.Main;

using GeoAlert.App.Features.AddPoint;
using GeoAlert.App.Services.AppLog;
using ReactiveUI;
using System.Reactive;
using System.Reactive.Disposables;

public partial class MainShell : Shell
{
	private readonly IServiceProvider serviceProvider;
	private readonly ILogService logService;
	private CompositeDisposable? disposables;

	public MainShell(IServiceProvider serviceProvider)
	{
		IServiceScope serviceScope = serviceProvider.CreateScope();
		this.serviceProvider = serviceScope.ServiceProvider;
		logService = serviceScope.ServiceProvider.GetRequiredService<ILogService>();

		InitializeComponent();

		disposables = new CompositeDisposable();
		NavigateToAddPointCommand = ReactiveCommand.CreateFromTask(NavigateToAddPointAsync);
	}

	public ReactiveCommand<Unit, Unit> NavigateToAddPointCommand { get; }

	protected override void OnAppearing()
	{
		base.OnAppearing();
		disposables ??= new CompositeDisposable();
		BtnAdd.Command = NavigateToAddPointCommand;

		disposables.Add(NavigateToAddPointCommand.ThrownExceptions.Subscribe(logService.LogError, logService.LogError));
	}

	protected override void OnDisappearing()
	{
		base.OnDisappearing();
		disposables?.Dispose();
		disposables = null;
	}

	private async Task NavigateToAddPointAsync()
	{
		AddPointPage? addPointPage = serviceProvider.GetService<AddPointPage>();
		if (addPointPage is not null)
			await Navigation.PushAsync(addPointPage, true);
		else
			logService.LogLine("AddPointPage not founded in ServiceProvider");

	}
}
