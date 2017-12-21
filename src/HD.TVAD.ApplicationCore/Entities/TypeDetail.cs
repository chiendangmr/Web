using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class TypeDetail
    {
        public TypeDetail()
        {
            AnnexContractAssets = new HashSet<AnnexContractAsset>();
        }

        public Guid Id { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AnnexContractAsset> AnnexContractAssets { get; set; }
        public virtual RateSpotBlock RateSpotBlocks { get; set; }
        public virtual RetailType RetailTypes { get; set; }
		public virtual BenefitType BenefitType { get; set; }
		public virtual PriceType Type { get; set; }
    }
}
