using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.Asset
{
	public class AssetViewModel
	{
		public string Code { get; set; }
		public string ProductName { get; set; }
		public int Duration { get; set; }
		public DateTime? ReceivedDate { get; set; }
		public string Register { get; set; }
		public string ProducerName { get; set; }
		public DateTime? ExpDate { get; set; }
		public string ApproveComment { get; set; }
		public DateTime? TempApproveDate { get; set; }
	}
}
