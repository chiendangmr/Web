using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class SpotBlockRateCreateViewModel
	{
		[Required]
		[Display(Name = "SpotBlock")]
		public Guid SpotBlockId { get; set; }
		[Required]
		[Display(Name = "Start Date")]
		public DateTime StartDate { get; set; }
		[Required]
		[Display(Name = "Rate", Prompt ="Rate place")]
		[Range(0,Int32.MaxValue)]
		public string Rate { get; set; }
		[Display(Name = "Description", Prompt ="Description place")]
		public string Description { get; set; }
	}
}
