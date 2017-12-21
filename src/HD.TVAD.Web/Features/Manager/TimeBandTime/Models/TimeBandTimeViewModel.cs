using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TimeBandTimeViewModel
	{
		public Guid Id { get; set; }
		public Guid TimeBandId { get; set; }
		[Required]
		[Display(Name = "Start Date", Prompt = "Start Date place")]
		public DateTime StartDate { get; set; }
		[Display(Name = "End Date", Prompt = "End Date place")]
		public DateTime? EndDate { get; set; }
		[Required]
		[Display(Name = "Start Time", Prompt = "Start Time")]
		public TimeSpan StartTimeOfDay { get; set; }
		[Required]
		public int Duration { get; set; }
		[Required]
		[Display(Name = "End Time", Prompt = "End Time")]
		public TimeSpan EndTime { get; set; }
		[Display(Name = "Next Day", Prompt = "Next Day")]
		public bool NextDay { get; set; }

	}
}
