using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class DiscountAnnexContracts
    {
        public DiscountAnnexContracts()
        {
            DiscountAnnexContractAssets = new HashSet<DiscountAnnexContractAssets>();
            DiscountAnnexContractTimeBandBases = new HashSet<DiscountAnnexContractTimeBandBases>();
        }

        public Guid Id { get; set; }
        public Guid AnnexContractId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Rate { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DiscountAnnexContractAssets> DiscountAnnexContractAssets { get; set; }
        public virtual ICollection<DiscountAnnexContractTimeBandBases> DiscountAnnexContractTimeBandBases { get; set; }
        public virtual AnnexContractPartners AnnexContract { get; set; }
    }
}
