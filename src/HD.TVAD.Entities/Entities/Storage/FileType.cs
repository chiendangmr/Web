using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Storage
{
    [Table("FileTypes", Schema = "Storage")]
    public class FileType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey("FileTypeId")]
        public ICollection<FileTypeExtension> FileTypeExtensions { get; } = new HashSet<FileTypeExtension>();

        [ForeignKey("FileTypeId")]
        public ICollection<Location> Locations { get; } = new HashSet<Location>();
    }
}
