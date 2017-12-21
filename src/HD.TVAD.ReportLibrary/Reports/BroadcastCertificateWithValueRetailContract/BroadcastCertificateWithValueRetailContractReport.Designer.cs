namespace HD.TVAD.ReportLibrary.Reports.BroadcastCertificateWithValueRetailContract
{
	partial class BroadcastCertificateWithValueRetailContractReport
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BroadcastCertificateWithValueRetailContractReport));
			this.Detail = new DevExpress.XtraReports.UI.DetailBand();
			this.subSpotValueOfRetailContractReport = new DevExpress.XtraReports.UI.XRSubreport();
			this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
			this.SubSpotListReport = new DevExpress.XtraReports.UI.XRSubreport();
			this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
			this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
			this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
			this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
			this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
			this.Day = new DevExpress.XtraReports.Parameters.Parameter();
			this.Month = new DevExpress.XtraReports.Parameters.Parameter();
			this.Year = new DevExpress.XtraReports.Parameters.Parameter();
			this.ContractCode = new DevExpress.XtraReports.Parameters.Parameter();
			this.CustomerName = new DevExpress.XtraReports.Parameters.Parameter();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.subSpotValueOfRetailContractReport,
            this.xrLabel8,
            this.SubSpotListReport});
			this.Detail.HeightF = 100F;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
			this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			// 
			// subSpotValueOfRetailContractReport
			// 
			this.subSpotValueOfRetailContractReport.LocationFloat = new DevExpress.Utils.PointFloat(0F, 61.62503F);
			this.subSpotValueOfRetailContractReport.Name = "subSpotValueOfRetailContractReport";
			this.subSpotValueOfRetailContractReport.ReportSource = new HD.TVAD.ReportLibrary.Reports.BroadcastCertificateWithValueRetailContract.SpotValueOfRetailContractReport();
			this.subSpotValueOfRetailContractReport.SizeF = new System.Drawing.SizeF(1040F, 38.37497F);
			// 
			// xrLabel8
			// 
			this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 38.62502F);
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel8.SizeF = new System.Drawing.SizeF(1040F, 23F);
			this.xrLabel8.StylePriority.UseFont = false;
			this.xrLabel8.Text = "Giá trị phát sóng";
			// 
			// SubSpotListReport
			// 
			this.SubSpotListReport.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
			this.SubSpotListReport.Name = "SubSpotListReport";
			this.SubSpotListReport.ReportSource = new HD.TVAD.ReportLibrary.BroadcastCertificate.SpotListReport();
			this.SubSpotListReport.SizeF = new System.Drawing.SizeF(1040F, 38.625F);
			// 
			// TopMargin
			// 
			this.TopMargin.HeightF = 30F;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
			this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			// 
			// BottomMargin
			// 
			this.BottomMargin.HeightF = 30F;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
			this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			// 
			// ReportHeader
			// 
			this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabel6,
            this.xrLabel5,
            this.xrLabel3,
            this.xrLabel2,
            this.xrPageInfo1,
            this.xrLabel1,
            this.xrLabel13});
			this.ReportHeader.HeightF = 309.8332F;
			this.ReportHeader.Name = "ReportHeader";
			// 
			// xrLabel4
			// 
			this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
			this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 142.1666F);
			this.xrLabel4.Name = "xrLabel4";
			this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel4.SizeF = new System.Drawing.SizeF(1040F, 23F);
			this.xrLabel4.StylePriority.UseFont = false;
			this.xrLabel4.StylePriority.UseTextAlignment = false;
			this.xrLabel4.Text = "I. BÊN A : TRUNG TÂM QUẢNG CÁO & DỊCH VỤ TRUYỀN HÌNH";
			this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
			// 
			// xrLabel6
			// 
			this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
			this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 285.7915F);
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel6.SizeF = new System.Drawing.SizeF(1040F, 24.04167F);
			this.xrLabel6.StylePriority.UseFont = false;
			this.xrLabel6.Text = "II. BÊN B : [Parameters.CustomerName]";
			// 
			// xrLabel5
			// 
			this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 165.1666F);
			this.xrLabel5.Multiline = true;
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel5.SizeF = new System.Drawing.SizeF(1040F, 120.6249F);
			this.xrLabel5.StylePriority.UseFont = false;
			this.xrLabel5.Text = resources.GetString("xrLabel5.Text");
			// 
			// xrLabel3
			// 
			this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
			this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 100F);
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel3.SizeF = new System.Drawing.SizeF(1040F, 23F);
			this.xrLabel3.StylePriority.UseFont = false;
			this.xrLabel3.StylePriority.UseTextAlignment = false;
			this.xrLabel3.Text = "HỢP ĐỒNG PHÁT SÓNG SỐ : [Parameters.ContractCode] / QCL";
			this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// xrLabel2
			// 
			this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
			this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(587.8066F, 67.00001F);
			this.xrLabel2.Name = "xrLabel2";
			this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel2.SizeF = new System.Drawing.SizeF(524.1935F, 23F);
			this.xrLabel2.StylePriority.UseFont = false;
			this.xrLabel2.Text = "Hà nội ngày [Parameters.Day] tháng [Parameters.Month] năm [Parameters.Year]";
			// 
			// xrPageInfo1
			// 
			this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(1058.417F, 0F);
			this.xrPageInfo1.Name = "xrPageInfo1";
			this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrPageInfo1.SizeF = new System.Drawing.SizeF(49.37494F, 23F);
			this.xrPageInfo1.StylePriority.UseTextAlignment = false;
			this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
			// 
			// xrLabel1
			// 
			this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
			this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(101.125F, 0F);
			this.xrLabel1.Multiline = true;
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel1.SizeF = new System.Drawing.SizeF(903.1251F, 59.45834F);
			this.xrLabel1.StylePriority.UseFont = false;
			this.xrLabel1.StylePriority.UseTextAlignment = false;
			this.xrLabel1.Text = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM\r\nĐộc lập - Tự do - Hạnh phúc\r\n-----------*----" +
    "-------";
			this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
			// 
			// xrLabel13
			// 
			this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
			this.xrLabel13.Name = "xrLabel13";
			this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel13.SizeF = new System.Drawing.SizeF(87.50001F, 23F);
			this.xrLabel13.Text = "Ngày in: ";
			// 
			// ReportFooter
			// 
			this.ReportFooter.HeightF = 0F;
			this.ReportFooter.Name = "ReportFooter";
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
			// ContractCode
			// 
			this.ContractCode.Description = "ContractCode";
			this.ContractCode.Name = "ContractCode";
			this.ContractCode.Visible = false;
			// 
			// CustomerName
			// 
			this.CustomerName.Description = "CustomerName";
			this.CustomerName.Name = "CustomerName";
			this.CustomerName.Visible = false;
			// 
			// BroadcastCertificateWithValueRetailContractReport
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter});
			this.Landscape = true;
			this.Margins = new System.Drawing.Printing.Margins(27, 30, 30, 30);
			this.PageHeight = 827;
			this.PageWidth = 1169;
			this.PaperKind = System.Drawing.Printing.PaperKind.A4;
			this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.Day,
            this.Month,
            this.Year,
            this.ContractCode,
            this.CustomerName});
			this.Version = "17.1";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}

		#endregion

		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
		private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
		private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
		private DevExpress.XtraReports.UI.XRLabel xrLabel6;
		private DevExpress.XtraReports.UI.XRLabel xrLabel5;
		private DevExpress.XtraReports.UI.XRLabel xrLabel3;
		private DevExpress.XtraReports.UI.XRLabel xrLabel2;
		private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel13;
		private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
		public DevExpress.XtraReports.UI.XRSubreport subSpotValueOfRetailContractReport;
		private DevExpress.XtraReports.UI.XRLabel xrLabel8;
		public DevExpress.XtraReports.UI.XRSubreport SubSpotListReport;
		private DevExpress.XtraReports.UI.XRLabel xrLabel4;
		public DevExpress.XtraReports.Parameters.Parameter Day;
		public DevExpress.XtraReports.Parameters.Parameter Month;
		public DevExpress.XtraReports.Parameters.Parameter Year;
		public DevExpress.XtraReports.Parameters.Parameter ContractCode;
		public DevExpress.XtraReports.Parameters.Parameter CustomerName;
	}
}
