using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class BenefitTypes
    {
        public BenefitTypes()
        {
            BenefitPrices = new HashSet<BenefitPrices>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BenefitPrices> BenefitPrices { get; set; }
        public virtual TypeDetails IdNavigation { get; set; }
    }
}
