using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities.MediaAsset
{
    public partial class AssetLocator
    {
        public AssetLocator()
        {
            
        }
        public Guid Id { get; set; }        
        public Guid AssetId { get; set; }
        public string ContainerMimeType { get; set; }
        public Guid StorageLocationId { get; set; }
        public DateTimeOffset UploadedDate { get; set; }
        public string Path { get; set; }
        public Byte[] Revision { get; set; }

        public virtual Asset Asset { get; set; }
        public virtual StorageLocation StorageLocation { get; set; }
        public virtual MimeType MimeType { get; set; }
    }
}
