using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TimeBandSliceDurationByTypeViewModel
	{
		public Guid Id { get; set; }
		public Guid TimeBandSliceDurationId { get; set; }
		[Range(0, int.MaxValue)]
		[Display(Name = "Duration", Prompt = "Duration place")]
		public int Duration { get; set; }
		[Display(Name = "Booking Type", Prompt = "Booking Type place")]
		public int BookingTypeId { get; set; }
		public string BookingTypeName { get; set; }

	}
}
