using HD.TVAD.Entities.Entities.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Price
{
    [Table("BenefitPrice_TimeBands", Schema = "Price")]
    public class BenefitPrice_TimeBand
    {
        public Guid TimeBandId { get; set; }

        [ForeignKey(nameof(TimeBandId))]
        public TimeBand TimeBand { get; set; }

        public Guid BenefitPriceId { get; set; }

        [ForeignKey(nameof(BenefitPriceId))]
        public BenefitPrice BenefitPrice { get; set; }
    }
}
