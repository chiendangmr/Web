using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class AnnexContractPartners
    {
        public AnnexContractPartners()
        {
            AnnexContractPartnerPriceAtSignDates = new HashSet<AnnexContractPartnerPriceAtSignDates>();
            DiscountAnnexContracts = new HashSet<DiscountAnnexContracts>();
        }

        public Guid Id { get; set; }
        public DateTime SignDate { get; set; }
        public string ScheduleCampaign { get; set; }
        public string Content { get; set; }
        public Guid? SponsorProgramId { get; set; }
        public int? SponsorTypeId { get; set; }

        public virtual ICollection<AnnexContractPartnerPriceAtSignDates> AnnexContractPartnerPriceAtSignDates { get; set; }
        public virtual ICollection<DiscountAnnexContracts> DiscountAnnexContracts { get; set; }
        public virtual AnnexContracts IdNavigation { get; set; }
        public virtual SponsorPrograms SponsorProgram { get; set; }
        public virtual SponsorTypes SponsorType { get; set; }
    }
}
