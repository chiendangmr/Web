using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace HD.TVAD.ReportLibrary.SpotReportForTimeBandByAssetDuration
{
	public partial class SpotReportForTimeBandByAssetDurationReport : DevExpress.XtraReports.UI.XtraReport
	{
		public SpotReportForTimeBandByAssetDurationReport()
		{
			InitializeComponent();
		}

		private void Detail_AfterPrint(object sender, EventArgs e)
		{
			DataSource = null;
		}
	}
}
