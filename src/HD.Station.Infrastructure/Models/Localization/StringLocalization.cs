using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HD.Station.Models.Localization
{
    [Table("StringLocalization")]
    public class StringLocalization
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(256)]
        public string Location { get; set; }

        [StringLength(1024)]
        public string Key { get; set; }

        [StringLength(64)]
        public string Culture { get; set; }

        public string Value { get; set; }
    }
}
