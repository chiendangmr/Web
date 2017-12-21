using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.Station.Infrastructure.ApplicationParts
{
    public class DiscoveryServiceFeature
    {
        public IServiceCollection Services { get; } = new ServiceCollection();
    }
}