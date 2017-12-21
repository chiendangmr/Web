using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class PositionRateCreateViewModel
	{
		[Display(Name = "TimeBand")]
		public Guid? TimeBandId { get; set; }
		[Required]
		[Display(Name = "Start Date")]
		public DateTime StartDate { get; set; }
		[Display(Name = "End Date")]
		public DateTime? EndDate { get; set; }
		[Required]
		[Display(Name = "Rate", Prompt ="Rate place")]
		[Range(0, 100)]
		public decimal Rate { get; set; }
	}
}
