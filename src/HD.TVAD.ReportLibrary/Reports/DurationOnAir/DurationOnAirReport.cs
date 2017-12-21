using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace HD.TVAD.ReportLibrary.DurationOnAir
{
	public partial class DurationOnAirReport : DevExpress.XtraReports.UI.XtraReport
	{
		public DurationOnAirReport()
		{
			InitializeComponent();
		}

		private void Detail_AfterPrint(object sender, EventArgs e)
		{
			DataSource = null;
		}

		private void xrPivotGrid1_FieldValueDisplayText(object sender, DevExpress.XtraReports.UI.PivotGrid.PivotFieldDisplayTextEventArgs e)
		{
			if (e.ValueType == DevExpress.XtraPivotGrid.PivotGridValueType.GrandTotal)
			{
				e.DisplayText = "Tổng cộng";
			}
		}
	}
}
