using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
namespace HD.Station.Infrastructure.ApplicationParts
{
    public class DiscoveryServiceFeature
    {
        public IServiceCollection Services { get; } = new ServiceCollection();
    }
    public class DiscoveryAssemblyFeature
    {
        public IList<Assembly> Assemblies { get; set; } = new List<Assembly>();
    }
}