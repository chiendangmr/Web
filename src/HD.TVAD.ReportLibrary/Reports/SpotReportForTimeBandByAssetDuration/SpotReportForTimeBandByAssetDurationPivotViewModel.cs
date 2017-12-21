using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotReportForTimeBandByAssetDuration
{
	public class SpotReportForTimeBandByAssetDurationPivotViewModel
	{
		public DateTime BroadcastDate { get; set; }
		public string TimeBandName { get; set; }
		public string AssetDurationType { get; set; }
		public decimal Price { get; set; }
		public decimal DiscountValue { get; set; }
		public decimal Total { get {
				return Price - DiscountValue;
			} }
	}
}
