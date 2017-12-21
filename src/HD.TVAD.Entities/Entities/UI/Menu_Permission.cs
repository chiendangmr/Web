using HD.TVAD.Entities.Entities.Security;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HD.TVAD.Entities.Entities.UI
{
    [Table("Menu_Permissions", Schema = "UI")]
    public partial class Menu_Permission
    {
        public Guid MenuId { get; set; }

        public Guid PermissionId { get; set; }

        [ForeignKey(nameof(MenuId))]
        public Menu Menu { get; set; }

        [ForeignKey(nameof(PermissionId))]
        public Permission Permission { get; set; }
    }
}
