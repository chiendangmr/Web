using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class BenefitPrices
    {
        public BenefitPrices()
        {
            BenefitPriceSponsorPrograms = new HashSet<BenefitPriceSponsorPrograms>();
            BenefitPriceTimeBands = new HashSet<BenefitPriceTimeBands>();
        }

        public Guid Id { get; set; }
        public Guid BenefitTypeId { get; set; }
        public DateTime StartDate { get; set; }

        public virtual ICollection<BenefitPriceSponsorPrograms> BenefitPriceSponsorPrograms { get; set; }
        public virtual ICollection<BenefitPriceTimeBands> BenefitPriceTimeBands { get; set; }
        public virtual BenefitTypes BenefitType { get; set; }
    }
}
