using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class BenefitPriceTimeBands
    {
        public Guid TimeBandId { get; set; }
        public Guid BenefitPriceId { get; set; }

        public virtual BenefitPrices BenefitPrice { get; set; }
        public virtual TimeBands TimeBand { get; set; }
    }
}
