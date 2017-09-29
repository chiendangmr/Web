using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class SponsorPrograms
    {
        public SponsorPrograms()
        {
            AnnexContractPartners = new HashSet<AnnexContractPartners>();
            BenefitPriceSponsorPrograms = new HashSet<BenefitPriceSponsorPrograms>();
            DiscountSponsorPrograms = new HashSet<DiscountSponsorPrograms>();
        }

        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<AnnexContractPartners> AnnexContractPartners { get; set; }
        public virtual ICollection<BenefitPriceSponsorPrograms> BenefitPriceSponsorPrograms { get; set; }
        public virtual ICollection<DiscountSponsorPrograms> DiscountSponsorPrograms { get; set; }
        public virtual SponsorPrograms Parent { get; set; }
        public virtual ICollection<SponsorPrograms> InverseParent { get; set; }
    }
}
