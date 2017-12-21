using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.ValueReportForCustomerByChannel
{
	public class ValueReportForCustomerByChannelViewModel
	{
		public string ProductName {get; set; }
		public string ChannelName { get; set; }
		public Decimal? Price { get; set; }
		public Decimal? DiscountRate { get; set; }
		public Decimal? PositionCost { get; set; }
		public Decimal? DiscountValue { get; set; }
		public Decimal? TotalValue
		{
			get
			{
				return Price.GetValueOrDefault(0)
					+ PositionCost.GetValueOrDefault(0)
					- DiscountValue.GetValueOrDefault(0);
			}
		}
	}
}
