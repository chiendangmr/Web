using HD.TVAD.ReportLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Reporting.Helper
{
    public class ParameterHelper<TParameter> where TParameter : Parameter
	{
		public ParameterHelper(TParameter parameter)
		{
			//		var type = typeof(TParameter);
			//		var typeofPeriodDaySelect = type.GetProperty("IsMonthOrFromDaySelect").PropertyType.GetGenericArguments()[0];
			switch (parameter.IsMonthOrFromDaySelect)
			{
				case Period.All:
					IsAllTime = true;
					FromDate = new DateTime(2000, 1, 1);
					ToDate = DateTime.Today;
					TimePeriod = "TẤT CẢ PS";
					break;
				case Period.Month:
					if (parameter.IsMonthOrThreeMount)
					{

						var lastDayOfThisMonth = DateTime.DaysInMonth(parameter.Year, parameter.Month);
						FromDate = new DateTime(parameter.Year, parameter.Month, 1);
						ToDate = new DateTime(parameter.Year, parameter.Month, lastDayOfThisMonth);
					}
					else
					{
						switch (parameter.ThreeMonth)
						{
							case ThreeMonth.Fisrt:
								var lastDayOfMarch = DateTime.DaysInMonth(parameter.Year, 3);
								FromDate = new DateTime(parameter.Year, 1, 1);
								ToDate = new DateTime(parameter.Year,3, lastDayOfMarch);
								break;
							case ThreeMonth.Second:
								var lastDayOfJul = DateTime.DaysInMonth(parameter.Year, 6);
								FromDate = new DateTime(parameter.Year, 4, 1);
								ToDate = new DateTime(parameter.Year, 6, lastDayOfJul);
								break;
							case ThreeMonth.Third:
								var lastDayOfSeptempber = DateTime.DaysInMonth(parameter.Year, 9);
								FromDate = new DateTime(parameter.Year, 7, 1);
								ToDate = new DateTime(parameter.Year, 9, lastDayOfSeptempber);
								break;
							case ThreeMonth.Foutth:
								var lastDayOfYear = DateTime.DaysInMonth(parameter.Year, 12);
								FromDate = new DateTime(parameter.Year, 10, 1);
								ToDate = new DateTime(parameter.Year, 12, lastDayOfYear);
								break;
							default:
								break;
						}
					}

					TimePeriod = "Trong tháng " + parameter.Month.ToString() + "/" + parameter.Year.ToString() ;

					break;
				case Period.FromDate:
					IsFromDateToDate = true;
					FromDate = parameter.FromDate;
					ToDate = parameter.ToDate;
					TimePeriod = "Từ ngày " + FromDate.ToString("dd/MM/yyyy") + " đến " + ToDate.ToString("dd/MM/yyyy");
					break;
				case Period.OneDate:
					FromDate = parameter.Date;
					ToDate = parameter.Date;
					TimePeriod = $"Ngày {parameter.Date.ToString("dd/MM/yyyy")}";
					break;
				case Period.ChooseDate:
					IsChooseDates = true;
					FromDate = parameter.FromDate;
					ToDate = parameter.ToDate;
					break;
				default:
					break;
			}

			var today = DateTime.Today;
			TodayDay = today.Day;
			TodayMonth = today.Month;
			TodayYear = today.Year;
		}
		public DateTime FromDate;
		public DateTime ToDate;
		public int TodayDay;
		public int TodayMonth;
		public int TodayYear;
		public bool IsAllTime;
		public bool IsFromDateToDate;
		public bool IsChooseDates;
		public string TimePeriod;
	}
}
