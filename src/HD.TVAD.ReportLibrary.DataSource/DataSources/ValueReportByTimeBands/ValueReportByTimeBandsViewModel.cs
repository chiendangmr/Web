using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.ValueReportByTimeBands
{
	public class ValueReportByTimeBandsViewModel
	{
		public string TimeBandName { get; set; }
		public string TimeBandTimeFrame { get; set; }
		public string SponsorProgramName { get; set; }
		public string BookingTypeName { get; set; }
		public decimal? Price { get; set; }
		public decimal? DiscountValue { get; set; }
		public decimal? TotalValue
		{
			get
			{
				return Price.GetValueOrDefault(0) - DiscountValue.GetValueOrDefault(0);
			}
		}
	}
}
