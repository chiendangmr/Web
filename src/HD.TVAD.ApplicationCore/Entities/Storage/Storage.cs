using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HD.TVAD.ApplicationCore.Entities.Storage
{
    [Table("Storages", Schema = "Storage")]
    public partial class Storage
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey("StorageId")]
        public virtual ICollection<Location> Locations { get; } = new HashSet<Location>();
    }
}
