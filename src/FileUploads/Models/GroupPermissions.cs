using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class GroupPermissions
    {
        public Guid GroupId { get; set; }
        public Guid PermissionId { get; set; }

        public virtual Groups Group { get; set; }
        public virtual Permissions Permission { get; set; }
    }
}
