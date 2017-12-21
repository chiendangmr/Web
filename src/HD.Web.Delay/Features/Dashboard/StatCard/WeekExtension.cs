using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Dashboard.StatCard
{
	static class WeekExtension
	{
		public static DateTime GetFirstDayThisWeek(this DateTime date)
		{
			var dayAdded = 0;
			switch (date.DayOfWeek)
			{
				case DayOfWeek.Monday:
					dayAdded = 0;
					break;
				case DayOfWeek.Tuesday:
					dayAdded = -1;
					break;
				case DayOfWeek.Wednesday:
					dayAdded = -2;
					break;
				case DayOfWeek.Thursday:
					dayAdded = -3;
					break;
				case DayOfWeek.Friday:
					dayAdded = -4;
					break;
				case DayOfWeek.Saturday:
					dayAdded = -5;
					break;
				case DayOfWeek.Sunday:
					dayAdded = -6;
					break;
				default:
					break;
			}
			return date.AddDays(dayAdded);
		}

		public static DateTime GetFirstDayLastWeek(this DateTime date)
		{
			var dayAdded = -7;
			switch (date.DayOfWeek)
			{
				case DayOfWeek.Monday:
					dayAdded += 0;
					break;
				case DayOfWeek.Tuesday:
					dayAdded += -1;
					break;
				case DayOfWeek.Wednesday:
					dayAdded += -2;
					break;
				case DayOfWeek.Thursday:
					dayAdded += -3;
					break;
				case DayOfWeek.Friday:
					dayAdded += -4;
					break;
				case DayOfWeek.Saturday:
					dayAdded += -5;
					break;
				case DayOfWeek.Sunday:
					dayAdded += -6;
					break;
				default:
					break;
			}
			return date.AddDays(dayAdded);
		}
		public static DateTime GetLastDayThisWeek(this DateTime date)
		{
			var dayAdded = 0;
			switch (date.DayOfWeek)
			{
				case DayOfWeek.Monday:
					dayAdded = 6;
					break;
				case DayOfWeek.Tuesday:
					dayAdded = 5;
					break;
				case DayOfWeek.Wednesday:
					dayAdded = 4;
					break;
				case DayOfWeek.Thursday:
					dayAdded = 3;
					break;
				case DayOfWeek.Friday:
					dayAdded = 2;
					break;
				case DayOfWeek.Saturday:
					dayAdded = 1;
					break;
				case DayOfWeek.Sunday:
					dayAdded = 0;
					break;
				default:
					break;
			}
			return date.AddDays(dayAdded);
		}
		public static DateTime GetLastDayLastWeek(this DateTime date)
		{
			var dayAdded = -7;
			switch (date.DayOfWeek)
			{
				case DayOfWeek.Monday:
					dayAdded += 6;
					break;
				case DayOfWeek.Tuesday:
					dayAdded += 5;
					break;
				case DayOfWeek.Wednesday:
					dayAdded += 4;
					break;
				case DayOfWeek.Thursday:
					dayAdded += 3;
					break;
				case DayOfWeek.Friday:
					dayAdded += 2;
					break;
				case DayOfWeek.Saturday:
					dayAdded += 1;
					break;
				case DayOfWeek.Sunday:
					dayAdded += 0;
					break;
				default:
					break;
			}
			return date.AddDays(dayAdded);
		}
	}

}
