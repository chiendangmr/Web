using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Storage
{
    [Table("LocationAccessZones", Schema = "Storage")]
    public class LocationAccessZone
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid LocationId { get; set; }

        [ForeignKey(nameof(LocationId))]
        public Location Location { get; set; }

        public int AccessZoneId { get; set; }

        [ForeignKey(nameof(AccessZoneId))]
        public AccessZone AccessZone { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid? StorageAccessId { get; set; }

        [ForeignKey(nameof(StorageAccessId))]
        public Storage StorageAccess { get; set; }

        [ForeignKey("LocationAccessZoneId")]
        public ICollection<LocationAccessZoneUri> LocationAccessZoneUris { get; } = new HashSet<LocationAccessZoneUri>();

    }
}