using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities.MediaAsset
{
    public partial class StorageLocation
    {
        public StorageLocation()
        {
            AssetLocators = new HashSet<AssetLocator>();
            StorageLocationAccesses = new HashSet<StorageLocationAccess>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }  
        public string Path { get; set; }
        public string UncPath { get; set; }
        public int? StorageType { get; set; }
        public string StorageTypeDescription { get; set; }
        public Guid? StorageId { get; set; }
        public Guid? AssetTypeId { get; set; }

        public virtual Storage Storage { get; set; }
        public virtual AssetType AssetType { get; set; }
        public virtual ICollection<AssetLocator> AssetLocators { get; set; }
        public virtual ICollection<StorageLocationAccess> StorageLocationAccesses { get; set; }
    
    }
}
