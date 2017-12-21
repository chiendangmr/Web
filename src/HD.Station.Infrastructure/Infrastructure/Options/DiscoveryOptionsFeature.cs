using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.Station.Infrastructure.Options
{
    public class DiscoveryOptionsFeature
    {
        public IList<OptionsDescriptor> Options { get; } = new List<OptionsDescriptor>();
    }
}
