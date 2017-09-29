using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class UploadingFile
    {
        public UploadingFile()
        {
            UploadingPart = new HashSet<UploadingPart>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public Guid? ExternalId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

        public virtual ICollection<UploadingPart> UploadingPart { get; set; }
    }
}
