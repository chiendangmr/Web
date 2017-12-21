using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.BroadcastCertificateWithValueRetailContract
{
	public class SpotValueOfRetailContractViewModel
	{
		public string AssetCode { get; set; }
		public string TimeBandName { get; set; }
		public int Duration { get; set; }
		public decimal Price { get; set; }
		public decimal TotalValue { get; set; }
	}
}
