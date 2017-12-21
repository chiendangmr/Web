using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Storage
{
    [Table("AccessZones", Schema = "Storage")]
    public class AccessZone
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey("AccessZoneId")]
        public ICollection<LocationAccessZone> LocationAccessZones { get; } = new HashSet<LocationAccessZone>();
    }
}
