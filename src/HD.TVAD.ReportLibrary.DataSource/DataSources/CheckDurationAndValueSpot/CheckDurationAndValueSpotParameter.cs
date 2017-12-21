using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary
{
	public class CheckDurationAndValueSpotParameter : Parameter
	{
		[Display(Name = "Channel")]
		public Guid? ChannelId { get; set; }
		[Display(Name = "TimeBand")]
		public Guid? TimeBandId { get; set; }
		[Display(Name = "TimeBand Slice")]
		public Guid? TimeBandSliceId { get; set; }



		[Display(Name = "Is Approved")]
		public bool IsApproved { get; set; }

		[Display(Name = "Is By Value Or Duration")]
		public bool IsByValueOrDuration { get; set; }
	}
}
