using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class UriTypes
    {
        public UriTypes()
        {
            LocationAccessZoneUris = new HashSet<LocationAccessZoneUris>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<LocationAccessZoneUris> LocationAccessZoneUris { get; set; }
    }
}
