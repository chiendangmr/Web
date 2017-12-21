namespace HD.TVAD.ReportLibrary.Reports.SubDetail
{
	partial class AnnexContractDetailReport
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
			this.spotValueOfContractReport = new DevExpress.XtraReports.UI.XRSubreport();
			this.spotListReport = new DevExpress.XtraReports.UI.XRSubreport();
			this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
			this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
			this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			this.ContractCode = new DevExpress.XtraReports.Parameters.Parameter();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.spotValueOfContractReport,
            this.spotListReport});
			this.Detail.HeightF = 98.08334F;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
			this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			// 
			// spotValueOfContractReport
			// 
			this.spotValueOfContractReport.LocationFloat = new DevExpress.Utils.PointFloat(4.768372E-05F, 48F);
			this.spotValueOfContractReport.Name = "spotValueOfContractReport";
			this.spotValueOfContractReport.ReportSource = new HD.TVAD.ReportLibrary.BroadcastCertificateWithValueContract.SpotValueOfContractReport();
			this.spotValueOfContractReport.SizeF = new System.Drawing.SizeF(1109F, 50.08334F);
			// 
			// spotListReport
			// 
			this.spotListReport.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
			this.spotListReport.Name = "spotListReport";
			this.spotListReport.ReportSource = new HD.TVAD.ReportLibrary.BroadcastCertificate.SpotListReport();
			this.spotListReport.SizeF = new System.Drawing.SizeF(1109F, 48F);
			// 
			// TopMargin
			// 
			this.TopMargin.HeightF = 0F;
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
			this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			// 
			// BottomMargin
			// 
			this.BottomMargin.HeightF = 0F;
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
			this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			// 
			// ReportHeader
			// 
			this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1});
			this.ReportHeader.HeightF = 23F;
			this.ReportHeader.Name = "ReportHeader";
			// 
			// xrLabel1
			// 
			this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
			this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel1.SizeF = new System.Drawing.SizeF(1109F, 23F);
			this.xrLabel1.StylePriority.UseFont = false;
			this.xrLabel1.Text = "MÃ PHỤ LỤC: [Parameters.ContractCode]";
			// 
			// ContractCode
			// 
			this.ContractCode.Description = "ContractCode";
			this.ContractCode.Name = "ContractCode";
			this.ContractCode.ValueInfo = "\" \"";
			this.ContractCode.Visible = false;
			// 
			// AnnexContractDetailReport
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader});
			this.Landscape = true;
			this.Margins = new System.Drawing.Printing.Margins(30, 30, 0, 0);
			this.PageHeight = 827;
			this.PageWidth = 1169;
			this.PaperKind = System.Drawing.Printing.PaperKind.A4;
			this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.ContractCode});
			this.Version = "17.1";
			this.ParametersRequestBeforeShow += new System.EventHandler<DevExpress.XtraReports.Parameters.ParametersRequestEventArgs>(this.AnnexContractDetailReport_ParametersRequestBeforeShow);
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}

		#endregion

		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
		private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
		private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
		private DevExpress.XtraReports.UI.XRLabel xrLabel1;
		public DevExpress.XtraReports.UI.XRSubreport spotListReport;
		public DevExpress.XtraReports.UI.XRSubreport spotValueOfContractReport;
		public DevExpress.XtraReports.Parameters.Parameter ContractCode;
	}
}
