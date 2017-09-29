using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class StorageLocation
    {
        public StorageLocation()
        {
            AssetLocator = new HashSet<AssetLocator>();
            StorageLocationAccess = new HashSet<StorageLocationAccess>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public string UncPath { get; set; }
        public int StorageType { get; set; }
        public string StorageTypeDescription { get; set; }
        public Guid? StorageId { get; set; }
        public Guid? AssetTypeId { get; set; }

        public virtual ICollection<AssetLocator> AssetLocator { get; set; }
        public virtual ICollection<StorageLocationAccess> StorageLocationAccess { get; set; }
        public virtual AssetType AssetType { get; set; }
        public virtual Storage Storage { get; set; }
    }
}
