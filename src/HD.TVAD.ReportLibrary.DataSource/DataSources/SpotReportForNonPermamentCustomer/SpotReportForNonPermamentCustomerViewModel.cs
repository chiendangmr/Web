using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotReportForNonPermamentCustomer
{
	public class SpotReportForNonPermamentCustomerViewModel
	{
		public int Index { get; set; }
		public string CustomerCode { get; set; }
		public string ContractCode { get; set; }
		public string CustomerName { get; set; }
		public int AssetDuration { get; set; }
		public decimal? Price { get; set; }
		public decimal? PositionCost { get; set; }
		public decimal? DiscountRate { get; set; }
		public decimal? DiscountValue { get; set; }
		public Decimal? TotalValue
		{
			get
			{
				return Price.GetValueOrDefault() + PositionCost.GetValueOrDefault() - DiscountValue.GetValueOrDefault();
			}
		}
	}
}
