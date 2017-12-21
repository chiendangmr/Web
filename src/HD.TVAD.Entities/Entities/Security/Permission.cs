using HD.TVAD.Entities.Entities.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HD.TVAD.Entities.Entities.Security
{
    [Table("Permissions", Schema = "Security")]
    public partial class Permission
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public Permission Parent { get; set; }

        [ForeignKey(nameof(ParentId))]
        public ICollection<Permission> Childrens { get; } = new HashSet<Permission>();

        [Required]
        [StringLength(256)]
        public string Type { get; set; }

        public string DisplayName { get; set; }

        public string Value { get; set; }

        public int Index { get; set; } = 0;

        [ForeignKey("PermissionId")]
        public ICollection<Group_Permission> Group_Permissions { get; } = new HashSet<Group_Permission>();

        [ForeignKey("PermissionId")]
        public ICollection<User_Permission> User_Permissions { get; } = new HashSet<User_Permission>();

        [ForeignKey("ParentId")]
        public ICollection<Permission_Request> PermissionsRequestMe { get; } = new HashSet<Permission_Request>();

        [ForeignKey("ChildrenId")]
        public ICollection<Permission_Request> PermissionsMeRequest { get; } = new HashSet<Permission_Request>();

        [ForeignKey("PermissionId")]
        public ICollection<Menu_Permission> Menu_Permissions { get; } = new HashSet<Menu_Permission>();
    }
}
