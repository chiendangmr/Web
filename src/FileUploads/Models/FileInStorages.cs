using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class FileInStorages
    {
        public FileInStorages()
        {
            FileDetails = new HashSet<FileDetails>();
        }

        public Guid Id { get; set; }

        public virtual ICollection<FileDetails> FileDetails { get; set; }
        public virtual Files IdNavigation { get; set; }
    }
}
