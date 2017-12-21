using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Dashboard.Chart
{
	static class MonthExtension
	{
		public static string ToMonthText(this int month) {
			var monthText = "";
			switch (month)
			{
				case 1:
					monthText = "January";
					break;
				case 2:
					monthText = "February";
					break;
				case 3:
					monthText = "Marth";
					break;
				case 4:
					monthText = "April";
					break;
				case 5:
					monthText = "May";
					break;
				case 6:
					monthText = "Jul";
					break;
				case 7:
					monthText = "July";
					break;
				case 8:
					monthText = "August";
					break;
				case 9:
					monthText = "September";
					break;
				case 10:
					monthText = "October";
					break;
				case 11:
					monthText = "November";
					break;
				case 12:
					monthText = "December";
					break;
				default:
					break;
			}
			return monthText;
		}
	}

}
