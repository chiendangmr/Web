using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class SponsorProgram
    {
        public SponsorProgram()
        {
            AnnexContractPartners = new HashSet<AnnexContractPartner>();
            DiscountSponsorPrograms = new HashSet<DiscountSponsorProgram>();
			BenefitPriceSponsorPrograms = new HashSet<BenefitPriceSponsorProgram>();

		}

        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }
		public Guid? DefaultContractTypeId { get; set; }

		public virtual ICollection<AnnexContractPartner> AnnexContractPartners { get; set; }
        public virtual ICollection<DiscountSponsorProgram> DiscountSponsorPrograms { get; set; }
		public virtual ICollection<BenefitPriceSponsorProgram> BenefitPriceSponsorPrograms { get; set; }		
		public virtual SponsorProgram Parent { get; set; }
        public virtual ICollection<SponsorProgram> InverseParent { get; set; }
		public virtual AnnexContractType AnnexContractType { get; set; }
	}
}
