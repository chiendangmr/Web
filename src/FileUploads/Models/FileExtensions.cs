using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class FileExtensions
    {
        public FileExtensions()
        {
            FileTypeExtensions = new HashSet<FileTypeExtensions>();
        }

        public Guid Id { get; set; }
        public string Extension { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FileTypeExtensions> FileTypeExtensions { get; set; }
    }
}
