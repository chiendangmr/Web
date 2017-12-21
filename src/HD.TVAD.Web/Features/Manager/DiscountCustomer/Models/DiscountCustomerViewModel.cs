using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class DiscountCustomerViewModel
	{
		public Guid Id { get; set; }
		[Display(Name = "Customer")]
		public Guid CustomerId { get; set; }
		[Display(Name = "Customer")]
		public string CustomerName { get; set; }
		[Display(Name = "Customer")]
		public string CustomerCode { get; set; }
		[Display(Name = "Start")]
		public DateTime StartDate { get; set; }
		[Display(Name = "End Date")]
		public DateTime? EndDate { get; set; }
		[Display(Name = "Rate", Prompt = "Rate place")]
		[Range(0, 100)]
		public decimal Rate { get; set; }
		[Display(Name = "Description", Prompt = "Description place")]
		public string Description { get; set; }
	}
}
