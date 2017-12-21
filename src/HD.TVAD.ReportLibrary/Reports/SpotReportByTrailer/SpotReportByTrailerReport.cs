using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace HD.TVAD.ReportLibrary.SpotReportByTrailer
{
	public partial class SpotReportByTrailerReport : DevExpress.XtraReports.UI.XtraReport
	{
		public SpotReportByTrailerReport()
		{
			InitializeComponent();
		}

		private bool haveKhachHang = false;
		string currentKhachHang = "";

		private void GroupHeader2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			XtraReport report = this;
			haveKhachHang = false;
			object khachHangCur = report.GetCurrentColumnValue("CustomerName");
			if (khachHangCur == null)
				currentKhachHang = "";
			else
				currentKhachHang = khachHangCur.ToString();
		}

		private void cellKhachHang_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			XRTableCell cell = (XRTableCell)sender;
			if (haveKhachHang)
			{
				cell.Lines = new string[] { "" };
			}
			else
			{
				cell.Lines = new string[] { currentKhachHang };
				haveKhachHang = true;
			}
		}
	}
}
