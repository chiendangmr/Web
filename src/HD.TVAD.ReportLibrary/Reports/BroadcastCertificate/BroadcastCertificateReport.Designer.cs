namespace HD.TVAD.ReportLibrary.BroadcastCertificate
{
	partial class BroadcastCertificateReport
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
			this.Detail = new DevExpress.XtraReports.UI.DetailBand();
			this.subSpotList = new DevExpress.XtraReports.UI.XRSubreport();
			this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
			this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
			this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
			this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
			this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
			this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
			this.SignPerson = new DevExpress.XtraReports.Parameters.Parameter();
			this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
			this.ContractCode = new DevExpress.XtraReports.Parameters.Parameter();
			this.Day = new DevExpress.XtraReports.Parameters.Parameter();
			this.Month = new DevExpress.XtraReports.Parameters.Parameter();
			this.Year = new DevExpress.XtraReports.Parameters.Parameter();
			this.ContractTypeName = new DevExpress.XtraReports.Parameters.Parameter();
			this.SpotsCount = new DevExpress.XtraReports.Parameters.Parameter();
			this.TotalDuration = new DevExpress.XtraReports.Parameters.Parameter();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.subSpotList});
			this.Detail.HeightF = 56.25F;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
			this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			// 
			// subSpotList
			// 
			this.subSpotList.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
			this.subSpotList.Name = "subSpotList";
			this.subSpotList.ReportSource = new HD.TVAD.ReportLibrary.BroadcastCertificate.SpotListReport();
			this.subSpotList.SizeF = new System.Drawing.SizeF(1092F, 56.25F);
			// 
			// TopMargin
			// 
			this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1});
			this.TopMargin.HeightF = 55.20833F;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
			this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			// 
			// xrPageInfo1
			// 
			this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(1051.065F, 32.20833F);
			this.xrPageInfo1.Name = "xrPageInfo1";
			this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrPageInfo1.SizeF = new System.Drawing.SizeF(40.93579F, 23F);
			this.xrPageInfo1.StylePriority.UseTextAlignment = false;
			this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
			// 
			// BottomMargin
			// 
			this.BottomMargin.HeightF = 51F;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
			this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			// 
			// ReportHeader
			// 
			this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1});
			this.ReportHeader.HeightF = 167.7083F;
			this.ReportHeader.Name = "ReportHeader";
			// 
			// xrLabel3
			// 
			this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
			this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 94.79166F);
			this.xrLabel3.Multiline = true;
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel3.SizeF = new System.Drawing.SizeF(1092F, 43.83332F);
			this.xrLabel3.StylePriority.UseFont = false;
			this.xrLabel3.StylePriority.UseTextAlignment = false;
			this.xrLabel3.Text = "CHỨNG  NHẬN PHÁT SÓNG TRÊN ĐÀI TRUYỀN HÌNH VIỆT NAM\r\nTHEO PHỤ LỤC PHÁT SÓNG SỐ:  " +
    "[Parameters.ContractCode]  / [Parameters.ContractTypeName]";
			this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			// 
			// xrLabel2
			// 
			this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
			this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(546.8396F, 59.45835F);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel2.SizeF = new System.Drawing.SizeF(545.1613F, 23F);
			this.xrLabel2.StylePriority.UseFont = false;
			this.xrLabel2.Text = "Hà Nội, ngày [Parameters.Day] tháng [Parameters.Month] năm [Parameters.Year]";
			this.xrLabel2.Visible = false;
			// 
			// xrLabel1
			// 
			this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
			this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
			this.xrLabel1.Multiline = true;
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel1.SizeF = new System.Drawing.SizeF(1092F, 59.45834F);
			this.xrLabel1.StylePriority.UseFont = false;
			this.xrLabel1.StylePriority.UseTextAlignment = false;
			this.xrLabel1.Text = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM\r\nĐộc lập - Tự do - Hạnh phúc\r\n-----------*----" +
    "-------";
			this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			// 
			// ReportFooter
			// 
			this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel6,
            this.xrLabel10,
            this.xrLabel5,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel7});
			this.ReportFooter.HeightF = 209.4584F;
			this.ReportFooter.Name = "ReportFooter";
			// 
			// xrLabel6
			// 
			this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
			this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 115.0001F);
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel6.SizeF = new System.Drawing.SizeF(1092F, 22.99998F);
			this.xrLabel6.StylePriority.UseFont = false;
			this.xrLabel6.StylePriority.UseTextAlignment = false;
			this.xrLabel6.Text = "Trung tâm QC & DV truyền hình";
			this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			// 
			// xrLabel10
			// 
			this.xrLabel10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding(this.SignPerson, "Text", "")});
			this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
			this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(0F, 186.4583F);
			this.xrLabel10.Name = "xrLabel10";
			this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel10.SizeF = new System.Drawing.SizeF(1092.001F, 23F);
			this.xrLabel10.StylePriority.UseFont = false;
			this.xrLabel10.StylePriority.UseTextAlignment = false;
			this.xrLabel10.Text = "Người ký";
			this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			// 
			// SignPerson
			// 
			this.SignPerson.Description = "SignPerson";
			this.SignPerson.Name = "SignPerson";
			this.SignPerson.Visible = false;
			// 
			// xrLabel5
			// 
			this.xrLabel5.ForeColor = System.Drawing.Color.Black;
			this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 69.00005F);
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel5.SizeF = new System.Drawing.SizeF(1092F, 23F);
			this.xrLabel5.StylePriority.UseForeColor = false;
			this.xrLabel5.Text = "- Chứng nhận Phát sóng này không được phép sao chụp lại dưới bất kỳ hình thức nào" +
    ".";
			// 
			// xrLabel9
			// 
			this.xrLabel9.ForeColor = System.Drawing.Color.Black;
			this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(0F, 46.00003F);
			this.xrLabel9.Name = "xrLabel9";
			this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel9.SizeF = new System.Drawing.SizeF(1092.001F, 23F);
			this.xrLabel9.StylePriority.UseForeColor = false;
			this.xrLabel9.Text = "- Tổng thời lượng: [Parameters.TotalDuration]";
			// 
			// xrLabel8
			// 
			this.xrLabel8.ForeColor = System.Drawing.Color.Black;
			this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 23.00002F);
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel8.SizeF = new System.Drawing.SizeF(1092F, 23F);
			this.xrLabel8.StylePriority.UseForeColor = false;
			this.xrLabel8.Text = "- Tổng số lần phát sóng: [Parameters.SpotsCount]";
			// 
			// xrLabel7
			// 
			this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
			this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
			this.xrLabel7.Name = "xrLabel7";
			this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel7.SizeF = new System.Drawing.SizeF(1092.001F, 23F);
			this.xrLabel7.StylePriority.UseFont = false;
			this.xrLabel7.Text = "Ghi chú:";
			// 
			// ContractCode
			// 
			this.ContractCode.Description = "ContractCode";
			this.ContractCode.Name = "ContractCode";
			this.ContractCode.Visible = false;
			// 
			// Day
			// 
			this.Day.Description = "Day";
			this.Day.Name = "Day";
			this.Day.Type = typeof(int);
			this.Day.ValueInfo = "0";
			this.Day.Visible = false;
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
			// ContractTypeName
			// 
			this.ContractTypeName.Description = "ContractTypeName";
			this.ContractTypeName.Name = "ContractTypeName";
			this.ContractTypeName.Visible = false;
			// 
			// SpotsCount
			// 
			this.SpotsCount.Description = "SpotsCount";
			this.SpotsCount.Name = "SpotsCount";
			this.SpotsCount.Type = typeof(int);
			this.SpotsCount.ValueInfo = "0";
			this.SpotsCount.Visible = false;
			// 
			// TotalDuration
			// 
			this.TotalDuration.Description = "TotalDuration";
			this.TotalDuration.Name = "TotalDuration";
			this.TotalDuration.Type = typeof(int);
			this.TotalDuration.ValueInfo = "0";
			this.TotalDuration.Visible = false;
			// 
			// BroadcastCertificateReport
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter});
			this.Landscape = true;
			this.Margins = new System.Drawing.Printing.Margins(39, 38, 55, 51);
			this.PageHeight = 827;
			this.PageWidth = 1169;
			this.PaperKind = System.Drawing.Printing.PaperKind.A4;
			this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.ContractCode,
            this.SignPerson,
            this.Day,
            this.Month,
            this.Year,
            this.ContractTypeName,
            this.SpotsCount,
            this.TotalDuration});
			this.Version = "17.1";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}

		#endregion

		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
		private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
		private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
		private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
		private DevExpress.XtraReports.UI.XRLabel xrLabel1;
		private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel2;
		private DevExpress.XtraReports.UI.XRLabel xrLabel3;
		private DevExpress.XtraReports.UI.XRLabel xrLabel5;
		private DevExpress.XtraReports.UI.XRLabel xrLabel9;
		private DevExpress.XtraReports.UI.XRLabel xrLabel8;
		private DevExpress.XtraReports.UI.XRLabel xrLabel7;
		private DevExpress.XtraReports.UI.XRLabel xrLabel6;
		private DevExpress.XtraReports.UI.XRLabel xrLabel10;
		public DevExpress.XtraReports.UI.XRSubreport subSpotList;
		public DevExpress.XtraReports.Parameters.Parameter ContractCode;
		public DevExpress.XtraReports.Parameters.Parameter SignPerson;
		public DevExpress.XtraReports.Parameters.Parameter Day;
		public DevExpress.XtraReports.Parameters.Parameter Month;
		public DevExpress.XtraReports.Parameters.Parameter Year;
		public DevExpress.XtraReports.Parameters.Parameter ContractTypeName;
		public DevExpress.XtraReports.Parameters.Parameter SpotsCount;
		public DevExpress.XtraReports.Parameters.Parameter TotalDuration;
	}
}
