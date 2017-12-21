using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class DiscountCustomerEditViewModel
	{
		[Required]
		public Guid Id { get; set; }
		[Required]
		[Display(Name = "Customer")]
		public Guid CustomerId { get; set; }
		[Required]
		[Display(Name = "Start")]
		public DateTime StartDate { get; set; }
		[Display(Name = "End Date")]
		public DateTime? EndDate { get; set; }
		[Required]
		[Display(Name = "Rate", Prompt = "Rate place")]
		public string Rate { get; set; }
		[Display(Name = "Description", Prompt = "Description place")]
		public string Description { get; set; }
	}
}
