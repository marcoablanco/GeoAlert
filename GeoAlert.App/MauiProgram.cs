namespace GeoAlert.App;

using GeoAlert.App.Configuration;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder()
							 .UseMauiApp<App>()
							 .AddFonts()
							 .AddHandlers();

		builder.Services.AddPlatformServices()
						.AddServices()
						.AddViewModels()
						.AddViews();


		MauiApp app = builder.Build();
		app.Services.Set();
		return app;
	}
}
