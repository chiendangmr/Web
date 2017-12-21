using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class LocationAccessZone
    {
        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public int AccessZoneId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VirtualPath { get; set; }
        public string SmbPath { get; set; }
        public string FtpUri { get; set; }

        public virtual AccessZone AccessZone { get; set; }
        public virtual Location Location { get; set; }     
        public virtual ICollection<LocationAccessZoneUri> LocationAccessZoneUri { get; set; }
    }
}
