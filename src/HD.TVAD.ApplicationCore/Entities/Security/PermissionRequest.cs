using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HD.TVAD.ApplicationCore.Entities.Security
{
    [Table("Permission_Requests", Schema = "Security")]
    public partial class PermissionRequest
    {
        public Guid ParentId { get; set; }

        public Guid ChildrenId { get; set; }

        [ForeignKey(nameof(ChildrenId))]
        public virtual Permission Children { get; set; }

        [ForeignKey(nameof(ParentId))]
        public virtual Permission Parent { get; set; }
    }
}
