using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TemplateItemAssetTypeRequestEditViewModel
	{
		[Required]
		public Guid Id { get; set; }
		[Required]
		public Guid TemplateItemId { get; set; }
		public Guid AssetTypeId { get; set; }
		public int MinCount { get; set; }
		public int MaxCount { get; set; }
	}
}
