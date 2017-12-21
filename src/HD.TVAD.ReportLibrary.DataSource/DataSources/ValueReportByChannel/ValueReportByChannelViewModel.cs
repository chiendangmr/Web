using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.ValueReportByChannel
{
	public class ValueReportByChannelViewModel
	{
		public string BookingTypeName { get; set; }
		public string ChannelName { get; set; }
		public decimal? Price { get; set; }
		public decimal? DiscountValue { get; set; }
		public decimal? TotalValue { get {
				return Price.GetValueOrDefault(0) - DiscountValue.GetValueOrDefault(0);
			} }
	}
}
