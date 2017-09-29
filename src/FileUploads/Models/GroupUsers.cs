using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class GroupUsers
    {
        public Guid GroupId { get; set; }
        public Guid UserId { get; set; }

        public virtual Groups Group { get; set; }
        public virtual Users User { get; set; }
    }
}
