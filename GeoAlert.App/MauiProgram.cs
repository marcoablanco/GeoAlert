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

		builder.Services.AddServices()
						.AddViewModels()
						.AddViews();


		return builder.Build();
	}
}
