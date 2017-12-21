using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace HDAdvertising.Datas
{
    public static class Extensions
    {
        public static T GetDisplayTextAttributeOfType<T>(Enum val) where T : Attribute
        {
            var type = val.GetType();
            var memInfo = type.GetMember(val.ToString());
            IEnumerable<Attribute> attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes?.ToArray()[0];
        }
    }
}
