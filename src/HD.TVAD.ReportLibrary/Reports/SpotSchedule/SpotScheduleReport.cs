using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.ObjectBinding;
using System.Collections.Generic;
using HD.TVAD.ReportLibrary.Reports;
using HD.TVAD.ReportLibrary;

namespace HD.TVAD.ReportLibrary.SpotSchedule
{
	public partial class SpotScheduleReport : DevExpress.XtraReports.UI.XtraReport
	{
		public SpotScheduleReport()
		{
			InitializeComponent();
		}

		private void SpotScheduleReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			var report = (XtraReport)sender;

			var bmp = Util.MakeWatermark();

			report.Watermark.Image = bmp;
			report.Watermark.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			report.Watermark.ImageViewMode = DevExpress.XtraPrinting.Drawing.ImageViewMode.Clip;
		}

		int TT = 0;
		private void GroupTimeBandSlice_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			TT = 0;
		}

		private void xrTableCell3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			XRTableCell cell = (XRTableCell)sender;
			cell.Lines = new string[] { (++TT).ToString() };
		}

		private void xrTableRow2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			XRTableRow rGio = (XRTableRow)sender;
			XtraReport report = rGio.RootReport;

			rGio.Visible = true;

			object lastPage = report.GetPreviousColumnValue("Page");
			object currentPage = report.GetCurrentColumnValue("Page");

			object lastNotePage = report.GetPreviousColumnValue("NotePage");

			object lastMaGio = report.GetPreviousColumnValue("TimeBandName");
			object currentMaGio = report.GetCurrentColumnValue("TimeBandName");

			object lastGhiChuGio = report.GetPreviousColumnValue("TimeBandDescription");
			object currentGhiChuGio = report.GetCurrentColumnValue("TimeBandDescription");

			object currentLatCat = report.GetCurrentColumnValue("TimeBandSlice");

			bool isfirst = report.CurrentRowIndex == 0;
			if (!isfirst)
				if (lastPage.ToString() == currentPage.ToString() && lastMaGio.ToString() == currentMaGio.ToString() &&
					(lastGhiChuGio.ToString() == currentGhiChuGio.ToString() || lastNotePage.ToString() == currentGhiChuGio.ToString()))
					rGio.Visible = false;
		}
	}
}
