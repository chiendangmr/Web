using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TimeBandDayCreateViewModel
	{
		[Required]
		public Guid TimeBandId { get; set; }
		[Required]
		[Display(Name = "Start Date", Prompt = "Start Date place")]
		public DateTime StartDate { get; set; }
		[Display(Name = "End Date", Prompt = "End Date place")]
		public DateTime? EndDate { get; set; }
		[Display(Name = "Day Of Week", Prompt = "Day Of Week")]
		public int DayOfWeeks { get; set; }
		[Required]
		public DayOfWeekViewModel DayOfWeekView { get; set; }

	}
}
