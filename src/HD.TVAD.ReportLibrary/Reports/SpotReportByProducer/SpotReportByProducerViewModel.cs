using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotReportByProducer
{
	public class SpotReportByProducerViewModel
	{
		public string ProducerName { get; set; }
		public string ContractCode { get; set; }
		public string ProductName { get; set; }
		public int Duration { get; set; }
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
