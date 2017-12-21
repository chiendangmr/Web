using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TimeBandSliceDescriptionEditViewModel
	{
		[Required]
		public Guid Id { get; set; }
		[Required]
		public Guid TimeBandSliceId { get; set; }
		[Required]
		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		[Required]
		public string Description { get; set; }

	}
}
