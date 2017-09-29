using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class FileTypeExtensions
    {
        public Guid Id { get; set; }
        public int FileTypeId { get; set; }
        public Guid FileExtensionId { get; set; }
        public string MediaInfoParameters { get; set; }

        public virtual FileExtensions FileExtension { get; set; }
        public virtual FileTypes FileType { get; set; }
    }
}
