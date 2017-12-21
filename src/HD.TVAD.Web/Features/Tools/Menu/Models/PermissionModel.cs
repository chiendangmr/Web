using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Tools.Menu.Models
{
    public class PermissionModel
    {
        public Guid id { get; set; }

        public Guid? parentId { get; set; }

        public string displayName { get; set; }
    }
}
