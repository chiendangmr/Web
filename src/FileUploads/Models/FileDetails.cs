using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class FileDetails
    {
        public FileDetails()
        {
            FileDetailLocations = new HashSet<FileDetailLocations>();
        }

        public Guid Id { get; set; }
        public Guid? FileId { get; set; }
        public int Index { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual ICollection<FileDetailLocations> FileDetailLocations { get; set; }
        public virtual FileInStorages File { get; set; }
    }
}
