using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TemplateItemAssetTypeRequestViewModel
	{
		[Required]
		public Guid Id { get; set; }
		public Guid TemplateItemId { get; set; }
		[Display(Name = "Asset Type", Prompt = "Asset Type")]
		public Guid AssetTypeId { get; set; }
		public string AssetTypeName { get; set; }
		[Display(Name = "Min Count", Prompt = "Min Count")]
		public int? MinCount { get; set; }
		[Display(Name = "Max Count", Prompt = "Max Count")]
		public int? MaxCount { get; set; }
	}
}
