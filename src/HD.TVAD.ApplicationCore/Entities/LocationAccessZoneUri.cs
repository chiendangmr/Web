using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class LocationAccessZoneUri
    {
        public Guid Id { get; set; }
        public Guid LocationAccessZoneId { get; set; }
        public int UriTypeId { get; set; }
        public string Value { get; set; }
        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
        
        public virtual LocationAccessZone LocationAccessZone { get; set; }
        public virtual UriType UriType { get; set; }
    }
}
