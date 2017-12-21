using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities.MediaAsset
{
    public partial class AssetType
    {
        public AssetType()
        {
            Assets = new HashSet<Asset>();
            StorageLocations = new HashSet<StorageLocation>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DefaultPath { get; set; }
        public Byte[] Revision { get; set; }
        public bool Editable { get; set; }    
        
        public virtual ICollection<Asset> Assets { get; set; }
        public virtual ICollection<StorageLocation> StorageLocations { get; set; }
    }
}
