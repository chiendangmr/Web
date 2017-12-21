using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class AnnexContractAssetCreateViewModel
	{
		public Guid AnnexContractId { get; set; }
		[Required]
		[Display(Name = "Asset")]
		public Guid AssetId { get; set; }
		[Required]
		[Display(Name = "Price Type")]
		public Guid PriceTypeDetailId { get; set; }
		[Display(Name = "Booking Type")]
		public int BookingTypeId { get; set; }
		[Display(Name = "Content", Prompt ="Content place")]
		public string Content { get; set; }
		[Display(Name = "Price", Prompt ="Price place")]
		public decimal? Price { get; set; }

		[Required]
		[Display(Name = "Asset Code", Prompt = "Asset Code place")]
		public string AssetCodeDisplay { get; set; }
		[Display(Name = "Annex Contract Code", Prompt = "Annex Contract Code place")]
		public string AnnexContractCode { get; set; }
	}
}
