using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class DiscountAnnexContractAssets
    {
        public Guid DiscountId { get; set; }
        public Guid AssetId { get; set; }

        public virtual Content Asset { get; set; }
        public virtual DiscountAnnexContracts Discount { get; set; }
    }
}
