using System;
using System.ComponentModel.DataAnnotations;

namespace HD.TVAD.ReportLibrary
{
	public class PrintCertificateByAnnexContractAssetParameter : Parameter
	{
		[Required]
		[Display(Name = "Annex Contract Asset")]
		public Guid AnnexContractAssetId { get; set; }


		[Display(Name = "Asset")]
		public string AssetCode { get; set; }

		[Display(Name = "Sign person")]
		public string SignPerson { get; set; }
	}
}