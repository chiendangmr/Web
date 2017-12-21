using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
	public class SpotBookingViewModel
	{

		public Guid Id { get; set; }

		[Required]
		[Display(Name = "Broadcast Date")]
		public DateTime BroadcastDate { get; set; }
		[Required]
		[Display(Name = "TimeBand Slice")]
		public Guid TimeBandSliceId { get; set; }
		public string TimeBandSliceName { get; set; }
		[Display(Name = "TimeBand")]
		public Guid TimeBandId { get; set; }
		[Display(Name = "TimeBand")]
		public string TimeBandName { get; set; }
		[Display(Name = "Description")]
		public string Description { get; set; }

		[Display(Name = "Annex Contract Asset")]
		public Guid AnnexContractAssetId { get; set; }
		[Display(Name = "Spot")]
		public Guid SpotId { get; set; }
		[Display(Name = "Position")]
		public int? Position { get; set; }
		//	public int? PositionApprove { get; set; }
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
		[Display(Name = "Total Value")]
		public decimal? TotalValue {
		get {
				return CardRateSet.GetValueOrDefault(0) + PositionRateSet.GetValueOrDefault(0) - DiscountRateSet.GetValueOrDefault(0);
			}
		}
		[Display(Name = "Calc Time")]
		public DateTime? CalcTime { get; set; }
		[Display(Name = "SpotBooking Request")]
		public Guid? SpotBookingRequestId { get; set; }


		[Display(Name = "Asset")]
		public Guid AssetId { get; set; }
		[Display(Name = "Asset Code")]
		public string AssetCode { get; set; }


		[Display(Name = "Approved OnAir")]
		public bool? ApprovedOnAir { get; set; }
	}
}
