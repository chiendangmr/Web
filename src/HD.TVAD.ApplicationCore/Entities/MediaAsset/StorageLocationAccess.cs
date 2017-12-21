using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities.MediaAsset
{
    public partial class StorageLocationAccess
    {
        public StorageLocationAccess()
        {
            StorageLocationAccessZones = new HashSet<StorageLocationAccessZone>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }  
        public Guid StorageLocationId { get; set; }
        public Guid StorageLocationAccessTypeId { get; set; }
        public string Identity { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int? Port { get; set; }
        public string Path { get; set; }
        public bool Readable { get; set; }
        public bool Writeable { get; set; }
        
        public virtual StorageLocation StorageLocation { get; set; }
        public virtual ICollection<StorageLocationAccessZone> StorageLocationAccessZones { get; set; }
        public virtual StorageLocationAccessType StorageLocationAccessType { get; set; }
    }
}
