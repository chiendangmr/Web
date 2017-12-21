using System;
using System.Collections.Generic;
using System.Text;

namespace HD.TVAD.ReportLibrary
{
    public class SpotValueOfContractParameter
	{
		public Guid AnnexContractId { get; set; }
		public Guid AnnexContractAssetId { get; set; }
		public bool IsAllTime { get; set; }
		public DateTime FromDate { get; set; }
		public DateTime ToDate { get; set; }

	}
}
