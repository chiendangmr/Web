using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary
{
	public class SpotReportByOneTimeBandParameter : Parameter
	{
		[Display(Name = "Type")]
		public int Type { get; set; }

		[Display(Name = "Is Approved")]
		public bool IsApproved { get; set; }

		public bool IsByValueOrDuration { get; set; }
		

		public DayOfWeekViewModel DayOfWeek { get; set; }

		[Display(Name = "TimeBand")]
		public Guid TimeBandId { get; set; }
		[Display(Name = "TimeBandSlice")]
		public IEnumerable<Guid> TimeBandSliceIds { get; set; }
		/// <summary>
		/// The hien theo tung cut
		/// </summary>
		[Display(Name = "View By Cut")]
		public bool ViewByCut { get; set; }
	}
}
