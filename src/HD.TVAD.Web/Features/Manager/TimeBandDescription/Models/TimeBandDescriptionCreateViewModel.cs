using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TimeBandDescriptionCreateViewModel
	{
		[Required]
		public Guid TimeBandId { get; set; }
		[Required]
		[Display(Name = "Description", Prompt = "Description place")]
		public string Description { get; set; }
		[Required]
		[Display(Name = "Start Date", Prompt = "Start Date place")]
		public DateTime StartDate { get; set; }
		[Display(Name = "End Date", Prompt = "End Date place")]
		public DateTime? EndDate { get; set; }
	}
}
