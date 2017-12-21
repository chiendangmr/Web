using System;
using System.ComponentModel.DataAnnotations;

namespace HD.TVAD.ReportLibrary
{
	public class PrintContractByAnnexContractAssetParameter : Parameter
	{
		[Required]
		[Display(Name = "Annex Contract Asset")]
		public Guid AnnexContractAssetId { get; set; }
		[Display(Name = "Asset")]
		public string AssetCode { get; set; }


		[Display(Name = "A Organic Position")]
		public string A_OrganicPositionName { get; set; }
		[Display(Name = "A Organic Person")]
		public string A_OrganicPersonName { get; set; }
		[Display(Name = "B Organic Position")]
		public string B_OrganicPositionName { get; set; }
		[Display(Name = "B Organic Person")]
		public string B_OrganicPersonName { get; set; }
	}
}