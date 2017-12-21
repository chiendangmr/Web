using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class SpotBookingSearchIndexViewModel
	{
		[Display(Name = "From Date")]
		public DateTime? FromDate { get; set; }
		[Display(Name = "To Date")]
		public DateTime? ToDate { get; set; }
		[Display(Name = "TimeBand")]
		public Guid? TimeBandId { get; set; }
		[Display(Name = "TimeBand Slice")]
		public Guid? TimeBandSliceId { get; set; }
	}
}
