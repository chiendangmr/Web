using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class RateSpotBlockViewModel
	{
		public Guid Id { get; set; }
		[Display(Name = "Name")]
		public string Name { get; set; }
		[Display(Name = "Block")]
		public Guid? SpotBlockId { get; set; }
		[Display(Name = "Duration")]
		public int SpotBlockDuration { get; set; }
		[Display(Name = "Rate")]
		[Range(0, 100)]
		public decimal? Rate { get; set; }
		[Display(Name = "Type")]
		public int TypeId { get; set; }
		[Display(Name = "Type")]
		public string TypeName { get; set; }
	}
}
