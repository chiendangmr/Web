using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Groups
    {
        public Groups()
        {
            GroupPermissions = new HashSet<GroupPermissions>();
            GroupUsers = new HashSet<GroupUsers>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }

        public virtual ICollection<GroupPermissions> GroupPermissions { get; set; }
        public virtual ICollection<GroupUsers> GroupUsers { get; set; }
        public virtual Groups Parent { get; set; }
        public virtual ICollection<Groups> InverseParent { get; set; }
    }
}
