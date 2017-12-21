using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HD.TVAD.Entities.Entities.Security
{
    [Table("Group_Users", Schema = "Security")]
    public partial class Group_User
    {
        public Guid GroupId { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey(nameof(GroupId))]
        public Group Group { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
