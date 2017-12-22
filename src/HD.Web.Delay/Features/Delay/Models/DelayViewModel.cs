using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class DelayViewModel
    {
        public Guid Id { get; set; }
		[Display(Name = "Code", Prompt = "Asset code place")]
        public string Code { get; set; }
		[Display(Name = "Product Name", Prompt = "Product Name place")]
		public string ProductName { get; set; }
		[Display(Name = "Product Model", Prompt = "Product model place")]
		public string ProductModel { get; set; }
		[Display(Name = "Duration")]
		public int BlockDuration { get; set; }
		[Display(Name = "Create Time")]
		public DateTime CreateTime { get; set; }
		[Display(Name = "Type")]
		public Guid TypeId { get; set; }
		[Display(Name = "Type")]
		public string TypeName { get; set; }
		[Display(Name = "Register")]
		public Guid? RegisterId { get; set; }
		[Display(Name = "Register")]
		public string RegisterName { get; set; }
		[Display(Name = "Producer")]
		public Guid? ProducerId { get; set; }
		[Display(Name = "Producer")]
		public string ProducerName { get; set; }
		[Display(Name = "Area")]
		public Guid? AreaId { get; set; }
		[Display(Name = "Area")]
		public string AreaName { get; set; }
		[Display(Name = "ProductGroup")]
		public Guid? ProductGroupId { get; set; }
		[Display(Name = "ProductGroup")]
		public string ProductGroupName { get; set; }
		[Display(Name = "Approve")]
		public bool? Approve { get; set; }		
		[Display(Name = "Approve End Date")]
		public DateTime? ApproveEndDate { get; set; }
		[Display(Name = "Last Product Model")]
		public Guid? LastProductModel { get; set; }
		[Display(Name = "Last Product Model")]
		public string LastProductModelName { get; set; }
        public string Text { get; set; }
    }
}