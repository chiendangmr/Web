using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class ContentCreateViewModel
    {
		[Required]
		[Display(Name = "Code")]
		public string Code { get; set; }
		[Required]
		[Display(Name = "Product Name")]
		public string ProductName { get; set; }
		[Display(Name = "Product Model")]
		public string ProductModel { get; set; }
		[Required]
		[Display(Name = "Duration")]
		public int BlockDuration { get; set; }
		[Required]
		[Display(Name = "Type")]
		public Guid TypeId { get; set; }
		[Display(Name = "Register")]
		public Guid? RegisterId { get; set; }
		[Display(Name = "Producer")]
		public Guid? ProducerId { get; set; }
		public Guid AreaId { get; set; }
        public string AreaName { get; set; }
		[Display(Name = "ProductGroup")]
		public Guid? ProductGroupId { get; set; }
		[Display(Name = "Last Product Model")]
		public Guid? LastProductModel { get; set; }
        public string Text { get; set; }

		public Guid LastAssetId { get; set; } // for back action
	}
}