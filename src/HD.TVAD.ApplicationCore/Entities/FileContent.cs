using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class FileContent
    {
        public Guid Id { get; set; }
        public string Content { get; set; }

        public virtual File IdNavigation { get; set; }
    }
}
