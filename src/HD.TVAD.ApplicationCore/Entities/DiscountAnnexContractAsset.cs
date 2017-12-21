using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class DiscountAnnexContractAsset
    {
        public Guid DiscountId { get; set; }
        public Guid AssetId { get; set; }

        public virtual Content Asset { get; set; }
        public virtual DiscountAnnexContract Discount { get; set; }
    }
}
