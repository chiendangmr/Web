using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace HD.TVAD.ReportLibrary.SpotReportForPermamentCustomer
{
	public partial class SpotReportForPermamentCustomerReport : DevExpress.XtraReports.UI.XtraReport
	{
		public SpotReportForPermamentCustomerReport()
		{
			InitializeComponent();
		}
		bool beginCustomerCode = true;
		private void xrTableCell18_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{

			var cellCur = sender as XRTableCell;

			if (!beginCustomerCode)
				cellCur.Lines = new string[] { "" };

			cellCur.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right
				| (beginCustomerCode ? DevExpress.XtraPrinting.BorderSide.Top : DevExpress.XtraPrinting.BorderSide.None);

			beginCustomerCode = false;
		}

		private void xrTableCell17_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{

			var cellCur = sender as XRTableCell;

			if (!beginCustomerCode)
				cellCur.Lines = new string[] { "" };

			cellCur.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right
				| (beginCustomerCode ? DevExpress.XtraPrinting.BorderSide.Top : DevExpress.XtraPrinting.BorderSide.None);

		//	beginCustomerCode = false;
		}

		private void GroupHeader2_AfterPrint(object sender, EventArgs e)
		{
			beginCustomerCode = true;
		}
	}
}
