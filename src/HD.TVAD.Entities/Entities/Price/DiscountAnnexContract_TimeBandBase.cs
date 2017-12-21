using HD.TVAD.Entities.Entities.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Price
{
    [Table("DiscountAnnexContract_TimeBandBases", Schema = "Price")]
    public class DiscountAnnexContract_TimeBandBase
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid DiscountId { get; set; }

        [ForeignKey(nameof(DiscountId))]
        public DiscountAnnexContract Discount { get; set; }

        public Guid TimeBandBaseId { get; set; }

        [ForeignKey(nameof(TimeBandBaseId))]
        public TimeBandBase TimeBandBase { get; set; }
    }
}
