using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.CheckSpotDuration
{
	public class CheckSpotDurationViewModel
	{
		public string TimeBandName { get; set; }
		public string TimeBandSliceName { get; set; }
		public string TimeBandSliceDescription { get; set; }
		public int Year { get; set; }
		public int Month { get; set; }
		public int Day { get; set; }
		public int? MaximumBookingDuration { get; set; }
		public int? UsedBookingDuration { get; set; }
		public int? LeftBookingDuration
		{
			get
			{
				return MaximumBookingDuration == null && UsedBookingDuration == null ? null : (int?)((MaximumBookingDuration == null ? 0 : (int)MaximumBookingDuration) - (UsedBookingDuration == null ? 0 : (int)UsedBookingDuration));
			}
		}

		public int? MaximumSponsorDuration { get; set; }
		public int? UsedSponsorDuration { get; set; }
		public int? LeftSponsorDuration
		{
			get
			{
				//		return MaximumSponsorDuration == null && LeftSponsorDuration == null ? null : (int?)((MaximumSponsorDuration == null ? 0 : (int)MaximumSponsorDuration) - (LeftSponsorDuration == null ? 0 : (int)LeftSponsorDuration));
				return 0;
			}
		}
	}
}