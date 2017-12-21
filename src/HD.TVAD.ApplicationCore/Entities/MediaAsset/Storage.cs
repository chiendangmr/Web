using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities.MediaAsset
{
    public partial class Storage
    {
        public Storage()
        {
            StorageLocations = new HashSet<StorageLocation>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }  
        
        public virtual ICollection<StorageLocation> StorageLocations { get; set; }
    }
}
