using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.ValueReportForSponsorProgramByTimePeriod
{
	public class ValueReportForSponsorProgramByTimePeriodViewModel
	{
		public string SponsorProgramName { get; set; }
		public string TimeBandName { get; set; }
		public string TimeBandSliceName { get; set; }
		public decimal Price { get; set; }
		public decimal DiscountValue { get; set; }
		public decimal TotalValue { get {
				return Price - DiscountValue;
			} }

	}
}
