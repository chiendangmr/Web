using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TimeBandSliceDurationByTypeCreateViewModel
	{
		[Required]
		public Guid TimeBandSliceDurationId { get; set; }
		[Required]
		[Range(0, int.MaxValue)]
		[Display(Name = "Duration", Prompt = "Duration place")]
		public int Duration { get; set; }
		[Required]
		[Display(Name = "Booking Type", Prompt = "Booking Type place")]
		public int BookingTypeId { get; set; }

	}
}
