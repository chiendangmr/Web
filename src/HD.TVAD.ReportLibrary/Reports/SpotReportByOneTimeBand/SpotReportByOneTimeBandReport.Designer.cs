namespace HD.TVAD.ReportLibrary.SpotReportByOneTimeBand
{
	partial class SpotReportByOneTimeBandReport
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
			this.xrPivotGrid1 = new DevExpress.XtraReports.UI.XRPivotGrid();
			this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
			this.fieldTimeBandSlice1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.fieldContractType1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.fieldAssetArea1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.fieldPrice1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
			this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
			this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
			this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			this.FromDate = new DevExpress.XtraReports.Parameters.Parameter();
			this.ToDate = new DevExpress.XtraReports.Parameters.Parameter();
			this.TimeBandName = new DevExpress.XtraReports.Parameters.Parameter();
			this.IsApprovedText = new DevExpress.XtraReports.Parameters.Parameter();
			((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPivotGrid1});
			this.Detail.HeightF = 87.91666F;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
			this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			// 
			// xrPivotGrid1
			// 
			this.xrPivotGrid1.Appearance.Cell.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.Appearance.CustomTotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.Appearance.FieldValueGrandTotal.BackColor = System.Drawing.Color.White;
			this.xrPivotGrid1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
			this.xrPivotGrid1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.Appearance.Lines.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.Appearance.TotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.DataSource = this.objectDataSource1;
			this.xrPivotGrid1.Fields.AddRange(new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField[] {
            this.fieldTimeBandSlice1,
            this.fieldContractType1,
            this.fieldAssetArea1,
            this.fieldPrice1});
			this.xrPivotGrid1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
			this.xrPivotGrid1.Name = "xrPivotGrid1";
			this.xrPivotGrid1.OLAPConnectionString = "";
			this.xrPivotGrid1.OptionsPrint.FilterSeparatorBarPadding = 3;
			this.xrPivotGrid1.OptionsView.ShowColumnHeaders = false;
			this.xrPivotGrid1.OptionsView.ShowColumnTotals = false;
			this.xrPivotGrid1.OptionsView.ShowDataHeaders = false;
			this.xrPivotGrid1.OptionsView.ShowFilterHeaders = false;
			this.xrPivotGrid1.OptionsView.ShowFilterSeparatorBar = false;
			this.xrPivotGrid1.OptionsView.ShowRowGrandTotalHeader = false;
			this.xrPivotGrid1.SizeF = new System.Drawing.SizeF(498.0002F, 87.91666F);
			this.xrPivotGrid1.FieldValueDisplayText += new System.EventHandler<DevExpress.XtraReports.UI.PivotGrid.PivotFieldDisplayTextEventArgs>(this.xrPivotGrid1_FieldValueDisplayText);
			this.xrPivotGrid1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrPivotGrid1_BeforePrint);
			this.xrPivotGrid1.AfterPrint += new System.EventHandler(this.xrPivotGrid1_AfterPrint);
			// 
			// objectDataSource1
			// 
			this.objectDataSource1.DataSource = typeof(HD.TVAD.ReportLibrary.SpotReportByOneTimeBand.SpotReportByOneTimeBandViewModel);
			this.objectDataSource1.Name = "objectDataSource1";
			// 
			// fieldTimeBandSlice1
			// 
			this.fieldTimeBandSlice1.Appearance.FieldHeader.BackColor = System.Drawing.Color.White;
			this.fieldTimeBandSlice1.Appearance.FieldHeader.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
			this.fieldTimeBandSlice1.Appearance.FieldValue.BackColor = System.Drawing.Color.White;
			this.fieldTimeBandSlice1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.fieldTimeBandSlice1.AreaIndex = 1;
			this.fieldTimeBandSlice1.Caption = "CUT";
			this.fieldTimeBandSlice1.FieldName = "TimeBandSlice";
			this.fieldTimeBandSlice1.Name = "fieldTimeBandSlice1";
			this.fieldTimeBandSlice1.Width = 60;
			// 
			// fieldContractType1
			// 
			this.fieldContractType1.Appearance.FieldHeader.BackColor = System.Drawing.Color.White;
			this.fieldContractType1.Appearance.FieldHeader.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
			this.fieldContractType1.Appearance.FieldValue.BackColor = System.Drawing.Color.White;
			this.fieldContractType1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.fieldContractType1.AreaIndex = 0;
			this.fieldContractType1.Caption = "LOẠI HỢP ĐỒNG";
			this.fieldContractType1.FieldName = "ContractType";
			this.fieldContractType1.Name = "fieldContractType1";
			this.fieldContractType1.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.None;
			this.fieldContractType1.Width = 300;
			// 
			// fieldAssetArea1
			// 
			this.fieldAssetArea1.AreaIndex = 0;
			this.fieldAssetArea1.Caption = "PHÂN LOẠI";
			this.fieldAssetArea1.FieldName = "AssetArea";
			this.fieldAssetArea1.Name = "fieldAssetArea1";
			this.fieldAssetArea1.Width = 200;
			// 
			// fieldPrice1
			// 
			this.fieldPrice1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.fieldPrice1.AreaIndex = 0;
			this.fieldPrice1.Caption = "GIÁ TRỊ";
			this.fieldPrice1.CellFormat.FormatString = "#,#";
			this.fieldPrice1.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.fieldPrice1.FieldName = "Price";
			this.fieldPrice1.Name = "fieldPrice1";
			// 
			// TopMargin
			// 
			this.TopMargin.HeightF = 46.875F;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
			this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			// 
			// BottomMargin
			// 
			this.BottomMargin.HeightF = 100F;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
			this.BottomMargin.StylePriority.UseTextAlignment = false;
			this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// PageHeader
			// 
			this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabel1});
			this.PageHeader.HeightF = 85.41666F;
			this.PageHeader.Name = "PageHeader";
			// 
			// xrLabel4
			// 
			this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Italic);
			this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 23F);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel4.SizeF = new System.Drawing.SizeF(998.0001F, 20F);
			this.xrLabel4.StylePriority.UseFont = false;
			this.xrLabel4.StylePriority.UseTextAlignment = false;
			this.xrLabel4.Text = "Từ  ngày [Parameters.FromDate!dd/MM/yyyy] đến ngày [Parameters.ToDate!dd/MM/yyyy]" +
    "";
			this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			// 
			// xrLabel1
			// 
			this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel1.SizeF = new System.Drawing.SizeF(998.0001F, 23F);
			this.xrLabel1.StylePriority.UseFont = false;
			this.xrLabel1.StylePriority.UseTextAlignment = false;
			this.xrLabel1.Text = "TỔNG HỢP GIÁ TRỊ PHÁT SÓNG THEO MÃ GIỜ [Parameters.TimeBandName] - [Parameters.Is" +
    "ApprovedText]";
			this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			// 
			// FromDate
			// 
			this.FromDate.Description = "FromDate";
			this.FromDate.Name = "FromDate";
			this.FromDate.Type = typeof(System.DateTime);
			this.FromDate.Visible = false;
			// 
			// ToDate
			// 
			this.ToDate.Description = "ToDate";
			this.ToDate.Name = "ToDate";
			this.ToDate.Type = typeof(System.DateTime);
			this.ToDate.Visible = false;
			// 
			// TimeBandName
			// 
			this.TimeBandName.Description = "TimeBandName";
			this.TimeBandName.Name = "TimeBandName";
			this.TimeBandName.Visible = false;
			// 
			// IsApprovedText
			// 
			this.IsApprovedText.Description = "IsApprovedText";
			this.IsApprovedText.Name = "IsApprovedText";
			this.IsApprovedText.Visible = false;
			// 
			// SpotReportByOneTimeBandReport
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader});
			this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1});
			this.DataSource = this.objectDataSource1;
			this.Landscape = true;
			this.Margins = new System.Drawing.Printing.Margins(50, 52, 47, 100);
			this.PageHeight = 827;
			this.PageWidth = 1169;
			this.PaperKind = System.Drawing.Printing.PaperKind.A4;
			this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.FromDate,
            this.ToDate,
            this.TimeBandName,
            this.IsApprovedText});
			this.Version = "17.1";
			((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}

		#endregion

		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
		private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
		private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
		private DevExpress.XtraReports.UI.XRPivotGrid xrPivotGrid1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldTimeBandSlice1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldContractType1;
		private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
		private DevExpress.XtraReports.UI.XRLabel xrLabel1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldAssetArea1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldPrice1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel4;
		public DevExpress.XtraReports.Parameters.Parameter FromDate;
		public DevExpress.XtraReports.Parameters.Parameter ToDate;
		public DevExpress.XtraReports.Parameters.Parameter TimeBandName;
		public DevExpress.XtraReports.Parameters.Parameter IsApprovedText;
	}
}
