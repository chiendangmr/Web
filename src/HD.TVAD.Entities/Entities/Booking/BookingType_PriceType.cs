using HD.TVAD.Entities.Entities.Price;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Booking
{
    [Table("BookingType_PriceTypes", Schema = "Booking")]
    public class BookingType_PriceType
    {
        public BookingTypeEnum BookingTypeId { get; set; }

        [ForeignKey(nameof(BookingTypeId))]
        public BookingType BookingType { get; set; }

        public PriceTypeEnum PriceTypeId { get; set; }

        [ForeignKey(nameof(PriceTypeId))]
        public PriceType PriceType { get; set; }

        public int Index { get; set; }
    }
}
