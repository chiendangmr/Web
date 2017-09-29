using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Permissions
    {
        public Permissions()
        {
            GroupPermissions = new HashSet<GroupPermissions>();
            MenuPermissions = new HashSet<MenuPermissions>();
            PermissionRequestsChildren = new HashSet<PermissionRequests>();
            PermissionRequestsParent = new HashSet<PermissionRequests>();
            UserPermissions = new HashSet<UserPermissions>();
        }

        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string Type { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }
        public int Index { get; set; }

        public virtual ICollection<GroupPermissions> GroupPermissions { get; set; }
        public virtual ICollection<MenuPermissions> MenuPermissions { get; set; }
        public virtual ICollection<PermissionRequests> PermissionRequestsChildren { get; set; }
        public virtual ICollection<PermissionRequests> PermissionRequestsParent { get; set; }
        public virtual ICollection<UserPermissions> UserPermissions { get; set; }
        public virtual Permissions Parent { get; set; }
        public virtual ICollection<Permissions> InverseParent { get; set; }
    }
}
