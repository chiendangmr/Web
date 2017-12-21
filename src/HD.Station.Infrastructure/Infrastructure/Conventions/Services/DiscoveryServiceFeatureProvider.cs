using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HD.Station.Infrastructure.ApplicationParts
{
    public class DiscoveryServiceFeatureProvider : IApplicationFeatureProvider<DiscoveryServiceFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, DiscoveryServiceFeature feature)
        {
            foreach (var type in parts.Where(part => part.Name.StartsWith("HD.")).OfType<IApplicationPartTypeProvider>().SelectMany(p => p.Types))
            {
                foreach (var serviceAttr in type.GetCustomAttributes<ServiceAttribute>())
                {
                    var implementType = type.AsType();
                    var serviceType = serviceAttr.ServiceType ?? implementType;

                    // Only accept correct declaration
                    if (serviceType.IsAssignableFrom(implementType))
                    {
                        feature.Services.Add(new ServiceDescriptor(serviceType, implementType, serviceAttr.Lifetime));
                    }
                }
            }
        }
    }
}