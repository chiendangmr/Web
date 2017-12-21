using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class DiscountSponsorProgramViewModel
	{
		public Guid Id { get; set; }
		[Display(Name = "Program")]
		public Guid ProgramId { get; set; }
		[Display(Name = "Program Name")]
		public string ProgramName { get; set; }
		[Display(Name = "Start Date")]
		public DateTime StartDate { get; set; }
		[Display(Name = "End Date")]
		public DateTime? EndDate { get; set; }
		[Display(Name = "Rate", Prompt = "Rate place")]
		[Range(0, 100)]
		public decimal Rate { get; set; }
		[Display(Name = "Description", Prompt = "Description place")]
		public string Description { get; set; }
	}
}
