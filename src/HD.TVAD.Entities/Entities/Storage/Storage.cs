using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Storage
{
    [Table("Storages", Schema = "Storage")]
    public class Storage
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey("StorageId")]
        public ICollection<Location> Locations { get; } = new HashSet<Location>();

        [ForeignKey("StorageAccessId")]
        public ICollection<LocationAccessZone> AccessLocationAccessZones { get; } = new HashSet<LocationAccessZone>();
    }
}
