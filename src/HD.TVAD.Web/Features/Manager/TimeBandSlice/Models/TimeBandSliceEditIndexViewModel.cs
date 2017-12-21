using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Models
{
    public class TimeBandSliceEditIndexViewModel
	{
		public Guid Id { get; set; }
		public int? DisplayOrder { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int? MaxDuration { get; set; }
		public int? DurationExceeded { get; set; }
		public int? DateNotExceeded { get; set; }
		public DateTime? FromDate { get; set; }
		public DateTime? ToDate { get; set; }
		public int? MaxDurationSponsor { get; set; }
		public int? MaxDurationAds { get; set; }
		public int? MaxDurationSponsored { get; set; }
		public int? MaxDurationAdsed { get; set; }
		public Guid TimeBandId { get; set; }

	}
}
