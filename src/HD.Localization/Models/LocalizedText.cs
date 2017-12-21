using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.Localization
{
    [Table("LocalizedTexts", Schema = "Language")]
    public class LocalizedText
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(256)]
        public string Key { get; set; }

        [Required]
        [StringLength(16)]
        public string Culture { get; set; }

        [StringLength(190)]
        public string Scope { get; set; }

        public bool Disabled { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
