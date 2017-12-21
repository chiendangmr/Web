using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TimeBandSliceDetailIndexViewModel
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public Guid TimeBandId { get; set; }
		public Guid TimeBandSliceId { get; set; }

	}
}
