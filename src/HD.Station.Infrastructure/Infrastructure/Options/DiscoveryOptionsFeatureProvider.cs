using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HD.Station.Infrastructure.Options
{
    public class DiscoveryOptionsFeatureProvider : IApplicationFeatureProvider<DiscoveryOptionsFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, DiscoveryOptionsFeature feature)
        {
            foreach (var type in parts.Where(part => part.Name.StartsWith("HD.")).OfType<IApplicationPartTypeProvider>().SelectMany(p => p.Types))
            {
                var attr = type.GetCustomAttribute<ApplicationOptionsAttribute>();
                if (attr != null)
                {
                    feature.Options.Add(new OptionsDescriptor(attr.Path, type));
                }
            }
        }
    }
}