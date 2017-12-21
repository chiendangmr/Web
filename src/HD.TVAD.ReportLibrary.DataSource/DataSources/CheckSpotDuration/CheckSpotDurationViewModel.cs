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
				return MaximumBookingDuration.GetValueOrDefault() - UsedBookingDuration.GetValueOrDefault();
			}
		}

		public int? MaximumSponsorDuration { get; set; }
		public int? UsedSponsorDuration { get; set; }
		public int? LeftSponsorDuration
		{
			get
			{
				return MaximumSponsorDuration.GetValueOrDefault() - UsedSponsorDuration.GetValueOrDefault();
			//	return 0;
			}
		}
	}
}