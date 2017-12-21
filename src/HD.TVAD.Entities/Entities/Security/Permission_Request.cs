using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HD.TVAD.Entities.Entities.Security
{
    [Table("Permission_Requests", Schema = "Security")]
    public partial class Permission_Request
    {
        public Guid ParentId { get; set; }

        public Guid ChildrenId { get; set; }

        [ForeignKey(nameof(ChildrenId))]
        public Permission Children { get; set; }

        [ForeignKey(nameof(ParentId))]
        public Permission Parent { get; set; }
    }
}
