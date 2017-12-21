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
		public Decimal Price { get; set; }
		public Decimal PositionCost { get; set; }
		public Decimal DiscountValue { get; set; }
		public Decimal TotalValue { get; set; }
	}
}
