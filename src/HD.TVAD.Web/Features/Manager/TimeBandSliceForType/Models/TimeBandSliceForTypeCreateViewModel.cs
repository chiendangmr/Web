using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TimeBandSliceForTypeCreateViewModel
	{
		[Required]
		[Display(Name = "TimeBand Slice")]
		public Guid TimeBandSliceId { get; set; }
		[Required]
		[Display(Name = "Start Date")]
		public DateTime StartDate { get; set; }
		[Display(Name = "End Date")]
		public DateTime? EndDate { get; set; }
		[Required]
		[Display(Name = "Booking Type")]
		public int BookingTypeId { get; set; }
	}
}
