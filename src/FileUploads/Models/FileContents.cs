using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class FileContents
    {
        public Guid Id { get; set; }
        public string Content { get; set; }

        public virtual Files IdNavigation { get; set; }
    }
}
