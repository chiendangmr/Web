using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class BenefitPriceSponsorProgram
    {
        public Guid SponsorProgramId { get; set; }
        public Guid BenefitPriceId { get; set; }

        public virtual BenefitPrice BenefitPrice { get; set; }
        public virtual SponsorProgram SponsorProgram { get; set; }
    }
}
