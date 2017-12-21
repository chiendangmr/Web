using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TimeBandPriceCreateViewModel
	{
		public Guid Id { get; set; }
		[Display(Name = "TimeBand")]
		public Guid TimeBandId { get; set; }
		[Display(Name = "Block")]
		public Guid? SpotBlockId { get; set; }
		[Display(Name = "Start Date")]
		public DateTime StartDate { get; set; }
		[Display(Name = "Price", Prompt = "Price place")]
		[Range(0, int.MaxValue)]
		public decimal Price { get; set; }
	}
}
