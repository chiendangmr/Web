using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDAdvertising.Datas.Security
{
    /// <summary>
    /// Link group and permission
    /// </summary>
    public partial class Group_Permission
    {
        /// <summary>
        /// Id of group
        /// </summary>
        public Guid GroupId { get; set; }

        /// <summary>
        /// Id of permission
        /// </summary>
        public Guid PermissionId { get; set; }
    }
}
