using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDAdvertising.Datas.Security
{
    /// <summary>
    /// User object
    /// </summary>
    public partial class User
    {
        public User()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Id of user
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// user name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Base64 of password hash by md5
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Full name of user
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Email of user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Phone number of user
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Concurrency stamp
        /// </summary>
        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Aactived / Deactived
        /// </summary>
        public bool Active { get; set; } = false;

        /// <summary>
        /// Groups of user
        /// </summary>
        public ICollection<Group_User> Groups { get; } = new List<Group_User>();

        ///// <summary>
        ///// Permissions thêm riêng cho user
        ///// </summary>
        //public ICollection<User_Permission> Permissions { get; } = new List<User_Permission>();
    }
}
