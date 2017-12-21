using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotReportByContractContentOrProduct
{
	public class SpotReportByContractContentOrProductViewModel
	{
		public string CustomerCode { get; set; }
		public string CustomerName { get; set; }
		public string ContractContentAndProductName { get; set; }
		public int AssetDuration { get; set; }
		public decimal? Price { get; set; }
		public decimal? PositionCost { get; set; }
		public decimal? DiscountValue { get; set; }
		public decimal? TotalValue
		{
			get
			{
				if (Price == null && PositionCost == null)
					return null;

				decimal result = Price == null ? 0 : (decimal)Price;
				if (PositionCost != null)
					result += (decimal)PositionCost;
				if (DiscountValue != null)
					result -= (decimal)DiscountValue;
				return result;
			}
		}
	}
}
