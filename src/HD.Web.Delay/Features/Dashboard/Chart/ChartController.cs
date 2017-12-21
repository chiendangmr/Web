using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Features.Dashboard.Chart;
using HD.TVAD.Web.Features.Manager;
using HD.TVAD.Web.Models;
using HD.TVAD.Web.Services;
using HD.TVAD.Services.PriceCalculation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HD.TVAD.ApplicationCore.Entities.Booking;
using Microsoft.Extensions.Localization;

namespace HD.TVAD.Web.Dashboard
{
    [Area("Dashboard")]
	[Authorize]
	public class ChartController : TVADController
	{
		private readonly ISpotService _spotService;
		private readonly IPriceCalculationService _priceCalculationService;
		private IStringLocalizer<ChartController> _localizer;
		public ChartController(
			ISpotService spotService,
			IPriceCalculationService priceCalculationService,
			IStringLocalizer<ChartController> localizer
			)
		{
			_spotService = spotService;
			_priceCalculationService = priceCalculationService;
			_localizer = localizer;
		}
		public async Task<IActionResult> IndexAsync(TimePeriod timePeriod)
		{
			timePeriod.Date = timePeriod.ToDate;
			var timePeriodHelper = new TimePeriodHelper(timePeriod);


			var values = new Dictionary<string, ICollection<decimal>>();
			List<decimal> bookingValues, retailValues, inProgramValues, outProgramValues;
			bookingValues = retailValues = inProgramValues = outProgramValues = new List<decimal>();
			switch (timePeriod.Type)
			{
				case TimePeriodType.Day:
					bookingValues = GetDaysListValue(timePeriod, BookingTypeEnum.Contract_Booking);
					retailValues = GetDaysListValue(timePeriod, BookingTypeEnum.Retail);
					inProgramValues = GetDaysListValue(timePeriod, BookingTypeEnum.Contract_Sponsor_InProgram);
					outProgramValues = GetDaysListValue(timePeriod, BookingTypeEnum.Contract_Sponsor_OutProgram);
					break;
				case TimePeriodType.Week:
					bookingValues = GetWeekListValue(timePeriod, BookingTypeEnum.Contract_Booking);
					retailValues = GetWeekListValue(timePeriod, BookingTypeEnum.Retail);
					inProgramValues = GetWeekListValue(timePeriod, BookingTypeEnum.Contract_Sponsor_InProgram);
					outProgramValues = GetWeekListValue(timePeriod, BookingTypeEnum.Contract_Sponsor_OutProgram);
					break;
				case TimePeriodType.Month:
					bookingValues = GetListValue(timePeriod, BookingTypeEnum.Contract_Booking);
					retailValues = GetListValue(timePeriod, BookingTypeEnum.Retail);
					inProgramValues = GetListValue(timePeriod, BookingTypeEnum.Contract_Sponsor_InProgram);
					outProgramValues = GetListValue(timePeriod, BookingTypeEnum.Contract_Sponsor_OutProgram);
					break;
				case TimePeriodType.Year:
					break;
				default:
					break;
			}

			values.Add("booking", bookingValues);
			values.Add("inProgram", inProgramValues);
			values.Add("outProgram", outProgramValues);
			values.Add("retail", retailValues);


			var model = new ChartViewModel() { };
			model.data.Add(
				new KeyValuePair<string, ChartData>(
					"line",
					new ChartData()
					{
						labels = timePeriodHelper.PeriodLabels,
						datasets = new ChartDataSet[] {
							new ChartDataSet(){
								label = _localizer["Booking"].Value,
								data = values["booking"],
								backgroundColor = "rgba(153,255,51,0.4)",
							},
							new ChartDataSet(){
								label = _localizer["InProgram"].Value,
								data = values["inProgram"],
								backgroundColor = "rgba(231,76,60,0.4)",
							},
							new ChartDataSet(){
								label = _localizer["OutProgram"].Value,
								data = values["outProgram"],
								backgroundColor = "rgba(52,152,219,0.4)",
							},
							new ChartDataSet(){
								label = _localizer["Retail"].Value,
								data = values["retail"],
								backgroundColor = "rgba(255,153,0,0.4)",
							},
						},
					}));
			return PartialView(model);
		}

		private IQueryable<SpotBooking> GetBookings(DateTime fromDate, DateTime toDate, BookingTypeEnum bookingType)
		{
			var spots = _spotService.GetAll()
				.Where(s => s.BroadcastDate >= fromDate && s.BroadcastDate <= toDate);
			var bookings = spots.SelectMany(s => s.SpotBookings
													.Where(sb => sb.AnnexContractAsset.AnnexContract.BookingTypeId == (int)bookingType));
			return bookings;
		}
		private TimePeriodHelper GetFromDateToDateThisMonth(DateTime date)
		{
			var timePeriod = new TimePeriod()
			{
				Date = date,
				Type = TimePeriodType.Month,
			};
			var timePeriodHelper = new TimePeriodHelper(timePeriod);
			return timePeriodHelper;
		}
		private TimePeriodHelper GetFromDateToDateThisWeek(DateTime date)
		{
			var timePeriod = new TimePeriod()
			{
				Date = date,
				Type = TimePeriodType.Week,
			};
			var timePeriodHelper = new TimePeriodHelper(timePeriod);
			return timePeriodHelper;
		}
		private decimal? getValueOfBooking(SpotBooking booking)
		{
			return _priceCalculationService.GetTotalAfterDiscount(booking);
		}
		private List<decimal> GetListValue(TimePeriod timePeriod, BookingTypeEnum bookingType) {

			var values = new List<decimal>();
			for (int i = TimePeriodHelper.PeriodCount; i >= 0; i--)
			{
				var lastMonth = timePeriod.Date.AddMonths(-i);
				var dateHelper = GetFromDateToDateThisMonth(lastMonth);
				var bookings = GetBookings(dateHelper.FromDate, dateHelper.ToDate, bookingType);
				var total = bookings.Sum(b => getValueOfBooking(b));
				values.Add(total.Value);
			}
			return values;
		}
		private List<decimal> GetWeekListValue(TimePeriod timePeriod, BookingTypeEnum bookingType)
		{

			var values = new List<decimal>();
			for (int i = TimePeriodHelper.PeriodCount; i >= 0; i--)
			{
				var lastWeek = timePeriod.Date.AddDays(-i * 7);
				var dateHelper = GetFromDateToDateThisWeek(lastWeek);
				var bookings = GetBookings(dateHelper.FromDate, dateHelper.ToDate, bookingType);
				var total = bookings.Sum(b => getValueOfBooking(b));
				values.Add(total.Value);
			}
			return values;

		}
		private List<decimal> GetDaysListValue(TimePeriod timePeriod, BookingTypeEnum bookingType)
		{
			var values = new List<decimal>();
			for (int i = TimePeriodHelper.PeriodCount; i >= 0; i--)
			{
				var lastDay = timePeriod.Date.AddDays(-i);
				var bookings = GetBookings(lastDay, lastDay, bookingType);
				var total = bookings.Sum(b => getValueOfBooking(b).GetValueOrDefault());
				values.Add(total);
			}
			return values;

		}
	}
}