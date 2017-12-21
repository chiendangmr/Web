using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPivotGrid;

namespace HD.TVAD.ReportLibrary.ValueReportByChannel
{
	public partial class ValueReportByChannelReport : DevExpress.XtraReports.UI.XtraReport
	{
		public ValueReportByChannelReport()
		{
			InitializeComponent();
		}

		private void Detail_AfterPrint(object sender, EventArgs e)
		{
			DataSource = null;
		}

		private void xrPivotGrid1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{

		}

		private void xrPivotGrid1_FieldValueDisplayText(object sender, DevExpress.XtraReports.UI.PivotGrid.PivotFieldDisplayTextEventArgs e)
		{
			if (e.ValueType == PivotGridValueType.GrandTotal) e.DisplayText = "Tổng cộng";
		}
	}
}
