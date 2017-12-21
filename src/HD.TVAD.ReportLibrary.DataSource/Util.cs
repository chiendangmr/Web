using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary
{
	public static class Util
	{
		public static string GetTextDate(DateTime date)
		{
			var dayOfWeek = date.DayOfWeek;
			var dayOfWeekText = "";
			switch (dayOfWeek)
			{
				case DayOfWeek.Sunday:
					dayOfWeekText = "CHỦ NHẬT";
					break;
				case DayOfWeek.Monday:
					dayOfWeekText = "THỨ HAI";
					break;
				case DayOfWeek.Tuesday:
					dayOfWeekText = "THỨ BA";
					break;
				case DayOfWeek.Wednesday:
					dayOfWeekText = "THỨ TƯ";
					break;
				case DayOfWeek.Thursday:
					dayOfWeekText = "THỨ NĂM";
					break;
				case DayOfWeek.Friday:
					dayOfWeekText = "THỨ SÁU";
					break;
				case DayOfWeek.Saturday:
					dayOfWeekText = "THỨ BẢY";
					break;
				default:
					break;
			}
			var dateText = date.ToString("dd/MM/yyyy");
			return dayOfWeekText + " " + dateText;
		}
	}
}
