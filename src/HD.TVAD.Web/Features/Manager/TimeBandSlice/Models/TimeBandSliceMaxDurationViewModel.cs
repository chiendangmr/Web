using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TimeBandSliceMaxDurationViewModel
	{
		public int? MaxDuration { get; set; }
		public Guid? MaxDurationId { get; set; }
		public ICollection<TimeBandSliceDurationByTypeViewModel> TimeBandSliceDurationByTypes { get; set; }
	}
}
