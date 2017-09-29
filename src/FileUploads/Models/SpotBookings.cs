using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class SpotBookings
    {
        public Guid Id { get; set; }
        public Guid AnnexContractAssetId { get; set; }
        public Guid SpotId { get; set; }
        public int? Position { get; set; }
        public DateTime BookingDate { get; set; }
        public bool? PositionCost { get; set; }
        public decimal? CardRateSet { get; set; }
        public decimal? PositionRateSet { get; set; }
        public decimal? DiscountRateSet { get; set; }
        public decimal? CardRateCalc { get; set; }
        public decimal? PositionRateCalc { get; set; }
        public decimal? DiscountRateCalc { get; set; }
        public DateTime? CalcTime { get; set; }
        public Guid? SpotBookingRequestId { get; set; }

        public virtual SpotAssetByBookings SpotAssetByBookings { get; set; }
        public virtual AnnexContractAssets AnnexContractAsset { get; set; }
        public virtual SpotBookings SpotBookingRequest { get; set; }
        public virtual ICollection<SpotBookings> InverseSpotBookingRequest { get; set; }
        public virtual Spots Spot { get; set; }
    }
}
