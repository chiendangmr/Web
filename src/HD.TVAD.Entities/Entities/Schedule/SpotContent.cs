using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Schedule
{
    [Table("SpotAssets", Schema = "Schedule")]
    public class SpotContent
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(Id))]
        public SpotContentByContent ByContent { get; set; }

        [ForeignKey(nameof(Id))]
        public SpotContentByBooking ByBooking { get; set; }

        public Guid SpotId { get; set; }

        [ForeignKey(nameof(SpotId))]
        public Spot Spot { get; set; }

        public int Index { get; set; }
    }
}
