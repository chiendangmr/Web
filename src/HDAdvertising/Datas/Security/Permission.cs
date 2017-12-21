using HDAdvertising.Datas.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDAdvertising.Datas.Security
{
    /// <summary>
    /// Permission objects
    /// </summary>
    public partial class Permission
    {
        public Permission()
        {
            Id = Guid.NewGuid();
            Index = -1;
        }

        /// <summary>
        /// Id of permission
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id of parent permission
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// Parent permission
        /// </summary>
        public Permission Parent { get; set; }

        /// <summary>
        /// Childrens permission
        /// </summary>
        public ICollection<Permission> Childrens { get; } = new List<Permission>();

        /// <summary>
        /// Type of permission, example: System, Channel
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Display text on UI
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Value of permission
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Visible index on UI
        /// </summary>
        public int Index { get; set; }

        ///// <summary>
        ///// Request permissions
        ///// </summary>
        //public ICollection<Permission_Request> RequestParents { get; } = new List<Permission_Request>();

        ///// <summary>
        ///// Permissions request
        ///// </summary>
        //public ICollection<Permission_Request> RequestChildrens { get; } = new List<Permission_Request>();

        /// <summary>
        /// Groups have permission
        /// </summary>
        public ICollection<Group_Permission> Groups { get; } = new List<Group_Permission>();

        ///// <summary>
        ///// Users have permission
        ///// </summary>
        //public ICollection<User_Permission> Users { get; } = new List<User_Permission>();

        /// <summary>
        /// Menus request
        /// </summary>
        public ICollection<Menu_Permission> Menus { get; } = new List<Menu_Permission>();
    }
}
