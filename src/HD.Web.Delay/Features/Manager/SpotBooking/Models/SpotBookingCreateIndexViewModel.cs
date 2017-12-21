using HD.TVAD.ApplicationCore.Entities.Booking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class SpotBookingCreateIndexViewModel
	{
		[Display(Name = "Annex Contract")]
		public Guid AnnexContractId { get; set; }

		public Guid Id { get; set; }
		[Required]
		[Display(Name = "Broadcast Date")]
		public DateTime BroadcastDate { get; set; }
		[Required]
		[Display(Name = "TimeBand Slice")]
		public Guid TimeBandSliceId { get; set; }
		[Display(Name = "TimeBand")]
		public Guid TimeBandId { get; set; }
		[Display(Name = "Description")]
		public string Description { get; set; }

		[Display(Name = "Annex Contract Asset")]
		public Guid AnnexContractAssetId { get; set; }
		[Display(Name = "Asset Code")]
		public string AssetCode { get; set; }
		[Display(Name = "Spot")]
		public Guid SpotId { get; set; }
		[Display(Name = "Position")]
		public int? Position { get; set; }
		[Display(Name = "Position Approve")]
		public int? PositionApprove { get; set; }
		[Display(Name = "Booking Date")]
		public DateTime BookingDate { get; set; }
		[Display(Name = "Position Cost")]
		public bool IsPositionCost { get; set; }
		[Display(Name = "Card Rate Set")]
		public decimal? CardRateSet { get; set; }
		[Display(Name = "Position Rate Set")]
		public decimal? PositionRateSet { get; set; }
		[Display(Name = "Discount Rate Set")]
		public decimal? DiscountRateSet { get; set; }
		[Display(Name = "Card Rate Calc")]
		public decimal? CardRateCalc { get; set; }
		[Display(Name = "Position Rate Calc")]
		public decimal? PositionRateCalc { get; set; }
		[Display(Name = "Discount Rate Calc")]
		public decimal? DiscountRateCalc { get; set; }
		[Display(Name = "Calc Time")]
		public DateTime? CalcTime { get; set; }
		[Display(Name = "Spot Booking Request")]
		public Guid? SpotBookingRequestId { get; set; }


		public BookingTypeEnum BookingType { get; set; }
	}
}
