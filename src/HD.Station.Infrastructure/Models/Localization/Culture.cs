using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HD.Station.Models.Localization
{
    [Table("Language")]
    public class Culture
    {
        [Key]
        [Column("Culture")]
        public string Name { get; set; }

        public string ParentCulture { get; set; }

        public bool Disabled { get; set; }

        [ForeignKey(nameof(ParentCulture))]
        public Culture Parent { get; set; }
    }
}
