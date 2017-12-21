using HD.TVAD.Web.Features.Manager.TimeBands;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web
{
	public static class TimeBandUtil
	{

		public static int ConvertDayOfWeekViewToSumInt(DayOfWeekViewModel dayOfWeeks)
		{
			var sum = 0;
			if (dayOfWeeks.Monday)
			{
				sum += (int)VisibleDayOfWeek.Mon;
			}
			if (dayOfWeeks.Tuesday)
			{
				sum += (int)VisibleDayOfWeek.Tue;
			}
			if (dayOfWeeks.Wednesday)
			{
				sum += (int)VisibleDayOfWeek.Wed;
			}
			if (dayOfWeeks.Thursday)
			{
				sum += (int)VisibleDayOfWeek.Thu;
			}
			if (dayOfWeeks.Friday)
			{
				sum += (int)VisibleDayOfWeek.Fri;
			}
			if (dayOfWeeks.Saturday)
			{
				sum += (int)VisibleDayOfWeek.Sat;
			}
			if (dayOfWeeks.Sunday)
			{
				sum += (int)VisibleDayOfWeek.Sun;
			}
			return sum;
		}
		public static DayOfWeekViewModel ConvertDayOfWeekEnumToDayOfWeekViewModel(VisibleDayOfWeek dayOfWeek)
		{
			return new DayOfWeekViewModel()
			{
				Monday = dayOfWeek.HasFlag(VisibleDayOfWeek.Mon) ? true : false,
				Tuesday = dayOfWeek.HasFlag(VisibleDayOfWeek.Tue) ? true : false,
				Wednesday = dayOfWeek.HasFlag(VisibleDayOfWeek.Wed) ? true : false,
				Thursday = dayOfWeek.HasFlag(VisibleDayOfWeek.Thu) ? true : false,
				Friday = dayOfWeek.HasFlag(VisibleDayOfWeek.Fri) ? true : false,
				Saturday = dayOfWeek.HasFlag(VisibleDayOfWeek.Sat) ? true : false,
				Sunday = dayOfWeek.HasFlag(VisibleDayOfWeek.Sun) ? true : false,
			};
		}
		public static int ConvertDurationTimeToInt(TimeSpan start, TimeSpan end, bool nextDay) {
			
			var duration = 0;
			if (!nextDay)
			{
				var durationTimeSpan = end - start;
				duration = (int)durationTimeSpan.TotalSeconds;
			}
			else
			{
				var durationLeftTo24h = new TimeSpan(24, 0, 0) - start;
				var durationTimeSpan = durationLeftTo24h + end;
				duration = (int)durationTimeSpan.TotalSeconds;
			}

			return duration;
		}
	}
}
