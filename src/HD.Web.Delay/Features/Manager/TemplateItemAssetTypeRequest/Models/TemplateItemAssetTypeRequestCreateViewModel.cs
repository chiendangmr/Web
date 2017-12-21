using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TemplateItemAssetTypeRequestCreateViewModel
	{
		[Required]
		public Guid TemplateItemId { get; set; }
		[Required]
		[Display(Name = "Asset Type", Prompt = "Asset Type")]
		public Guid AssetTypeId { get; set; }
		[Display(Name = "Min Count", Prompt = "Min Count")]
		public int MinCount { get; set; }
		[Display(Name = "Max Count", Prompt = "Max Count")]
		public int MaxCount { get; set; }
	}
}
