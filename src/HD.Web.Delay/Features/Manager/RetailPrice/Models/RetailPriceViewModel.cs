using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class RetailPriceViewModel
	{
		public Guid Id { get; set; }
		[Display(Name = "Type")]
		public Guid RetailTypeId { get; set; }
		[Display(Name = "Description")]
		public string RetailTypeDescription { get; set; }
		[Display(Name = "Name")]
		public string TypeDetailName { get; set; }
		[Display(Name = "Start Date")]
		public DateTime StartDate { get; set; }
		[Required]
		[Display(Name = "Price", Prompt = "Price place")]
		[Range(0, int.MaxValue)]
		public decimal Price { get; set; }
	}
}
