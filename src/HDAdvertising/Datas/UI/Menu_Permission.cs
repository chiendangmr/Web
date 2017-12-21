using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDAdvertising.Datas.UI
{
    /// <summary>
    /// Link menu and permission
    /// </summary>
    public partial class Menu_Permission
    {
        /// <summary>
        /// Id of menu
        /// </summary>
        public Guid MenuId { get; set; }

        /// <summary>
        /// Id of permission
        /// </summary>
        public Guid PermissionId { get; set; }
    }
}
