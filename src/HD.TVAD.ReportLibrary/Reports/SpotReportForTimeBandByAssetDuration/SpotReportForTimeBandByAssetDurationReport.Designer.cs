namespace HD.TVAD.ReportLibrary.SpotReportForTimeBandByAssetDuration
{
	partial class SpotReportForTimeBandByAssetDurationReport
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.Detail = new DevExpress.XtraReports.UI.DetailBand();
			this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
			this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
			this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrPivotGrid1 = new DevExpress.XtraReports.UI.XRPivotGrid();
			this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
			this.fieldBroadcastDate1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.field5s1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.field10s1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.field15s1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.field20s1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.field30s1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.field45s1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.field60s1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.field75s1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.field90s1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.field120s1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.fieldIntro1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.fieldTotal1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPivotGrid1});
			this.Detail.HeightF = 166.6667F;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
			this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
			// 
			// TopMargin
			// 
			this.TopMargin.HeightF = 47.91667F;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
			this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			// 
			// BottomMargin
			// 
			this.BottomMargin.HeightF = 100F;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
			this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			// 
			// ReportHeader
			// 
			this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLabel2});
			this.ReportHeader.HeightF = 91.66666F;
			this.ReportHeader.Name = "ReportHeader";
			// 
			// xrLabel1
			// 
			this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
			this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel1.SizeF = new System.Drawing.SizeF(1114F, 25F);
			this.xrLabel1.StylePriority.UseFont = false;
			this.xrLabel1.StylePriority.UseTextAlignment = false;
			this.xrLabel1.Text = "TỔNG HỢP GIÁ TRỊ (THỜI LƯỢNG) MÃ GIỜ  ... THEO THỜI LƯỢNG BĂNG";
			this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			// 
			// xrLabel2
			// 
			this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic);
			this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 29.16667F);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel2.SizeF = new System.Drawing.SizeF(1090F, 26.04167F);
			this.xrLabel2.StylePriority.UseFont = false;
			this.xrLabel2.StylePriority.UseTextAlignment = false;
			this.xrLabel2.Text = "Thời gian: Từ...đến....";
			this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			// 
			// xrPivotGrid1
			// 
			this.xrPivotGrid1.Appearance.Cell.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.Appearance.CustomTotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.Appearance.Lines.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.Appearance.TotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.DataSource = this.objectDataSource1;
			this.xrPivotGrid1.Fields.AddRange(new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField[] {
            this.fieldBroadcastDate1,
            this.field5s1,
            this.field10s1,
            this.field15s1,
            this.field20s1,
            this.field30s1,
            this.field45s1,
            this.field60s1,
            this.field75s1,
            this.field90s1,
            this.field120s1,
            this.fieldIntro1,
            this.fieldTotal1});
			this.xrPivotGrid1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
			this.xrPivotGrid1.Name = "xrPivotGrid1";
			this.xrPivotGrid1.OptionsPrint.FilterSeparatorBarPadding = 3;
			this.xrPivotGrid1.OptionsView.ShowDataHeaders = false;
			this.xrPivotGrid1.OptionsView.ShowFilterHeaders = false;
			this.xrPivotGrid1.SizeF = new System.Drawing.SizeF(558.75F, 156.6667F);
			// 
			// objectDataSource1
			// 
			this.objectDataSource1.DataSource = typeof(HD.TVAD.ReportLibrary.SpotReportForTimeBandByAssetDuration.SpotReportForTimeBandByAssetDurationViewModel);
			this.objectDataSource1.Name = "objectDataSource1";
			// 
			// fieldBroadcastDate1
			// 
			this.fieldBroadcastDate1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.fieldBroadcastDate1.AreaIndex = 0;
			this.fieldBroadcastDate1.FieldName = "BroadcastDate";
			this.fieldBroadcastDate1.Name = "fieldBroadcastDate1";
			// 
			// field5s1
			// 
			this.field5s1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.field5s1.AreaIndex = 0;
			this.field5s1.FieldName = "_5s";
			this.field5s1.Name = "field5s1";
			this.field5s1.Width = 60;
			// 
			// field10s1
			// 
			this.field10s1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.field10s1.AreaIndex = 1;
			this.field10s1.FieldName = "_10s";
			this.field10s1.Name = "field10s1";
			this.field10s1.Width = 60;
			// 
			// field15s1
			// 
			this.field15s1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.field15s1.AreaIndex = 2;
			this.field15s1.FieldName = "_15s";
			this.field15s1.Name = "field15s1";
			this.field15s1.Width = 60;
			// 
			// field20s1
			// 
			this.field20s1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.field20s1.AreaIndex = 3;
			this.field20s1.FieldName = "_20s";
			this.field20s1.Name = "field20s1";
			this.field20s1.Width = 60;
			// 
			// field30s1
			// 
			this.field30s1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.field30s1.AreaIndex = 4;
			this.field30s1.FieldName = "_30s";
			this.field30s1.Name = "field30s1";
			this.field30s1.Width = 60;
			// 
			// field45s1
			// 
			this.field45s1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.field45s1.AreaIndex = 5;
			this.field45s1.FieldName = "_45s";
			this.field45s1.Name = "field45s1";
			this.field45s1.Width = 60;
			// 
			// field60s1
			// 
			this.field60s1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.field60s1.AreaIndex = 6;
			this.field60s1.FieldName = "_60s";
			this.field60s1.Name = "field60s1";
			this.field60s1.Width = 60;
			// 
			// field75s1
			// 
			this.field75s1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.field75s1.AreaIndex = 7;
			this.field75s1.FieldName = "_75s";
			this.field75s1.Name = "field75s1";
			this.field75s1.Width = 60;
			// 
			// field90s1
			// 
			this.field90s1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.field90s1.AreaIndex = 8;
			this.field90s1.FieldName = "_90s";
			this.field90s1.Name = "field90s1";
			this.field90s1.Width = 60;
			// 
			// field120s1
			// 
			this.field120s1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.field120s1.AreaIndex = 9;
			this.field120s1.FieldName = "_120s";
			this.field120s1.Name = "field120s1";
			this.field120s1.Width = 60;
			// 
			// fieldIntro1
			// 
			this.fieldIntro1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.fieldIntro1.AreaIndex = 10;
			this.fieldIntro1.FieldName = "Intro";
			this.fieldIntro1.Name = "fieldIntro1";
			this.fieldIntro1.Width = 60;
			// 
			// fieldTotal1
			// 
			this.fieldTotal1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.fieldTotal1.AreaIndex = 11;
			this.fieldTotal1.FieldName = "Total";
			this.fieldTotal1.Name = "fieldTotal1";
			this.fieldTotal1.Width = 60;
			// 
			// SpotReportForTimeBandByAssetDurationReport
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader});
			this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1});
			this.DataSource = this.objectDataSource1;
			this.Landscape = true;
			this.Margins = new System.Drawing.Printing.Margins(30, 25, 48, 100);
			this.PageHeight = 827;
			this.PageWidth = 1169;
			this.PaperKind = System.Drawing.Printing.PaperKind.A4;
			this.Version = "17.1";
			((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}

		#endregion

		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
		private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
		private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
		private DevExpress.XtraReports.UI.XRLabel xrLabel1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel2;
		private DevExpress.XtraReports.UI.XRPivotGrid xrPivotGrid1;
		private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldBroadcastDate1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field5s1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field10s1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field15s1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field20s1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field30s1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field45s1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field60s1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field75s1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field90s1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField field120s1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldIntro1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldTotal1;
	}
}
