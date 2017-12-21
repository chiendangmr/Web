using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TimeBandBaseScheduleTemplateEditViewModel
	{
		[Required]
		public Guid Id { get; set; }
		[Required]
		public Guid TemplateId { get; set; }
		public Guid TimeBandBaseId { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }
	}
}
