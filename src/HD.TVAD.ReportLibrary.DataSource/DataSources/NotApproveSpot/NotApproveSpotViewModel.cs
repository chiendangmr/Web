using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.NotApproveSpot
{
    public class NotApproveSpotViewModel
    {
		public string ContractCode { get; set; }
		public string AssetCode { get; set; }
		public int AssetDuration { get; set; }
		public string ProductName { get; set; }
		public Guid SpotBookingId { get; set; }
		public DateTime BroadcastDate { get; set; }
		public string TimeBandName { get; set; }
		public string TimeBandSliceName { get; set; }
		public int? Position { get; set; }
		public string ApproveComment { get; set; }
		public bool IsRetail { get; set; }
	}
}
