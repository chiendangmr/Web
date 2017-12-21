using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TimeBandSliceForTypeViewModel
    {
		public Guid Id { get; set; }
		[Display(Name = "TimeBand")]
		public Guid TimeBandId { get; set; }
		[Display(Name = "Slice")]
		public Guid TimeBandSliceId { get; set; }
		[Display(Name = "Slice")]
		public string TimeBandSliceName { get; set; }
		[Display(Name = "TimeBand")]
		public string TimeBandName { get; set; }
		[Display(Name = "Start Date")]
		public DateTime StartDate { get; set; }
		[Display(Name = "End Date")]
		public DateTime? EndDate { get; set; }
		[Display(Name = "Booking Type")]
		public int BookingTypeId { get; set; }
		[Display(Name = "Booking Type")]
		public string BookingTypeName { get; set; }
	}
}
