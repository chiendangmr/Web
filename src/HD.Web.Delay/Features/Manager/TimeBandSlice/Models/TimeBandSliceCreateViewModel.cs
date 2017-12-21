using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TimeBandSliceCreateViewModel
	{
		[Required]
		public Guid TimeBandId { get; set; }
		[Required]
		[Display(Name="Name", Prompt ="Name place")]
		public string Name { get; set; }
		public TimeBandSliceDescriptionCreateViewModel Description { get; set; }
		public TimeBandSliceDurationCreateViewModel Duration { get; set; }
	}
}
