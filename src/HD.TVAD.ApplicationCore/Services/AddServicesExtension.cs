using HD.TVAD.ApplicationCore.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HD.TVAD.ApplicationCore.Services
{
    public static class RegisterServicesExtension
	{
		public static IServiceCollection AddCoreServices(this IServiceCollection services)
		{
			services.AddScoped<IAssetCoreService, AssetCoreService>();

			return services;
		}
	}
}
