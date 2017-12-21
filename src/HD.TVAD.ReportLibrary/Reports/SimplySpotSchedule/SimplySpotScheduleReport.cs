using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.ObjectBinding;
using System.Collections.Generic;
using HD.TVAD.ReportLibrary.Reports;

namespace HD.TVAD.ReportLibrary.SimplySpotSchedule
{
	public partial class SimplySpotScheduleReport : DevExpress.XtraReports.UI.XtraReport
	{
		public SimplySpotScheduleReport()
		{
			InitializeComponent();
		}
		

		private void SimplySpotScheduleReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			var report = (XtraReport)sender;

			var bmp = Util.MakeWatermarkForSimplySpotSchedule();

			report.Watermark.Image = bmp;
			report.Watermark.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			report.Watermark.ImageViewMode = DevExpress.XtraPrinting.Drawing.ImageViewMode.Clip;
		}
	}
}
