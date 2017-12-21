using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class UriType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<LocationAccessZoneUri> LocationAccessZoneUri { get; set; }        
    }
}
