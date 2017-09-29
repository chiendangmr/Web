using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class UserPermissions
    {
        public Guid UserId { get; set; }
        public Guid PermissionId { get; set; }

        public virtual Permissions Permission { get; set; }
        public virtual Users User { get; set; }
    }
}
