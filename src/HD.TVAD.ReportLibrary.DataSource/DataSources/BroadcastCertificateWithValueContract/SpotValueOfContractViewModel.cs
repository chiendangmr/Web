using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.BroadcastCertificateWithValueContract
{
	public class SpotValueOfContractViewModel
	{
		public int Group { get; set; }
		public string AssetCode { get; set; }
		public string TimeBandName { get; set; }
		public decimal RateCard { get; set; }
		public int SpotBlockDuration { get; set; }
		public int Duration { get; set; }
		public decimal? Price { get; set; }
		public decimal? PositionCost { get; set; }
		public decimal? DiscountRate { get; set; }
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
