using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace HD.TVAD.ReportLibrary.ValueReportForCustomerByProductGroup
{
	public partial class ValueReportForCustomerByProductGroupReport : DevExpress.XtraReports.UI.XtraReport
	{
		public ValueReportForCustomerByProductGroupReport()
		{
			InitializeComponent();
		}

		bool beginCustomerCode = true;

		bool beginProductGroupName = true;

		private void xrTableCell1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{

			var cellCur = sender as XRTableCell;

			if (!beginCustomerCode)
				cellCur.Lines = new string[] { "" };

			cellCur.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right
				| (beginCustomerCode ? DevExpress.XtraPrinting.BorderSide.Top : DevExpress.XtraPrinting.BorderSide.None);
			beginCustomerCode = false;

		}

		private void xrTableCell2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			var cellCur = sender as XRTableCell;

			if (!beginProductGroupName)
				cellCur.Lines = new string[] { "" };

			cellCur.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right
				| (beginProductGroupName ? DevExpress.XtraPrinting.BorderSide.Top : DevExpress.XtraPrinting.BorderSide.None);

			beginProductGroupName = false;
		}

		private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{

		}

		private void GroupHeader3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			beginCustomerCode = true;

		}

		private void GroupHeader2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			beginProductGroupName = true;
		}
	}
}
