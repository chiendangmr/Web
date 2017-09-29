using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class MenuPermissions
    {
        public Guid MenuId { get; set; }
        public Guid PermissionId { get; set; }

        public virtual Menus Menu { get; set; }
        public virtual Permissions Permission { get; set; }
    }
}
