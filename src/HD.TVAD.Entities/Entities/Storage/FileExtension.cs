using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Storage
{
    [Table("FileExtensions", Schema = "Storage")]
    public class FileExtension
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string Extension { get; set; }

        public string Description { get; set; }

        [ForeignKey("FileExtensionId")]
        public ICollection<FileTypeExtension> FileTypeExtensions { get; } = new HashSet<FileTypeExtension>();
    }
}
