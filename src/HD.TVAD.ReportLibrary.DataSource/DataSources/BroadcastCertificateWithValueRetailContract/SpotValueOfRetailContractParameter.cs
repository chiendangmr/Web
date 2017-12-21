using System;
using System.Collections.Generic;
using System.Text;

namespace HD.TVAD.ReportLibrary
{
    public class SpotValueOfRetailContractParameter
	{
		public Guid AnnexContractId { get; set; }
		public bool IsAllTime { get; set; }
		public DateTime FromDate { get; set; }
		public DateTime ToDate { get; set; }

	}
}
