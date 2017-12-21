using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class BenefitPrice
    {
        public BenefitPrice()
        {
            BenefitPriceSponsorPrograms = new HashSet<BenefitPriceSponsorProgram>();
            BenefitPriceTimeBands = new HashSet<BenefitPriceTimeBand>();
        }

        public Guid Id { get; set; }
        public Guid BenefitTypeId { get; set; }
        public DateTime StartDate { get; set; }
		public decimal Price { get; set; }
		

		public virtual ICollection<BenefitPriceSponsorProgram> BenefitPriceSponsorPrograms { get; set; }
        public virtual ICollection<BenefitPriceTimeBand> BenefitPriceTimeBands { get; set; }
        public virtual BenefitType BenefitType { get; set; }
    }
}
