using HD.TVAD.Web.Features.Dashboard.Chart;
using HD.TVAD.Web.Features.Dashboard.StatCard;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Dashboard.Chart
{
	public class TimePeriodHelper
	{
		public const int PeriodCount = 6; // 7 
		public DateTime FromDate { get; set; }
		public DateTime ToDate { get; set; }
		public DateTime LastFromDate { get; }
		public DateTime LastToDate { get; }
		public DateTime YesterdayDate { get; }
		public ICollection<string> PeriodLabels { get; } = new List<string>();
		public TimePeriodHelper()
		{

		}
		public TimePeriodHelper(TimePeriod timePeriod)
		{
			switch (timePeriod.Type)
			{
				case TimePeriodType.Day:
					YesterdayDate = timePeriod.Date.AddDays(-1);
					for (int i = PeriodCount; i >= 0; i--)
					{
						var lastDay = timePeriod.Date.AddDays(-i);
						PeriodLabels.Add(DateTimeFormatInfo.CurrentInfo.GetDayName(lastDay.DayOfWeek));
					}

					break;
				case TimePeriodType.Week:
					FromDate = timePeriod.Date.GetFirstDayThisWeek();
					ToDate = timePeriod.Date.GetLastDayThisWeek();
					LastFromDate = timePeriod.Date.GetFirstDayLastWeek();
					LastToDate = timePeriod.Date.GetLastDayLastWeek();
					for (int i = PeriodCount; i >= 0; i--)
					{
						var fromDateOfWeek = FromDate.AddDays(-i * 7);
						PeriodLabels.Add($"Week {fromDateOfWeek.ToString("dd/MM")}");
					}
					break;
				case TimePeriodType.Month:
					var lastDayOfThisMonth = DateTime.DaysInMonth(timePeriod.Date.Year, timePeriod.Date.Month);
					FromDate = new DateTime(timePeriod.Date.Year, timePeriod.Date.Month, 1);
					ToDate = new DateTime(timePeriod.Date.Year, timePeriod.Date.Month, lastDayOfThisMonth);

					var fistDayThisMonth = new DateTime(timePeriod.Date.Year, timePeriod.Date.Month, 1);
					var lastDayLastMonth = fistDayThisMonth.AddDays(-1);
					var lastDayOfLastMonth = DateTime.DaysInMonth(lastDayLastMonth.Year, lastDayLastMonth.Month);
					LastFromDate = new DateTime(lastDayLastMonth.Year, lastDayLastMonth.Month, 1);
					LastToDate = new DateTime(lastDayLastMonth.Year, lastDayLastMonth.Month, lastDayOfLastMonth);

					for (int i = PeriodCount; i >= 0; i--)
					{
						var lastMonth = timePeriod.Date.AddMonths(-i);
						var monthString = lastMonth.Month.ToMonthText();
						PeriodLabels.Add(monthString);
					}

					break;
				case TimePeriodType.Year:
					break;
			}
		}

	}

	static class DateTimeExtensions
	{
		static GregorianCalendar _gc = new GregorianCalendar();
		public static int GetWeekOfMonth(this DateTime time)
		{
			DateTime first = new DateTime(time.Year, time.Month, 1);
			return time.GetWeekOfYear() - first.GetWeekOfYear() + 1;
		}

		static int GetWeekOfYear(this DateTime time)
		{
			return _gc.GetWeekOfYear(time, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
		}
	}
}