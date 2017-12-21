using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.CheckDurationAndValueSpot
{
	public class CheckDurationAndValueSpotViewModel
	{
		public Guid TimeBandId { get; set; }
		public string TimeBandName { get; set; }
		public string TimeBandSliceName { get; set; }
		public string TimeBandSliceDescription { get; set; }
		public DateTime BroadcastDate { get; set; }
		public int Year
		{
			get
			{
				return BroadcastDate.Year;
			}
		}
		public int Month
		{
			get
			{
				return BroadcastDate.Month;
			}
		}
		public int Day
		{
			get;
			//{
			//	return BroadcastDate.Day;
			//}
			set;
		}
		public decimal? BookingValue { get; set; }
		public decimal? SponsorValue { get; set; }
		public decimal? TotalValue
		{
			get
			{
				if (BookingValue == null && SponsorValue == null)
					return null;

				decimal sum = BookingValue == null ? 0 : (decimal)BookingValue;
				if (SponsorValue != null)
					sum += (decimal)SponsorValue;

				return sum;
			}
		}
	}
}
