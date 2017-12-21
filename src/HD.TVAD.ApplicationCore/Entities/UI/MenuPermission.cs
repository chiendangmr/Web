using HD.TVAD.ApplicationCore.Entities.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HD.TVAD.ApplicationCore.Entities.UI
{
    [Table("Menu_Permissions", Schema = "UI")]
    public partial class Menu_Permission
    {
        public Guid MenuId { get; set; }

        public Guid PermissionId { get; set; }

        [ForeignKey(nameof(MenuId))]
        public virtual Menu Menu { get; set; }

        [ForeignKey(nameof(MenuId))]
        public virtual Permission Permission { get; set; }
    }
}
