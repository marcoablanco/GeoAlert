namespace GeoAlert.App.Features.Main;

using GeoAlert.App.Features.AddPoint;
using GeoAlert.App.Services.AppLog;
using ReactiveUI;

public partial class MainShell : Shell
{
	private readonly IServiceProvider serviceProvider;
	private readonly ILogService logService;

	public MainShell(IServiceProvider serviceProvider)
	{
		IServiceScope serviceScope = serviceProvider.CreateScope();
		this.serviceProvider = serviceScope.ServiceProvider;
		logService = serviceScope.ServiceProvider.GetRequiredService<ILogService>();

		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		BtnAdd.Command = ReactiveCommand.CreateFromTask(NavigateToAddPointAsync);
	}

	public async Task NavigateToAddPointAsync()
	{
		AddPointPage? addPointPage = serviceProvider.GetService<AddPointPage>();
		if (addPointPage is not null)
			await Navigation.PushModalAsync(addPointPage, true);
		else
			logService.LogLine("AddPointPage not founded in ServiceProvider");

	}
}
