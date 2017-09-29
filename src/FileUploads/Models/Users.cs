using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Users
    {
        public Users()
        {
            GroupUsers = new HashSet<GroupUsers>();
            UserPermissions = new HashSet<UserPermissions>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ConcurrencyStamp { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<GroupUsers> GroupUsers { get; set; }
        public virtual ICollection<UserPermissions> UserPermissions { get; set; }
    }
}
