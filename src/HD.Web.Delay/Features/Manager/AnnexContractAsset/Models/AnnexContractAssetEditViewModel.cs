using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class AnnexContractAssetEditViewModel
	{
		[Required]
		public Guid Id { get; set; }
		public Guid AnnexContractId { get; set; }
		[Display(Name = "Asset")]
		public Guid AssetId { get; set; }
		[Display(Name = "Price Type")]
		public Guid PriceTypeDetailId { get; set; }
		[Display(Name = "Content")]
		public string Content { get; set; }
		[Display(Name = "Price")]
		public decimal? Price { get; set; }
	}
}
