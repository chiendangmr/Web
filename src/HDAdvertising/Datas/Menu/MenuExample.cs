using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDAdvertising.Datas.Menu
{
    public partial class MenuExample : UI.Menu
    {
        public string PermissionNames { get; set; }

        public List<MenuExample> Items { get; set; }
    }
}
