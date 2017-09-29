using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class BenefitPriceSponsorPrograms
    {
        public Guid SponsorProgramId { get; set; }
        public Guid BenefitPriceId { get; set; }

        public virtual BenefitPrices BenefitPrice { get; set; }
        public virtual SponsorPrograms SponsorProgram { get; set; }
    }
}
