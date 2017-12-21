using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class Location
    {
        public Location()
        {
            FileDetailLocations = new HashSet<FileDetailLocation>();
            LocationAccessZones = new HashSet<LocationAccessZone>();
        }

        public Guid Id { get; set; }
        public Guid StorageId { get; set; }
        public int FileTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool CanUpload { get; set; }

        public virtual ICollection<FileDetailLocation> FileDetailLocations { get; set; }
        public virtual ICollection<LocationAccessZone> LocationAccessZones { get; set; }
        public virtual FileType FileType { get; set; }
        public virtual Storage.Storage Storage { get; set; }
    }
}
