using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotReportForTimeBandByAssetDuration
{
	public class SpotReportForTimeBandByAssetDurationViewModel
	{
		public DateTime BroadcastDate { get; set; }
		public string TimeBandName { get; set; }
		public decimal _5s { get; set; }
		public decimal _10s { get; set; }
		public decimal _15s { get; set; }
		public decimal _20s { get; set; }
		public decimal _30s { get; set; }
		public decimal _45s { get; set; }
		public decimal _60s { get; set; }
		public decimal _75s { get; set; }
		public decimal _90s { get; set; }
		public decimal _120s { get; set; }
		public decimal Intro { get; set; }
		public decimal Total { get; set; }
	}
}
