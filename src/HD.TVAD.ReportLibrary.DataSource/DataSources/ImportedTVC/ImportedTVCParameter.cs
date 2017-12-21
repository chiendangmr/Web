using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HD.TVAD.ReportLibrary
{
	public class ImportedTVCParameter
	{
		[Required]
		[Display(Name = "Broadcast Date")]
		public DateTime BroadcastDate { get; set; }
		[Display(Name = "Channel")]
		public Guid? ChannelId { get; set; }
		[Display(Name = "TimeBand")]
		public Guid? TimeBandId { get; set; }
		[Display(Name = "Is Approved")]
		public bool IsApproved { get; set; }
	}
}
