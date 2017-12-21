using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDAdvertising.Datas.Security
{
    /// <summary>
    /// Link group and user
    /// </summary>
    public partial class Group_User
    {
        /// <summary>
        /// Id of group
        /// </summary>
        public Guid GroupId { get; set; }

        /// <summary>
        /// Id of user
        /// </summary>
        public Guid UserId { get; set; }
    }
}
