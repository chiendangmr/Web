using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class SpotBlockRateViewModel
	{
		public Guid Id { get; set; }
		[Display(Name = "SpotBlock")]
		public Guid? SpotBlockId { get; set; }
		[Display(Name = "Duration")]
		public int SpotBlockDuration { get; set; }
		[Display(Name = "Start Date")]
		public DateTime StartDate { get; set; }
		[Display(Name = "Rate")]
		[Range(0, Int32.MaxValue)]
		public decimal Rate { get; set; }
		[Display(Name = "Description")]
		public string Description { get; set; }
	}
}
