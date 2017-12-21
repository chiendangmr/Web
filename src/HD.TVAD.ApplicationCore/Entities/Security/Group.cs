using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HD.TVAD.ApplicationCore.Entities.Security
{
    [Table("Groups", Schema = "Security")]
    public partial class Group
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public Guid? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public virtual Group Parent { get; set; }

        [ForeignKey(nameof(ParentId))]
        public virtual ICollection<Group> Childrens { get; } = new HashSet<Group>();

        [ForeignKey("GroupId")]
        public virtual ICollection<Group_Permission> GroupPermissions { get; set; }

        [ForeignKey("GroupId")]
        public virtual ICollection<Group_User> GroupUsers { get; set; }
    }
}
