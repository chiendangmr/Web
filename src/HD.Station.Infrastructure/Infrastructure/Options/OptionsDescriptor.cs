using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HD.Station.Infrastructure.Options
{
    public class OptionsDescriptor
    {
        public OptionsDescriptor(string path, TypeInfo type)
        {
            this.Path = path;
            this.OptionsType = type;
        }

        public string Path { get; }

        public TypeInfo OptionsType { get; }
    }
}
