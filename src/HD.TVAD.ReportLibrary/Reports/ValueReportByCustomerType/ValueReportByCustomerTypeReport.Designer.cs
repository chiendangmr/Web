namespace HD.TVAD.ReportLibrary.ValueReportByCustomerType
{
	partial class ValueReportByCustomerTypeReport
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
			this.fieldCustomerName1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.fieldCustomerCode1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.fieldTimeBandName1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.fieldBookingTypeName1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.fieldPrice1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.fieldDiscountValue1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.fieldTotalValue1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
			this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
			this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
			this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
			this.FromDate = new DevExpress.XtraReports.Parameters.Parameter();
			this.ToDate = new DevExpress.XtraReports.Parameters.Parameter();
			this.CustomerType = new DevExpress.XtraReports.Parameters.Parameter();
			this.AssetDuration = new DevExpress.XtraReports.Parameters.Parameter();
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
            this.fieldCustomerName1,
            this.fieldCustomerCode1,
            this.fieldTimeBandName1,
            this.fieldBookingTypeName1,
            this.fieldPrice1,
            this.fieldDiscountValue1,
            this.fieldTotalValue1});
			this.xrPivotGrid1.LocationFloat = new DevExpress.Utils.PointFloat(0.4166603F, 1.041667F);
			this.xrPivotGrid1.Name = "xrPivotGrid1";
			this.xrPivotGrid1.OptionsPrint.FilterSeparatorBarPadding = 3;
			this.xrPivotGrid1.OptionsView.ShowColumnHeaders = false;
			this.xrPivotGrid1.OptionsView.ShowDataHeaders = false;
			this.xrPivotGrid1.OptionsView.ShowFilterHeaders = false;
			this.xrPivotGrid1.SizeF = new System.Drawing.SizeF(657.7084F, 98.95834F);
			this.xrPivotGrid1.FieldValueDisplayText += new System.EventHandler<DevExpress.XtraReports.UI.PivotGrid.PivotFieldDisplayTextEventArgs>(this.xrPivotGrid1_FieldValueDisplayText);
			// 
			// fieldCustomerName1
			// 
			this.fieldCustomerName1.Appearance.FieldHeader.BackColor = System.Drawing.Color.White;
			this.fieldCustomerName1.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.fieldCustomerName1.Appearance.FieldValue.BackColor = System.Drawing.Color.White;
			this.fieldCustomerName1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.fieldCustomerName1.AreaIndex = 1;
			this.fieldCustomerName1.Caption = "TÊN KHÁCH HÀNG";
			this.fieldCustomerName1.FieldName = "CustomerName";
			this.fieldCustomerName1.MinWidth = 50;
			this.fieldCustomerName1.Name = "fieldCustomerName1";
			this.fieldCustomerName1.Width = 200;
			// 
			// fieldCustomerCode1
			// 
			this.fieldCustomerCode1.Appearance.FieldHeader.BackColor = System.Drawing.Color.White;
			this.fieldCustomerCode1.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.fieldCustomerCode1.Appearance.FieldValue.BackColor = System.Drawing.Color.White;
			this.fieldCustomerCode1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.fieldCustomerCode1.AreaIndex = 0;
			this.fieldCustomerCode1.Caption = "MÃ KHÁCH HÀNG";
			this.fieldCustomerCode1.FieldName = "CustomerCode";
			this.fieldCustomerCode1.Name = "fieldCustomerCode1";
			// 
			// fieldTimeBandName1
			// 
			this.fieldTimeBandName1.Appearance.FieldHeader.BackColor = System.Drawing.Color.White;
			this.fieldTimeBandName1.Appearance.FieldHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.fieldTimeBandName1.Appearance.FieldValue.BackColor = System.Drawing.Color.White;
			this.fieldTimeBandName1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.fieldTimeBandName1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
			this.fieldTimeBandName1.AreaIndex = 0;
			this.fieldTimeBandName1.Caption = "MÃ GIỜ";
			this.fieldTimeBandName1.FieldName = "TimeBandName";
			this.fieldTimeBandName1.Name = "fieldTimeBandName1";
			// 
			// fieldBookingTypeName1
			// 
			this.fieldBookingTypeName1.AreaIndex = 0;
			this.fieldBookingTypeName1.Caption = "LOẠI";
			this.fieldBookingTypeName1.FieldName = "BookingTypeName";
			this.fieldBookingTypeName1.Name = "fieldBookingTypeName1";
			// 
			// fieldPrice1
			// 
			this.fieldPrice1.AreaIndex = 1;
			this.fieldPrice1.FieldName = "Price";
			this.fieldPrice1.Name = "fieldPrice1";
			// 
			// fieldDiscountValue1
			// 
			this.fieldDiscountValue1.AreaIndex = 2;
			this.fieldDiscountValue1.FieldName = "DiscountValue";
			this.fieldDiscountValue1.Name = "fieldDiscountValue1";
			// 
			// fieldTotalValue1
			// 
			this.fieldTotalValue1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.fieldTotalValue1.AreaIndex = 0;
			this.fieldTotalValue1.CellFormat.FormatString = "#,#";
			this.fieldTotalValue1.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.fieldTotalValue1.FieldName = "TotalValue";
			this.fieldTotalValue1.Name = "fieldTotalValue1";
			// 
			// TopMargin
			// 
			this.TopMargin.HeightF = 40F;
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
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1});
			this.ReportHeader.HeightF = 100.4167F;
			this.ReportHeader.Name = "ReportHeader";
			// 
			// xrLabel4
			// 
			this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(294.1667F, 70.20833F);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel4.SizeF = new System.Drawing.SizeF(256.1667F, 20.20833F);
			this.xrLabel4.StylePriority.UseFont = false;
			this.xrLabel4.Text = "Thời lượng băng: [Parameters.AssetDuration]";
			// 
			// xrLabel3
			// 
			this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
			this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0.4166603F, 69.79166F);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel3.SizeF = new System.Drawing.SizeF(256.1667F, 20.20833F);
			this.xrLabel3.StylePriority.UseFont = false;
			this.xrLabel3.Text = "Nhóm: [Parameters.CustomerType]";
			// 
			// xrLabel2
			// 
			this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Italic);
			this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0.4166603F, 22.91667F);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel2.SizeF = new System.Drawing.SizeF(1102.583F, 20F);
			this.xrLabel2.StylePriority.UseFont = false;
			this.xrLabel2.StylePriority.UseTextAlignment = false;
			this.xrLabel2.Text = "Từ  ngày [Parameters.FromDate!dd/MM/yyyy] đến ngày [Parameters.ToDate!dd/MM/yyyy]" +
    "";
			this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			// 
			// xrLabel1
			// 
			this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
			this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel1.SizeF = new System.Drawing.SizeF(1103F, 22.91667F);
			this.xrLabel1.StylePriority.UseFont = false;
			this.xrLabel1.StylePriority.UseTextAlignment = false;
			this.xrLabel1.Text = "TỔNG HỢP GIÁ TRỊ PHÁT SÓNG THEO NHÓM KHÁCH HÀNG";
			this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			// 
			// objectDataSource1
			// 
			this.objectDataSource1.DataSource = typeof(HD.TVAD.ReportLibrary.ValueReportByCustomerType.ValueReportByCustomerTypeViewModel);
			this.objectDataSource1.Name = "objectDataSource1";
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
			// CustomerType
			// 
			this.CustomerType.Description = "CustomerType";
			this.CustomerType.Name = "CustomerType";
			this.CustomerType.Visible = false;
			// 
			// AssetDuration
			// 
			this.AssetDuration.Description = "AssetDuration";
			this.AssetDuration.Name = "AssetDuration";
			this.AssetDuration.Visible = false;
			// 
			// ValueReportByCustomerTypeReport
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
			this.Margins = new System.Drawing.Printing.Margins(35, 31, 40, 100);
			this.PageHeight = 827;
			this.PageWidth = 1169;
			this.PaperKind = System.Drawing.Printing.PaperKind.A4;
			this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.FromDate,
            this.ToDate,
            this.CustomerType,
            this.AssetDuration});
			this.Version = "17.1";
			this.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart;
			((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}

		#endregion

		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
		private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
		private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
		private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel1;
		private DevExpress.XtraReports.UI.XRPivotGrid xrPivotGrid1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCustomerName1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldCustomerCode1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldTimeBandName1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldBookingTypeName1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldPrice1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldDiscountValue1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldTotalValue1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel2;
		private DevExpress.XtraReports.UI.XRLabel xrLabel4;
		private DevExpress.XtraReports.UI.XRLabel xrLabel3;
		public DevExpress.XtraReports.Parameters.Parameter FromDate;
		public DevExpress.XtraReports.Parameters.Parameter ToDate;
		public DevExpress.XtraReports.Parameters.Parameter CustomerType;
		public DevExpress.XtraReports.Parameters.Parameter AssetDuration;
	}
}
