using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class LocationAccessZoneUris
    {
        public Guid Id { get; set; }
        public int UriTypeId { get; set; }
        public Guid LocationAccessZoneId { get; set; }
        public string Value { get; set; }
        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }

        public virtual LocationAccessZones LocationAccessZone { get; set; }
        public virtual UriTypes UriType { get; set; }
    }
}
