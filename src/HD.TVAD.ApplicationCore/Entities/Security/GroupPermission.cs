using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HD.TVAD.ApplicationCore.Entities.Security
{
    [Table("Group_Permissions", Schema = "Security")]
    public partial class Group_Permission
    {
        public Guid GroupId { get; set; }

        public Guid PermissionId { get; set; }

        [ForeignKey(nameof(GroupId))]
        public virtual Group Group { get; set; }

        [ForeignKey(nameof(PermissionId))]
        public virtual Permission Permission { get; set; }
    }
}
