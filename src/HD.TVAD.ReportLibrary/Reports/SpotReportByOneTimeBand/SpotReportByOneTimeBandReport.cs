using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPivotGrid;

namespace HD.TVAD.ReportLibrary.SpotReportByOneTimeBand
{
	public partial class SpotReportByOneTimeBandReport : DevExpress.XtraReports.UI.XtraReport
	{
		public SpotReportByOneTimeBandReport()
		{
			InitializeComponent();
		}

		private void xrPivotGrid1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{

		}

		private void xrPivotGrid1_AfterPrint(object sender, EventArgs e)
		{
			var pivotGrid = (XRPivotGrid)sender;
			this.DataSource = null;
		}
		
		private void xrPivotGrid1_FieldValueDisplayText(object sender, DevExpress.XtraReports.UI.PivotGrid.PivotFieldDisplayTextEventArgs e)
		{
			if (e.ValueType == PivotGridValueType.GrandTotal) e.DisplayText = "Tổng cộng";
		//	if (e.ValueType == PivotGridValueType.Total) e.DisplayText = "Tổng cộng";
		}
	}
}
