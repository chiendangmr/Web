using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.ValueReportForCustomerByProductGroup
{
	public class ValueReportForCustomerByProductGroupViewModel
	{
		public string CustomerName { get; set; }
		public string CustomerCode { get; set; }
		public string AssetCode { get; set; }
		public string ProductGroupName { get; set; }
		public string ProductName { get; set; }
		public string ProducerName { get; set; }
		public int AssetDuration { get; set; }

		public decimal? Price { get; set; }
		public decimal? DiscountValue { get; set; }
		public decimal? TotalValue { get; set; }
	}
}
