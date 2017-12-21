using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class AnnexContractAssetViewModel
	{
		public Guid Id { get; set; }
		public Guid AnnexContractId { get; set; }
		[Display(Name = "Asset")]
		public Guid AssetId { get; set; }
		[Display(Name = "Price Type")]
		public Guid PriceTypeDetailId { get; set; }
		[Display(Name = "Content", Prompt = "Content place")]
		public string Content { get; set; }
		[Display(Name = "Price", Prompt = "Price place")]
		public decimal? Price { get; set; }


		public int BookingTypeId { get; set; }

		[Display(Name = "Asset")]
		public string AssetCode { get; set; }
		public string AssetProductName { get; set; }
		public int AssetBlockDuration { get; set; }
		public string PriceTypeDetailName { get; set; }
	}
}
