using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotReportForTimeBandByCustomer
{
	public class SpotReportForTimeBandByCustomerViewModel
	{
		public string TimeBandName { get; set; }
		public string CustomerCode { get; set; }
		public string CustomerName { get; set; }
		public int AssetDuration { get; set; }
		public decimal Price { get; set; }
		public decimal DiscountValue { get; set; }
		public decimal TotalValue { get {
				return Price - DiscountValue;
			} }
	}
}
