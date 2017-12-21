using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities.MediaAsset
{
    public partial class AccessZone
    {
        public AccessZone()
        {
            StorageLocationAccessZones = new HashSet<StorageLocationAccessZone>();
        }
        public Guid Id { get; set; }        
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<StorageLocationAccessZone> StorageLocationAccessZones { get; set; }
    }
}
