using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Storages
    {
        public Storages()
        {
            LocationAccessZones = new HashSet<LocationAccessZones>();
            Locations = new HashSet<Locations>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<LocationAccessZones> LocationAccessZones { get; set; }
        public virtual ICollection<Locations> Locations { get; set; }
    }
}
