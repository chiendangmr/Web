using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotReportBySocialProgram
{
	public class SpotReportBySocialProgramViewModel
	{

		public DateTime BroadcastDate { get; set; }
		public string TimeBandName { get; set; }
		public int AssetDuration { get; set; }
		public int IntroDuration { get; set; }
		public int FreePanelDuration { get; set; }
		public int TotalDurationWithOutIntroAndPanel => AssetDuration - IntroDuration - FreePanelDuration;
		public string SponsorProgramName { get; set; }

		/// <summary>
		/// Thời lượng đối tác XHH bán (giây) - SP Tài trợ
		/// </summary>
		public int SoldSponsorDuration { get; set; }
		/// <summary>
		/// Thời lượng đối tác XHH bán (giây) - SP Khac
		/// </summary>
		public int SoldOtherDuration { get; set; }
		public int TotalSoldDuration => SoldOtherDuration + SoldSponsorDuration;


		public int TotalVTVSoldDuration => TotalDurationWithOutIntroAndPanel - TotalSoldDuration;
	}
}
