using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TimeBandSliceDurationCreateViewModel
	{
		[Required]
		public Guid TimeBandSliceId { get; set; }
		[Required]
		[Display(Name = "Start Date", Prompt = "Start Date place")]
		public DateTime StartDate { get; set; }
		[Display(Name = "End Date", Prompt = "End Date place")]
		public DateTime? EndDate { get; set; }
		[Required]
		[Display(Name = "Duration", Prompt = "Duration place")]
		[Range(0,int.MaxValue)]
		public int Duration { get; set; }

	}
}
