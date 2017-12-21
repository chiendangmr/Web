using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TimeBandSliceDurationViewModel
	{
		public Guid Id { get; set; }
		public Guid TimeBandSliceId { get; set; }
		[Display(Name = "Start Date", Prompt = "Start Date place")]
		public DateTime StartDate { get; set; }
		[Display(Name = "End Date", Prompt = "End Date place")]
		public DateTime? EndDate { get; set; }
		[Range(0, int.MaxValue)]
		[Display(Name = "Duration", Prompt = "Duration place")]
		public int Duration { get; set; }

	}
}
