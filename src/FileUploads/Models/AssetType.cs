using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class AssetType
    {
        public AssetType()
        {
            Asset = new HashSet<Asset>();
            StorageLocation = new HashSet<StorageLocation>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DefaultPath { get; set; }
        public byte[] Revision { get; set; }
        public bool Editable { get; set; }

        public virtual ICollection<Asset> Asset { get; set; }
        public virtual ICollection<StorageLocation> StorageLocation { get; set; }
    }
}
