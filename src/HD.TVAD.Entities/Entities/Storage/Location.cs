using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Storage
{
    [Table("Locations", Schema = "Storage")]
    public class Location
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid StorageId { get; set; }

        [ForeignKey(nameof(StorageId))]
        public Storage Storage { get; set; }

        public int FileTypeId { get; set; }

        [ForeignKey(nameof(FileTypeId))]
        public FileType FileType { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey("LocationId")]
        public ICollection<LocationAccessZone> LocationAccessZones { get; } = new HashSet<LocationAccessZone>();
    }
}
