using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class AccessZones
    {
        public AccessZones()
        {
            LocationAccessZones = new HashSet<LocationAccessZones>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<LocationAccessZones> LocationAccessZones { get; set; }
    }
}
