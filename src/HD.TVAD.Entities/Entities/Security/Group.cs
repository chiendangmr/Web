using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HD.TVAD.Entities.Entities.Security
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

		public bool Active { get; set; }

		[ForeignKey(nameof(ParentId))]
        public Group Parent { get; set; }

        [ForeignKey(nameof(ParentId))]
        public ICollection<Group> Childrens { get; } = new HashSet<Group>();

        [ForeignKey("GroupId")]
        public ICollection<Group_Permission> Group_Permissions { get; } = new HashSet<Group_Permission>();

        [ForeignKey("GroupId")]
        public ICollection<Group_User> Group_Users { get; } = new HashSet<Group_User>();
    }
}
