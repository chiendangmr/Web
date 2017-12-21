using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HD.TVAD.ReportLibrary
{
	public class Parameter
	{
		/// <summary>
		/// 0: all, 1: month: 2, fromdate, 3: choose date
		/// </summary>
		public Period IsMonthOrFromDaySelect { get; set; }
		[Display(Name = "Year")]
		public int Year { get; set; }
		[Display(Name = "Month")]
		public int Month { get; set; }
		public bool IsMonthOrThreeMount { get; set; }
		/// <summary>
		/// Quý
		/// </summary>
		[Display(Name = "TheeMonth")]
		public ThreeMonth ThreeMonth { get; set; }

		[Display(Name = "From Date")]
		public DateTime FromDate { get; set; }
		[Display(Name = "To Date")]
		public DateTime ToDate { get; set; }


		public IEnumerable<DateTime> ChooseDates { get; set; }
		[Display(Name = "Date")]
		public DateTime Date { get; set; }
	}
}