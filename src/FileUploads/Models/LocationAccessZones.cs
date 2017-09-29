using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class LocationAccessZones
    {
        public LocationAccessZones()
        {
            LocationAccessZoneUris = new HashSet<LocationAccessZoneUris>();
        }

        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public int AccessZoneId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? StorageAccessId { get; set; }
        public string VirtualPath { get; set; }
        public string SmbPath { get; set; }
        public string FtpUri { get; set; }

        public virtual ICollection<LocationAccessZoneUris> LocationAccessZoneUris { get; set; }
        public virtual AccessZones AccessZone { get; set; }
        public virtual Locations Location { get; set; }
        public virtual Storages StorageAccess { get; set; }
    }
}
