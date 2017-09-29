using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class BookingTypePriceTypes
    {
        public int BookingTypeId { get; set; }
        public int PriceTypeId { get; set; }
        public int Index { get; set; }

        public virtual BookingTypes BookingType { get; set; }
        public virtual PriceTypes PriceType { get; set; }
    }
}
