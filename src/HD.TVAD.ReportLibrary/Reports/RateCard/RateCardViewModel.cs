using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.RateCard
{
	public class RateCardViewModel
	{
		public string ChannelName { get; set; }
		public string TimeBandName { get; set; }
		public int SpotBlockDuration { get; set; }
		public DateTime StartDate { get; set; }
		public decimal Price { get; set; }
	}
}
