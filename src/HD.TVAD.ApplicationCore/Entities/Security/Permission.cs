using HD.TVAD.ApplicationCore.Entities.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HD.TVAD.ApplicationCore.Entities.Security
{
    [Table("Permissions", Schema = "Security")]
    public partial class Permission
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public virtual Permission Parent { get; set; }

        [ForeignKey(nameof(ParentId))]
        public virtual ICollection<Permission> Childrens { get; set; }

        public string Type { get; set; }

        public string DisplayName { get; set; }

        public string Value { get; set; }

        public int Index { get; set; }

        [ForeignKey("PermissionId")]
        public virtual ICollection<Group_Permission> GroupPermissions { get; } = new HashSet<Group_Permission>();

        [ForeignKey("PermissionId")]
        public virtual ICollection<Menu_Permission> Menu_Permissions { get; } = new HashSet<Menu_Permission>();

        [ForeignKey("PermissionId")]
        public virtual ICollection<User_Permission> UserPermissions { get; } = new HashSet<User_Permission>();

        [ForeignKey("ParentId")]
        public virtual ICollection<PermissionRequest> PermissionsRequestMe { get; } = new HashSet<PermissionRequest>();

        [ForeignKey("ChildrenId")]
        public virtual ICollection<PermissionRequest> PermissionsMeRequest { get; } = new HashSet<PermissionRequest>();
    }
}
