using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TimeBandBaseScheduleTemplateCreateViewModel
	{
		[Required]
		public Guid TemplateId { get; set; }
		[Required]
		[Display(Name = "TimeBand Base", Prompt = "TimeBand Base")]
		public Guid TimeBandBaseId { get; set; }
		[Required]
		[Display(Name = "Start Date", Prompt = "Start Date")]
		public DateTime StartDate { get; set; }
		[Display(Name = "End Date", Prompt = "End Date")]
		public DateTime? EndDate { get; set; }
	}
}
