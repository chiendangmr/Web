using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDAdvertising.Models.AdministratorViewModels
{
    public partial class GroupPermissionViewModel
    {
        public bool Check { get; set; }

        public Guid GroupId { get; set; }

        public Guid PermissionId { get; set; }

        public Guid? PermissionParentId { get; set; }

        public string PermissionDisplayName { get; set; }
    }
}
