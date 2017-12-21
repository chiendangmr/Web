using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class BookingTypePriceType
    {
        public int BookingTypeId { get; set; }
        public int PriceTypeId { get; set; }
        public int Index { get; set; }

        public virtual BookingType BookingType { get; set; }
        public virtual PriceType PriceType { get; set; }
    }
}
