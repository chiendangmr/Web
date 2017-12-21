using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.ApplicationCore.Entities.Storage
{
    [Table("FileTypeExtensions", Schema = "Storage")]
    public class FileTypeExtension
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public int FileTypeId { get; set; }

        public Guid FileExtensionId { get; set; }

        public string MediaInfoParameters { get; set; }

        [ForeignKey(nameof(FileExtensionId))]
        public FileExtension FileExtension { get; set; }

        [ForeignKey(nameof(FileTypeId))]
        public FileType FileType { get; set; }
    }
}
