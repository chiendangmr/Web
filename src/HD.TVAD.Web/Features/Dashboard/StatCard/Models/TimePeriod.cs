using System;

namespace HD.TVAD.Web.Models
{
	public class TimePeriod
	{
		public DateTime Date { get; set; }
		public DateTime FromDate { get; set; }
		public DateTime ToDate { get; set; }
		public TimePeriodType Type { get; set; }
	}

	public enum TimePeriodType
	{
		Day,
		Week,
		Month,
	//	ThreeMonth,
		Year,
	}
}