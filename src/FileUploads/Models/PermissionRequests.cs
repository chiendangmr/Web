using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class PermissionRequests
    {
        public Guid ParentId { get; set; }
        public Guid ChildrenId { get; set; }

        public virtual Permissions Children { get; set; }
        public virtual Permissions Parent { get; set; }
    }
}
