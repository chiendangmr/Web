using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class DiscountAnnexContractTimeBandBase
    {
        public Guid DiscountId { get; set; }
        public Guid TimeBandBaseId { get; set; }

        public virtual DiscountAnnexContract Discount { get; set; }
        public virtual TimeBandBase TimeBandBase { get; set; }
    }
}
