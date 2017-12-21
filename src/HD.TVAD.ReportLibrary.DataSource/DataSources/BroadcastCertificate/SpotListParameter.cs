using System;
using System.Collections.Generic;
using System.Text;

namespace HD.TVAD.ReportLibrary
{
    public class SpotListParameter
    {
		public Guid AnnexContractId { get; set; }
		public Guid AnnexContractAssetId { get; set; }
		public bool IsAllTime { get; set; }
		public bool IsApproved { get; set; }
		public DateTime FromDate { get; set; }
		public DateTime ToDate { get; set; }

		public bool IsShowPosition { get; set; }

	}
}
