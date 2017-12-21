using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotReportByTrailer
{
	public class SpotReportByTrailerViewModel
	{
		public string SponsorProgramCode { get; set; }
		public string SponsorProgramName { get; set; }
		public string CustomerCode { get; set; }
		public string CustomerName { get; set; }
		public string ContractCode { get; set; }
		public int AssetDuration { get; set; }
		public decimal? Price { get; set; }
		public decimal? PositionCost { get; set; }
		public decimal? DiscountValue { get; set; }
		public decimal? TotalValue
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
