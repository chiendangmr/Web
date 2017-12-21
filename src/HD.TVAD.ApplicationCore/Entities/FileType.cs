using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class FileType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<File> Files { get; } = new HashSet<File>();

        public virtual ICollection<Location> Locations { get; } = new HashSet<Location>();

        [ForeignKey("FileTypeId")]
        public ICollection<Storage.FileTypeExtension> FileTypeExtensions { get; } = new HashSet<Storage.FileTypeExtension>();

        [ForeignKey("FileTypeId")]
        public ICollection<ContentType> AssetTypes { get; } = new HashSet<ContentType>();
    }
}
