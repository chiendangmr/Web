using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Storage
{
    [Table("LocationAccessZoneUris", Schema = "Storage")]
    public class LocationAccessZoneUri
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public int UriTypeId { get; set; }

        [ForeignKey(nameof(UriTypeId))]
        public UriType UriType { get; set; }

        public Guid LocationAccessZoneId { get; set; }

        [ForeignKey(nameof(LocationAccessZoneId))]
        public LocationAccessZone LocationAccessZone { get; set; }

        [Required]
        public string Value { get; set; }

        public bool CanRead { get; set; }

        public bool CanWrite { get; set; }
    }
}
