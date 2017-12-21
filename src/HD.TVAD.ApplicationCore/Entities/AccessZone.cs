using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class AccessZone
    {
        public AccessZone()
        {
            LocationAccessZones = new HashSet<LocationAccessZone>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<LocationAccessZone> LocationAccessZones { get; set; }
    }
}
