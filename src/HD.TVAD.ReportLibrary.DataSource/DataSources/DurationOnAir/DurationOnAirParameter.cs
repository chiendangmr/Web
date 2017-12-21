using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary
{
	public class DurationOnAirParameter : Parameter
	{
		[Display(Name = "Type")]
		public int Type { get; set; }

		[Display(Name = "Is Approved")]
		public bool IsApproved { get; set; }

		public bool IsByValueOrDuration { get; set; }
		[Display(Name = "Report Without Discount")]
		public bool ReportWithoutDiscount { get; set; }
		
		/// <summary>
		/// 0 : all, 1: Exclude retail: only retail
		/// </summary>
		public int IncludeRetailBooking { get; set; }
	}
}