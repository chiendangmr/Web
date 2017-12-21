using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary
{
	public class CheckSpotDurationParameter : Parameter
	{
		[Display(Name = "Channel")]
		public Guid? ChannelId { get; set; }
		[Display(Name = "TimeBand")]
		public Guid? TimeBandId { get; set; }
		[Display(Name = "TimeBand Slice")]
		public Guid? TimeBandSliceId { get; set; }		

	}
}