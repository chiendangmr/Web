using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Locations
    {
        public Locations()
        {
            FileDetailLocations = new HashSet<FileDetailLocations>();
            LocationAccessZones = new HashSet<LocationAccessZones>();
        }

        public Guid Id { get; set; }
        public Guid StorageId { get; set; }
        public int FileTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool CanUpload { get; set; }

        public virtual ICollection<FileDetailLocations> FileDetailLocations { get; set; }
        public virtual ICollection<LocationAccessZones> LocationAccessZones { get; set; }
        public virtual FileTypes FileType { get; set; }
        public virtual Storages Storage { get; set; }
    }
}
