using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class AnnexContractPartner
    {
        public AnnexContractPartner()
        {
            AnnexContractPartnerPriceAtSignDates = new HashSet<AnnexContractPartnerPriceAtSignDate>();
            DiscountAnnexContracts = new HashSet<DiscountAnnexContract>();
        }

        public Guid Id { get; set; }
        public DateTime SignDate { get; set; }
        public string ScheduleCampaign { get; set; }
        public string Content { get; set; }
        public Guid? SponsorProgramId { get; set; }
        public int? SponsorTypeId { get; set; }

        public virtual ICollection<AnnexContractPartnerPriceAtSignDate> AnnexContractPartnerPriceAtSignDates { get; set; }
        public virtual ICollection<DiscountAnnexContract> DiscountAnnexContracts { get; set; }
        public virtual AnnexContract AnnexContract { get; set; }
        public virtual SponsorProgram SponsorProgram { get; set; }
        public virtual SponsorType SponsorType { get; set; }

		public bool HasSponsorProgram { get {
				return SponsorProgramId.HasValue; }
		}

	}
}
