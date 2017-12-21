using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDAdvertising.Datas.Security
{
    /// <summary>
    /// User group object
    /// </summary>
    public partial class Group
    {
        public Group()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Id of group
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of group
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Id of parent group if exists
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// Parent group, can null if not include parent
        /// </summary>
        public Group Parent { get; set; }

        /// <summary>
        /// Childrens group, can empty if not include
        /// </summary>
        public ICollection<Group> Childrens { get; } = new List<Group>();

        /// <summary>
        /// Users on group
        /// </summary>
        public ICollection<Group_User> Users { get; } = new List<Group_User>();

        /// <summary>
        /// Permissions of group
        /// </summary>
        public ICollection<Group_Permission> Permissions { get; } = new List<Group_Permission>();
    }
}
