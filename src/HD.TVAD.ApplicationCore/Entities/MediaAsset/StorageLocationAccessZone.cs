using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities.MediaAsset
{
    public partial class StorageLocationAccessZone
    {
        public StorageLocationAccessZone()
        {
            
        }
        public Guid Id { get; set; }        
        public Guid StorageLocationAccessId { get; set; }
        public Guid AccessZoneId { get; set; }

        public virtual StorageLocationAccess StorageLocationAccess { get; set; }
        public virtual AccessZone AccessZone { get; set; }
    }
}
