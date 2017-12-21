using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using HD.Station.Business;
using HD.Station.Infrastructure;
using HD.Station.Infrastructure.ApplicationParts;
//using HD.Station.Services;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MvcBuilderExtensions
    {
        /// <summary>
        /// Registers discovered services in the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IMvcBuilder"/>.</param>
        /// <returns>The <see cref="IMvcBuilder"/>.</returns>
        internal static IMvcBuilder AddDiscoveredServices(this IMvcBuilder builder)
        {
            var feature = new DiscoveryServiceFeature();
            builder.PartManager.PopulateFeature(feature);

            foreach (var service in feature.Services)
            {
                // Don't add if service type and implement type already added
                if (builder.Services.Any(s => s.ServiceType == service.ServiceType && s.ImplementationType == service.ImplementationType))
                    continue;

                builder.Services.Add(service);
            }

            return builder;
        }

        internal static IMvcBuilder AddEmbeddedRazorView(this IMvcBuilder builder)
        {
            var feature = new DiscoveryAssemblyFeature();
            builder.PartManager.PopulateFeature(feature);

            foreach (var assembly in feature.Assemblies)
            {
                builder.AddRazorOptions(options =>
                {
                    options.FileProviders.Add(new EmbeddedFileProvider(assembly));
                });
            }

            return builder;
        }
    }
}