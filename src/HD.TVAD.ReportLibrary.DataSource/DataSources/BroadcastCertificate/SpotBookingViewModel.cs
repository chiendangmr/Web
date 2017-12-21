using System;
using System.Collections.Generic;
using System.Text;

namespace HD.TVAD.ReportLibrary.BroadcastCertificate
{
    public class SpotBookingViewModel
    {
		public int Year { get; set; }
		public int Month { get; set; }
		public int Day { get; set; }
		public string AssetCode { get; set; }
		public int AssetDuration { get; set; }
		public string ProductName { get; set; }
		public string AssetNote { get; set; }
		public string TimeBandName { get; set; }
		public string TimeBandSliceName { get; set; }
		public string Position { get; set; }
		public bool IsPositionChoose { get; set; }
	}
}
