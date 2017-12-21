using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class DiscountAnnexContract
    {
        public DiscountAnnexContract()
        {
            DiscountAnnexContractAssets = new HashSet<DiscountAnnexContractAsset>();
            DiscountAnnexContractTimeBandBases = new HashSet<DiscountAnnexContractTimeBandBase>();
        }

        public Guid Id { get; set; }
        public Guid AnnexContractId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Rate { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DiscountAnnexContractAsset> DiscountAnnexContractAssets { get; set; }
        public virtual ICollection<DiscountAnnexContractTimeBandBase> DiscountAnnexContractTimeBandBases { get; set; }
        public virtual AnnexContractPartner AnnexContract { get; set; }
    }
}
