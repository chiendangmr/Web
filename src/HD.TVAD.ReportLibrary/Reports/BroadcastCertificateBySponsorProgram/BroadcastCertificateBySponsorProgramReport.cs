using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using HD.TVAD.ReportLibrary.Reports.SubDetail;

namespace HD.TVAD.ReportLibrary.BroadcastCertificateBySponsorProgram
{
	public partial class BroadcastCertificateBySponsorProgramReport : DevExpress.XtraReports.UI.XtraReport
	{
		public BroadcastCertificateBySponsorProgramReport()
		{
			InitializeComponent();
		}

		private void BroadcastCertificateWithValueManyContractReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			//var yCur = 0;
			//for (int i = 0; i < 3; i++)
			//{

			//	var subReport = new XRSubreport();
			//	subReport.LocationF = new System.Drawing.PointF(0, yCur);
			//	subReport.SizeF = new System.Drawing.SizeF(this.PageWidth - this.Margins.Left - this.Margins.Right, 48.0F);

			//	subReport.ReportSource = new AnnexContractDetailReport();
				
			//	this.Bands[BandKind.Detail].Controls.Add(subReport);

			//	yCur += 48;
			//}
		}
	}
}
