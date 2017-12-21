using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class PositionRateEditViewModel
	{
		public Guid Id { get; set; }
		public Guid? TimeBandId { get; set; }
		[Required]
		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		[Required]
		[DisplayFormat(ApplyFormatInEditMode = false)]
		[Display(Name = "Rate", Prompt = "Rate place")]
		public string Rate { get; set; }
	}
}
