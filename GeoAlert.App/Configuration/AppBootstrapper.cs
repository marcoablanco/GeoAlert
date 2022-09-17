namespace GeoAlert.App.Configuration;

using GeoAlert.App.Features.AddPoint;
using GeoAlert.App.Features.Dashboard;
using GeoAlert.App.Features.Main;
using GeoAlert.App.Features.Points;
using GeoAlert.App.Features.Settings;
using GeoAlert.App.Services.AppLog;
using GeoAlert.App.Services.Geofencing;
using GeoAlert.App.Services.Preferences;
using GeoAlert.App.Services.Alert;
using Microsoft.Extensions.DependencyInjection;


#if ANDROID
using GeoAlert.App.Platforms.Android.Services;
#endif

internal static class AppBootstrapper
{
	internal static IServiceCollection AddServices(this IServiceCollection services)
	{
		bool useMockPreferencesService = true;

#if DEBUG
		if (useMockPreferencesService)
			services.AddSingleton<IPreferencesService, MockPreferencesService>();
		else
#endif
			services.AddSingleton<IPreferencesService, PreferencesService>();


		services.AddSingleton<ILogService, LogService>();
		services.AddSingleton<IAlertService, AlertService>();

		// Maui services
		services.AddSingleton(Preferences.Default);

		return services;
	}

	internal static IServiceCollection AddPlatformServices(this IServiceCollection services)
	{
#if ANDROID
		return services.AddSingleton<IGeofencingService, GeofencingService>();
#else
		return services;
#endif
	}

	internal static IServiceCollection AddViews(this IServiceCollection services)
	{
		return services.AddScoped<MainShell>()
					   .AddScoped<DashboardPage>()
					   .AddScoped<PointsPage>()
					   .AddScoped<SettingsPage>()
					   .AddScoped<AddPointPage>();
	}

	internal static IServiceCollection AddViewModels(this IServiceCollection services)
	{
		return services.AddScoped<DashboardViewModel>()
					   .AddScoped<PointsViewModel>()
					   .AddScoped<SettingsViewModel>()
					   .AddScoped<AddPointViewModel>();
	}
}
