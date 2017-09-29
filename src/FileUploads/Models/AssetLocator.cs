using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class AssetLocator
    {
        public Guid Id { get; set; }
        public Guid AssetId { get; set; }
        public string ContainerMineType { get; set; }
        public Guid StorageLocationId { get; set; }
        public DateTimeOffset UploadedDate { get; set; }
        public string Path { get; set; }
        public byte[] Revision { get; set; }

        public virtual Asset Asset { get; set; }
        public virtual MineType ContainerMineTypeNavigation { get; set; }
        public virtual StorageLocation StorageLocation { get; set; }
    }
}
