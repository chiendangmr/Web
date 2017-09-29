using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class FileTypes
    {
        public FileTypes()
        {
            AssetTypes = new HashSet<AssetTypes>();
            Files = new HashSet<Files>();
            FileTypeExtensions = new HashSet<FileTypeExtensions>();
            Locations = new HashSet<Locations>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AssetTypes> AssetTypes { get; set; }
        public virtual ICollection<Files> Files { get; set; }
        public virtual ICollection<FileTypeExtensions> FileTypeExtensions { get; set; }
        public virtual ICollection<Locations> Locations { get; set; }
    }
}
