using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities.MediaAsset
{
    public partial class StorageLocationAccessType
    {
        public StorageLocationAccessType()
        {
            StorageLocationAccesses = new HashSet<StorageLocationAccess>();
        }
        public Guid Id { get; set; }        
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<StorageLocationAccess> StorageLocationAccesses { get; set; }        
    }
}
