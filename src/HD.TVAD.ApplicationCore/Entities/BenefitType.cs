using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class BenefitType
    {
        public BenefitType()
        {
            BenefitPrices = new HashSet<BenefitPrice>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BenefitPrice> BenefitPrices { get; set; }
        public virtual TypeDetail TypeDetail { get; set; }
	}
}
