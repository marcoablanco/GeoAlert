namespace GeoAlert.App.Configuration;

using GeoAlert.App.Controls;
using GeoAlert.App.Platforms.Android.Handlers;
using Microsoft.Maui.LifecycleEvents;
using System.Diagnostics;

internal static class MauiConfiguration
{
	internal static MauiAppBuilder AddFonts(this MauiAppBuilder builder)
	{
		return builder.ConfigureFonts(fonts =>
		{
			fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
		});
	}

	internal static MauiAppBuilder AddHandlers(this MauiAppBuilder builder)
	{
		return builder
#if ANDROID
			.ConfigureMauiHandlers(handler => handler.AddHandler<ValidatableEntryControl, ValidatableEntryControlHandler>());
#else
;
#endif
	}

	internal static MauiAppBuilder AddLifeCycle(this MauiAppBuilder builder)
	{
		return builder.ConfigureLifecycleEvents(events =>
		{
#if ANDROID
			events.AddAndroid(android => android.OnActivityResult((activity, requestCode, resultCode, data) => LogEvent("OnActivityResult", requestCode.ToString()))
												.OnStart((activity) => LogEvent("OnStart"))
												.OnCreate((activity, bundle) => LogEvent("OnCreate"))
												.OnStop((activity) => LogEvent("OnStop")));

#endif
		});
	}

	private static void LogEvent(string eventName, string? type = null)
	{
		Debug.WriteLine($"Lifecycle event: {eventName}{(type == null ? string.Empty : $" ({type})")}");
	}
}
