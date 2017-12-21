using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.Localization
{
    /// <summary>
    /// Nội dung gốc
    /// </summary>
    [Table("LocalizableTexts", Schema = "Language")]
    public class LocalizableText
    {
        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Key { get; set; }

        [Required]
        [StringLength(190)]
        public string Scope { get; set; }

        public string Description { get; set; }
    }
}
