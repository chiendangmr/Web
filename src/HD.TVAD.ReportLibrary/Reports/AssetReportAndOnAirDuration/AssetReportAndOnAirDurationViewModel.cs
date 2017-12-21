using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.AssetReportAndOnAirDuration
{
	public class AssetReportAndOnAirDurationViewModel
	{
		public string TimeBandName { get; set; }
		public int Duration { get; set; }
		public int FreeDuration { get; set; }
		public int TotalDuration { get; set; }
		public int InMonthDuration { get; set; }
		public int FreeInMonthDuration { get; set; }
		public int TotalInMonthDuration { get; set; }
	}
}
