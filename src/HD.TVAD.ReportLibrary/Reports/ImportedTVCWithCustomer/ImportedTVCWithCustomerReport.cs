using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using HD.TVAD.ApplicationCore.Entities.Booking;

namespace HD.TVAD.ReportLibrary.ImportedTVCWithCustomer
{
	public partial class ImportedTVCWithCustomerReport : DevExpress.XtraReports.UI.XtraReport
	{
		public ImportedTVCWithCustomerReport()
		{
			InitializeComponent();
		}

		int TT = 0;
		private void xrTableRow5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			XRTableRow table = (XRTableRow)sender;

			XtraReport report = table.RootReport;
			var bookingType = (BookingTypeEnum)report.GetCurrentColumnValue("BookingTypeId");
			//	var sponsorType = (SponsorTypeEnum)report.GetCurrentColumnValue("SponsorTypeId");
			if (bookingType == BookingTypeEnum.Contract_Sponsor_InProgram)
				table.ForeColor = Color.Red;
			else if (bookingType == BookingTypeEnum.Contract_Sponsor_OutProgram)
				table.ForeColor = Color.Blue;
			else table.ForeColor = Color.Black;
		}

		private void xrTableCell3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			XRTableCell cell = (XRTableCell)sender;
			cell.Lines = new string[] { (++TT).ToString() };
		}

		private void grpHLatCat_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			TT = 0;
		}

		private void xrTableRow1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			XRTableRow rGio = (XRTableRow)sender;
			XtraReport report = rGio.RootReport;

			rGio.Visible = true;

			object lastPage = report.GetPreviousColumnValue("Page");
			object currentPage = report.GetCurrentColumnValue("Page");

			object lastMaGio = report.GetPreviousColumnValue("TimeBandName");
			object currentMaGio = report.GetCurrentColumnValue("TimeBandName");

			bool isfirst = report.CurrentRowIndex == 0;
			if (!isfirst)
				if (lastPage.ToString() == currentPage.ToString() && lastMaGio.ToString() == currentMaGio.ToString())
					rGio.Visible = false;
		}
	}
}
