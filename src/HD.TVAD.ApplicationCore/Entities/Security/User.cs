using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HD.TVAD.ApplicationCore.Entities.Security
{
    [Table("Users", Schema = "Security")]
    public partial class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [ConcurrencyCheck]
        public string ConcurrencyStamp { get; set; }

        public bool Active { get; set; }

        [ForeignKey("UserId")]
        public virtual ICollection<Group_User> GroupUsers { get; } = new HashSet<Group_User>();

        [ForeignKey("UserId")]
        public virtual ICollection<User_Permission> UserPermissions { get; } = new HashSet<User_Permission>();		
	}
}
