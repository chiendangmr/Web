namespace HD.TVAD.ReportLibrary.DurationOnAir
{
	partial class DurationOnAirReport
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
			this.fieldDay1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.fieldChannelName1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.fieldPrice1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.fieldDiscountValue1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.fieldTotalValue1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
			this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
			this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
			this.Month = new DevExpress.XtraReports.Parameters.Parameter();
			this.Year = new DevExpress.XtraReports.Parameters.Parameter();
			this.IsApprovedText = new DevExpress.XtraReports.Parameters.Parameter();
			((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPivotGrid1});
			this.Detail.HeightF = 100F;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
			this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			this.Detail.AfterPrint += new System.EventHandler(this.Detail_AfterPrint);
			// 
			// xrPivotGrid1
			// 
			this.xrPivotGrid1.Appearance.Cell.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.Appearance.CustomTotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.Appearance.FieldValueGrandTotal.BackColor = System.Drawing.Color.White;
			this.xrPivotGrid1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.xrPivotGrid1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.Appearance.Lines.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.Appearance.TotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.Fields.AddRange(new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField[] {
            this.fieldDay1,
            this.fieldChannelName1,
            this.fieldPrice1,
            this.fieldDiscountValue1,
            this.fieldTotalValue1});
			this.xrPivotGrid1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
			this.xrPivotGrid1.Name = "xrPivotGrid1";
			this.xrPivotGrid1.OptionsPrint.FilterSeparatorBarPadding = 3;
			this.xrPivotGrid1.OptionsView.ShowColumnHeaders = false;
			this.xrPivotGrid1.OptionsView.ShowDataHeaders = false;
			this.xrPivotGrid1.OptionsView.ShowFilterHeaders = false;
			this.xrPivotGrid1.SizeF = new System.Drawing.SizeF(462.9167F, 97.91666F);
			this.xrPivotGrid1.FieldValueDisplayText += new System.EventHandler<DevExpress.XtraReports.UI.PivotGrid.PivotFieldDisplayTextEventArgs>(this.xrPivotGrid1_FieldValueDisplayText);
			// 
			// fieldDay1
			// 
			this.fieldDay1.Appearance.FieldHeader.BackColor = System.Drawing.Color.White;
			this.fieldDay1.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.fieldDay1.Appearance.FieldValue.BackColor = System.Drawing.Color.White;
			this.fieldDay1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.fieldDay1.AreaIndex = 0;
			this.fieldDay1.Caption = "Ngày PS";
			this.fieldDay1.FieldName = "Day";
			this.fieldDay1.Name = "fieldDay1";
			this.fieldDay1.Width = 60;
			// 
			// fieldChannelName1
			// 
			this.fieldChannelName1.Appearance.FieldValue.BackColor = System.Drawing.Color.White;
			this.fieldChannelName1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.fieldChannelName1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
			this.fieldChannelName1.AreaIndex = 0;
			this.fieldChannelName1.Caption = "Kênh";
			this.fieldChannelName1.FieldName = "ChannelName";
			this.fieldChannelName1.Name = "fieldChannelName1";
			// 
			// fieldPrice1
			// 
			this.fieldPrice1.AreaIndex = 0;
			this.fieldPrice1.FieldName = "Price";
			this.fieldPrice1.Name = "fieldPrice1";
			// 
			// fieldDiscountValue1
			// 
			this.fieldDiscountValue1.AreaIndex = 1;
			this.fieldDiscountValue1.FieldName = "DiscountValue";
			this.fieldDiscountValue1.Name = "fieldDiscountValue1";
			// 
			// fieldTotalValue1
			// 
			this.fieldTotalValue1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.fieldTotalValue1.AreaIndex = 0;
			this.fieldTotalValue1.CellFormat.FormatString = "{0:N1}";
			this.fieldTotalValue1.FieldName = "TotalValue";
			this.fieldTotalValue1.Name = "fieldTotalValue1";
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
			this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			// 
			// ReportHeader
			// 
			this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1});
			this.ReportHeader.HeightF = 51.04167F;
			this.ReportHeader.Name = "ReportHeader";
			// 
			// xrLabel1
			// 
			this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
			this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0.9580612F, 0F);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel1.SizeF = new System.Drawing.SizeF(1101.042F, 19.79167F);
			this.xrLabel1.StylePriority.UseFont = false;
			this.xrLabel1.StylePriority.UseTextAlignment = false;
			this.xrLabel1.Text = "THỐNG KÊ THỜI LƯỢNG PHÁT SÓNG THÁNG [Parameters.Month] NĂM [Parameters.Year] -  [" +
    "Parameters.IsApprovedText] ";
			this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			// 
			// objectDataSource1
			// 
			this.objectDataSource1.DataSource = typeof(HD.TVAD.ReportLibrary.DurationOnAir.DurationOnAirViewModel);
			this.objectDataSource1.Name = "objectDataSource1";
			// 
			// Month
			// 
			this.Month.Description = "Month";
			this.Month.Name = "Month";
			this.Month.Type = typeof(int);
			this.Month.ValueInfo = "0";
			this.Month.Visible = false;
			// 
			// Year
			// 
			this.Year.Description = "Year";
			this.Year.Name = "Year";
			this.Year.Type = typeof(int);
			this.Year.ValueInfo = "0";
			this.Year.Visible = false;
			// 
			// IsApprovedText
			// 
			this.IsApprovedText.Description = "IsApprovedText";
			this.IsApprovedText.Name = "IsApprovedText";
			this.IsApprovedText.Visible = false;
			// 
			// DurationOnAirReport
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
			this.Margins = new System.Drawing.Printing.Margins(36, 31, 47, 100);
			this.PageHeight = 827;
			this.PageWidth = 1169;
			this.PaperKind = System.Drawing.Printing.PaperKind.A4;
			this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.Month,
            this.Year,
            this.IsApprovedText});
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
		private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
		private DevExpress.XtraReports.UI.XRPivotGrid xrPivotGrid1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldDay1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldChannelName1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldPrice1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldDiscountValue1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldTotalValue1;
		public DevExpress.XtraReports.Parameters.Parameter Month;
		public DevExpress.XtraReports.Parameters.Parameter Year;
		public DevExpress.XtraReports.Parameters.Parameter IsApprovedText;
	}
}
