using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class RateSpotBlockCreateViewModel
	{
		[Required]
		[Display(Name = "Name",Prompt = "Name place")]
		public string Name { get; set; }
		[Required]
		[Display(Name = "Type")]
		public int TypeId { get; set; }
		[Required]
		[Display(Name = "Block")]
		public Guid SpotBlockId { get; set; }
		[Display(Name = "Rate", Prompt ="Rate place")]
		[Range(0, 100)]
		public decimal? Rate { get; set; }
	}
}
