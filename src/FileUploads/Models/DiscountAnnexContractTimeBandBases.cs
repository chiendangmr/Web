using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class DiscountAnnexContractTimeBandBases
    {
        public Guid DiscountId { get; set; }
        public Guid TimeBandBaseId { get; set; }

        public virtual DiscountAnnexContracts Discount { get; set; }
        public virtual TimeBandBases TimeBandBase { get; set; }
    }
}
