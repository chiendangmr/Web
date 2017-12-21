using HD.TVAD.Entities.Entities.Schedule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Booking
{
    [Table("SpotBookings", Schema = "Booking")]
    public class SpotBooking
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(Id))]
        public SpotContentByBooking SpotContent { get; set; }

        [Column("AnnexContractAssetId")]
        public Guid AnnexContractContentId { get; set; }

        [ForeignKey(nameof(AnnexContractContentId))]
        public AnnexContractContent AnnexContractContent { get; set; }

        public Guid SpotId { get; set; }

        [ForeignKey(nameof(SpotId))]
        public Spot Spot { get; set; }

        public int? Position { get; set; }

        public DateTime BookingDate { get; set; }

        public bool? PositionCost { get; set; }

        public decimal? CardRateSet { get; set; }

        public decimal? PositionRateSet { get; set; }

        public decimal? DiscountRateSet { get; set; }

        public decimal? CardRateCalc { get; set; }

        public DateTime? CardRateCalcTime { get; set; }

        public decimal? PositionRateCalc { get; set; }

        public DateTime? PositionRateCalcTime { get; set; }

        public decimal? DiscountRateCalc { get; set; }

        public DateTime? DiscountRateCalcTime { get; set; }

        public Guid? SpotBookingRequestId { get; set; }

        public DateTime? OriginalPriceDate { get; set; }

        public decimal? OriginalPriceRate { get; set; }

        public OriginalPriceTypeEnum? OriginalPriceType { get; set; }

        [ForeignKey(nameof(SpotBookingRequestId))]
        public SpotBooking SpotBookingRequest { get; set; }

        [ForeignKey(nameof(SpotBookingRequestId))]
        public ICollection<SpotBooking> SpotBookingRequires { get; } = new HashSet<SpotBooking>();
    }

    public enum OriginalPriceTypeEnum : int
    {
        All = 0,
        Increase = 1,
        Decrease = 2
    }
}
