using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class BenefitPriceTimeBand
    {
        public Guid TimeBandId { get; set; }
        public Guid BenefitPriceId { get; set; }

        public virtual BenefitPrice BenefitPrice { get; set; }
        public virtual TimeBand TimeBand { get; set; }
    }
}
