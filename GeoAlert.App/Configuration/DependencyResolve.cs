namespace GeoAlert.App.Configuration;
using System;

internal static class DependencyResolve
{
	private static IServiceProvider? serviceProvider;

	public static IServiceProvider Set(this IServiceProvider serviceProvider)
	{
		DependencyResolve.serviceProvider = serviceProvider;
		return DependencyResolve.serviceProvider;
	}

	public static TService? Get<TService>()
	{
		if (serviceProvider is null)
			return default;
		return serviceProvider.GetService<TService>();
	}

}
