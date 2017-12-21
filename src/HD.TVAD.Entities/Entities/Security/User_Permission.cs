using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HD.TVAD.Entities.Entities.Security
{
    [Table("User_Permissions", Schema = "Security")]
    public partial class User_Permission
    {
        public Guid UserId { get; set; }

        public Guid PermissionId { get; set; }

        [ForeignKey(nameof(PermissionId))]
        public Permission Permission { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
