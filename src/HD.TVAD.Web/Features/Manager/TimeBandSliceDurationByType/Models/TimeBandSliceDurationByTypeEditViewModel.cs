using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TimeBandSliceDurationByTypeEditViewModel
	{
		[Required]
		public Guid Id { get; set; }
		[Required]
		public Guid TimeBandSliceDurationId { get; set; }
		[Required]
		[Range(0, int.MaxValue)]
		public int Duration { get; set; }
		public int BookingTypeId { get; set; }

	}
}
