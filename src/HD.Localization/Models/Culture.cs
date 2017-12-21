using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.Localization
{
    [Table("Cultures", Schema = "Language")]
    public class Culture
    {
        [Key]
        [MaxLength(16)]
        public string Name { get; set; }

        [MaxLength(16)]
        [Column("Parent")]
        public string ParentName { get; set; }

        public bool Disabled { get; set; }

        [ForeignKey(nameof(ParentName))]
        public Culture Parent { get; set; }
        
        [ForeignKey(nameof(ParentName))]
        public ICollection<Culture> Chidrens { get; } = new HashSet<Culture>();
    }
}
