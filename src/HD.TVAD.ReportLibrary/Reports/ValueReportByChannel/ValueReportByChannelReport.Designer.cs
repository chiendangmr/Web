namespace HD.TVAD.ReportLibrary.ValueReportByChannel
{
	partial class ValueReportByChannelReport
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
			this.fieldBookingTypeName1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.fieldChannelName1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.fieldPrice1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.fieldDiscountValue1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.fieldTotalValue1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
			this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
			this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
			this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
			this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrControlStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
			this.xrControlStyle2 = new DevExpress.XtraReports.UI.XRControlStyle();
			this.FromDate = new DevExpress.XtraReports.Parameters.Parameter();
			this.ToDate = new DevExpress.XtraReports.Parameters.Parameter();
			((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPivotGrid1});
			this.Detail.HeightF = 95.83334F;
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
			this.xrPivotGrid1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
			this.xrPivotGrid1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
			this.xrPivotGrid1.Appearance.Lines.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.Appearance.TotalCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
			this.xrPivotGrid1.CellStyleName = "xrControlStyle2";
			this.xrPivotGrid1.CustomTotalCellStyleName = "xrControlStyle2";
			this.xrPivotGrid1.DataSource = this.objectDataSource1;
			this.xrPivotGrid1.FieldHeaderStyleName = "xrControlStyle2";
			this.xrPivotGrid1.Fields.AddRange(new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField[] {
            this.fieldBookingTypeName1,
            this.fieldChannelName1,
            this.fieldPrice1,
            this.fieldDiscountValue1,
            this.fieldTotalValue1});
			this.xrPivotGrid1.FieldValueGrandTotalStyleName = "xrControlStyle2";
			this.xrPivotGrid1.FieldValueStyleName = "xrControlStyle2";
			this.xrPivotGrid1.GrandTotalCellStyleName = "xrControlStyle2";
			this.xrPivotGrid1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
			this.xrPivotGrid1.Name = "xrPivotGrid1";
			this.xrPivotGrid1.OptionsPrint.FilterSeparatorBarPadding = 3;
			this.xrPivotGrid1.OptionsView.ShowColumnHeaders = false;
			this.xrPivotGrid1.OptionsView.ShowDataHeaders = false;
			this.xrPivotGrid1.OptionsView.ShowFilterHeaders = false;
			this.xrPivotGrid1.SizeF = new System.Drawing.SizeF(393.125F, 95.83334F);
			this.xrPivotGrid1.TotalCellStyleName = "xrControlStyle2";
			this.xrPivotGrid1.FieldValueDisplayText += new System.EventHandler<DevExpress.XtraReports.UI.PivotGrid.PivotFieldDisplayTextEventArgs>(this.xrPivotGrid1_FieldValueDisplayText);
			// 
			// objectDataSource1
			// 
			this.objectDataSource1.DataSource = typeof(HD.TVAD.ReportLibrary.ValueReportByChannel.ValueReportByChannelViewModel);
			this.objectDataSource1.Name = "objectDataSource1";
			// 
			// fieldBookingTypeName1
			// 
			this.fieldBookingTypeName1.Appearance.Cell.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.fieldBookingTypeName1.Appearance.CustomTotalCell.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.fieldBookingTypeName1.Appearance.FieldHeader.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
			this.fieldBookingTypeName1.Appearance.FieldValue.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.fieldBookingTypeName1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
			this.fieldBookingTypeName1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.fieldBookingTypeName1.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.fieldBookingTypeName1.Appearance.TotalCell.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.fieldBookingTypeName1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
			this.fieldBookingTypeName1.AreaIndex = 0;
			this.fieldBookingTypeName1.Caption = "LOẠI HỢP ĐỒNG";
			this.fieldBookingTypeName1.FieldName = "BookingTypeName";
			this.fieldBookingTypeName1.Name = "fieldBookingTypeName1";
			this.fieldBookingTypeName1.Width = 200;
			// 
			// fieldChannelName1
			// 
			this.fieldChannelName1.Appearance.Cell.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.fieldChannelName1.Appearance.CustomTotalCell.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.fieldChannelName1.Appearance.FieldHeader.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
			this.fieldChannelName1.Appearance.FieldValue.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
			this.fieldChannelName1.Appearance.FieldValueGrandTotal.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.fieldChannelName1.Appearance.FieldValueTotal.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.fieldChannelName1.Appearance.GrandTotalCell.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.fieldChannelName1.Appearance.TotalCell.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.fieldChannelName1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
			this.fieldChannelName1.AreaIndex = 0;
			this.fieldChannelName1.FieldName = "ChannelName";
			this.fieldChannelName1.Name = "fieldChannelName1";
			// 
			// fieldPrice1
			// 
			this.fieldPrice1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
			this.fieldPrice1.AreaIndex = 0;
			this.fieldPrice1.CellFormat.FormatString = "#,#";
			this.fieldPrice1.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.fieldPrice1.FieldName = "Price";
			this.fieldPrice1.Name = "fieldPrice1";
			// 
			// fieldDiscountValue1
			// 
			this.fieldDiscountValue1.AreaIndex = 0;
			this.fieldDiscountValue1.FieldName = "DiscountValue";
			this.fieldDiscountValue1.Name = "fieldDiscountValue1";
			// 
			// fieldTotalValue1
			// 
			this.fieldTotalValue1.AreaIndex = 1;
			this.fieldTotalValue1.FieldName = "TotalValue";
			this.fieldTotalValue1.Name = "fieldTotalValue1";
			// 
			// TopMargin
			// 
			this.TopMargin.HeightF = 45.83333F;
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
            this.xrLabel2,
            this.xrLabel1});
			this.ReportHeader.HeightF = 81.25F;
			this.ReportHeader.Name = "ReportHeader";
			// 
			// xrLabel2
			// 
			this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Italic);
			this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 30.20833F);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel2.SizeF = new System.Drawing.SizeF(1100F, 20F);
			this.xrLabel2.StylePriority.UseFont = false;
			this.xrLabel2.StylePriority.UseTextAlignment = false;
			this.xrLabel2.Text = "Từ  ngày [Parameters.FromDate!dd/MM/yyy] đến ngày [Parameters.ToDate!dd/MM/yyy]";
			this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			// 
			// xrLabel1
			// 
			this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
			this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel1.SizeF = new System.Drawing.SizeF(1100F, 30.20833F);
			this.xrLabel1.StylePriority.UseFont = false;
			this.xrLabel1.StylePriority.UseTextAlignment = false;
			this.xrLabel1.Text = "TỔNG HỢP GIÁ TRỊ PHÁT SÓNG THEO KÊNH ";
			this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			// 
			// xrControlStyle1
			// 
			this.xrControlStyle1.Name = "xrControlStyle1";
			this.xrControlStyle1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
			// 
			// xrControlStyle2
			// 
			this.xrControlStyle2.BackColor = System.Drawing.Color.White;
			this.xrControlStyle2.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.xrControlStyle2.ForeColor = System.Drawing.Color.Black;
			this.xrControlStyle2.Name = "xrControlStyle2";
			this.xrControlStyle2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
			// 
			// FromDate
			// 
			this.FromDate.Description = "FromDate";
			this.FromDate.Name = "FromDate";
			this.FromDate.Visible = false;
			// 
			// ToDate
			// 
			this.ToDate.Description = "ToDate";
			this.ToDate.Name = "ToDate";
			this.ToDate.Visible = false;
			// 
			// ValueReportByChannelReport
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
			this.Margins = new System.Drawing.Printing.Margins(31, 36, 46, 100);
			this.PageHeight = 827;
			this.PageWidth = 1169;
			this.PaperKind = System.Drawing.Printing.PaperKind.A4;
			this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.FromDate,
            this.ToDate});
			this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.xrControlStyle1,
            this.xrControlStyle2});
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
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldBookingTypeName1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldChannelName1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldPrice1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldDiscountValue1;
		private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldTotalValue1;
		private DevExpress.XtraReports.UI.XRControlStyle xrControlStyle1;
		private DevExpress.XtraReports.UI.XRControlStyle xrControlStyle2;
		private DevExpress.XtraReports.UI.XRLabel xrLabel2;
		public DevExpress.XtraReports.Parameters.Parameter FromDate;
		public DevExpress.XtraReports.Parameters.Parameter ToDate;
	}
}
