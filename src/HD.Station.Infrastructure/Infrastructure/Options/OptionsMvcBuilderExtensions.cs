using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using HD.Station.Infrastructure.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class OptionsMvcBuilderExtensions
    {
        /// <summary>
        /// Registers discovered services in the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IMvcBuilder"/>.</param>
        /// <returns>The <see cref="IMvcBuilder"/>.</returns>
        public static IMvcBuilder AddDiscoveredOptions(this IMvcBuilder builder)
        {
            var feature = new DiscoveryOptionsFeature();
            builder.PartManager.PopulateFeature(feature);

            foreach (var option in feature.Options)
            {
                var descriptor = builder.Services.FirstOrDefault(desc =>
                    desc.Lifetime == ServiceLifetime.Singleton &&
                    desc.ServiceType == typeof(IConfigurationRoot) &&
                    desc.ImplementationInstance != null
                );

                var configuration = descriptor.ImplementationInstance as IConfigurationRoot;
                var section = configuration.GetSection(option.Path);

                var method = typeof(OptionsConfigurationServiceCollectionExtensions)
                    .GetTypeInfo()
                    .GetMethod("Configure", new Type[] { typeof(IServiceCollection), typeof(IConfiguration) });

                method = method.MakeGenericMethod(option.OptionsType.AsType());
                method.Invoke(null, new object[] { builder.Services, section });
            }

            return builder;
        }
    }
}