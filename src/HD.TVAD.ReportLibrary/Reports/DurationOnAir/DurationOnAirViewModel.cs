using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.DurationOnAir
{
	public class DurationOnAirViewModel
	{
		public int Day { get; set; }
		public string ChannelName { get; set; }
		public decimal Price { get; set; }
		public decimal DiscountValue { get; set; }
		public decimal TotalValue { get {
				return Price - DiscountValue;
			} }
	}
}
