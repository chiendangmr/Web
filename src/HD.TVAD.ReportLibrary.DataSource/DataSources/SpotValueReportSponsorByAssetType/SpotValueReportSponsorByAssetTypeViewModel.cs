using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotValueReportSponsorByAssetType
{
	public class SpotValueReportSponsorByAssetTypeViewModel
	{
		public Guid BookingId { get; set; }

		public string ChannelName { get; set; }
		public Guid SpotId { get; set; }

		public string SponsorProgramCode { get; set; }
		public string SponsorProgramName { get; set; }

		public string CustomerName { get; set; }

		public string AssetCode { get; set; }
		public int AssetDuration { get
			{
				return PanelDuration + IntroDuration + TVCDuration + FreeDuration;
			} }
		public decimal? Price
		{
			get
			{
				return TVCValue + IntoValue + PanelValue + FreeValue;
			}
		}

		public int TVCDuration { get; set; }

		public int IntroDuration { get; set; }

		public int PanelDuration { get; set; }

		public int FreeDuration { get; set; }

		public decimal TVCValue { get; set; }

		public decimal IntoValue { get; set; }

		public decimal PanelValue { get; set; }

		public decimal FreeValue { get; set; }
	}
}
