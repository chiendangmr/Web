using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class TypeDetails
    {
        public TypeDetails()
        {
            AnnexContractAssets = new HashSet<AnnexContractAssets>();
        }

        public Guid Id { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AnnexContractAssets> AnnexContractAssets { get; set; }
        public virtual BenefitTypes BenefitTypes { get; set; }
        public virtual RateSpotBlocks RateSpotBlocks { get; set; }
        public virtual RetailTypes RetailTypes { get; set; }
        public virtual PriceTypes Type { get; set; }
    }
}
