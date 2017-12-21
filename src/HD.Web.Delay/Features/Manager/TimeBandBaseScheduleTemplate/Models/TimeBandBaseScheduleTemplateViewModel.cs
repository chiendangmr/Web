using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TimeBandBaseScheduleTemplateViewModel
	{
		[Required]
		public Guid Id { get; set; }
		public Guid TemplateId { get; set; }
		public Guid TimeBandBaseId { get; set; }
		public string TimeBandBaseName { get; set; }
		[Display(Name = "Start Date", Prompt = "Start Date")]
		public DateTime StartDate { get; set; }
		[Display(Name = "End Date", Prompt = "End Date")]
		public DateTime? EndDate { get; set; }
	}
}
