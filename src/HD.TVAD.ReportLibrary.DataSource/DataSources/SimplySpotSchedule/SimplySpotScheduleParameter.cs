using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HD.TVAD.ReportLibrary
{
    public class SimplySpotScheduleParameter
    {
		[Required]
		[Display(Name = "Broadcast Date")]
		public DateTime? BroadcastDate {get; set; }
		[Display(Name = "Is Approved")]
		public bool IsApproved { get; set; }
	}
}
