using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Services.PriceCalculation;
using HD.TVAD.Web.Features.Dashboard.Chart;
using HD.TVAD.Web.Features.Manager;
using HD.TVAD.Web.Models;
using HD.TVAD.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Dashboard
{
    [Area("Dashboard")]
	[Authorize]
	public class StatCardController : TVADController
	{
		private ISpotService _spotService;
		private readonly IPriceCalculationService _priceCalculationService;

		public StatCardController(
			ISpotService spotService,
			IPriceCalculationService priceCalculationService
			)
		{
			_spotService = spotService;
			_priceCalculationService = priceCalculationService;
		}
		public async Task<IActionResult> IndexAsync(TimePeriod timePeriod)
		{
			timePeriod.Date = timePeriod.ToDate;
			var timePeriodHelper = new TimePeriodHelper(timePeriod);

			decimal currentBookingCount, prevBookingCount,
				currentAssetCount, prevAssetCount,
				currentDurationCount, prevDurationCount,
				currentValueCount, prevValueCount;
			currentBookingCount = prevBookingCount
				= prevAssetCount = currentAssetCount
				= currentDurationCount = prevDurationCount
				= currentValueCount = prevValueCount
				= 0M;
			var currentBookings = Enumerable.Empty<SpotBooking>().AsQueryable();
			var prevBookings = Enumerable.Empty<SpotBooking>().AsQueryable();
			switch (timePeriod.Type)
			{
				case TimePeriodType.Day:
					prevBookings = GetBookings(timePeriodHelper.YesterdayDate, timePeriodHelper.YesterdayDate);
					currentBookings = GetBookings(timePeriod.Date, timePeriod.Date);

					break;
				case TimePeriodType.Week:

					currentBookings = GetBookings(timePeriodHelper.FromDate, timePeriodHelper.ToDate);
					prevBookings = GetBookings(timePeriodHelper.LastFromDate, timePeriodHelper.LastToDate);


					break;
				case TimePeriodType.Month:

					currentBookings = GetBookings(timePeriodHelper.FromDate, timePeriodHelper.ToDate);
					prevBookings = GetBookings(timePeriodHelper.LastFromDate, timePeriodHelper.LastToDate);

					break;
				case TimePeriodType.Year:
					break;
				default:
					break;
			}

			currentBookingCount = currentBookings.Count();
			prevBookingCount = prevBookings.Count();

			currentAssetCount = GetAssetCountsOfBookings(currentBookings);
			prevAssetCount = GetAssetCountsOfBookings(prevBookings);

			currentDurationCount = GetSumDurationOfBookings(currentBookings);
			prevDurationCount = GetSumDurationOfBookings(prevBookings);

			currentValueCount = GetSumValueOfBookings(currentBookings).GetValueOrDefault();
			prevValueCount = GetSumValueOfBookings(prevBookings).GetValueOrDefault();

			var changePercentBooking = GetChangePercent(currentBookingCount, prevBookingCount);
			var changePercentAssetCount = GetChangePercent(currentAssetCount, prevAssetCount);
			var changePercentDurationCount = GetChangePercent(currentDurationCount, prevDurationCount);
			var changePercentValueCount = GetChangePercent(currentValueCount, prevValueCount);

			var model = new StatCardViewModel() { };
			model.StatCards.Add(
				new KeyValuePair<string, StatInfo>(
					"Booking",
					new StatInfo()
					{
						Count = currentBookingCount,
						Change = changePercentBooking,
					})
			);
			model.StatCards.Add(
				new KeyValuePair<string, StatInfo>(
					"Asset",
					new StatInfo()
					{
						Count = currentAssetCount,
						Change = changePercentAssetCount,
					})
			);
			model.StatCards.Add(
				new KeyValuePair<string, StatInfo>(
					"Duration",
					new StatInfo()
					{
						Count = currentDurationCount,
						Change = changePercentDurationCount,
					})
			);
			model.StatCards.Add(
				new KeyValuePair<string, StatInfo>(
					"Value",
					new StatInfo()
					{
						Count = currentValueCount,
						Change = changePercentValueCount,
					})
			);
			return PartialView(model);
		}
		private IQueryable<SpotBooking> GetBookings(DateTime fromDate, DateTime toDate)
		{
			var spots = _spotService.GetAll()
				.Where(s => s.BroadcastDate >= fromDate && s.BroadcastDate <= toDate);
			var bookings = spots.SelectMany(s => s.SpotBookings);

			return bookings;
		}
		private int GetAssetCountsOfBookings(IQueryable<SpotBooking> bookings)
		{
			var group = bookings.GroupBy(b => b.AnnexContractAsset.ContentId);

			return group.Count();
		}
		private int GetSumDurationOfBookings(IQueryable<SpotBooking> bookings)
		{
			var result = bookings.Sum(b => b.AnnexContractAsset.Content.BlockDuration);
			return result;
		}
		private decimal? GetSumValueOfBookings(IQueryable<SpotBooking> bookings)
		{
			var result = bookings.Sum(b => getValueOfBooking(b));
			return result;
		}
		private decimal GetChangePercent(decimal current, decimal prev)
		{
			if (current == 0)
				return 0;
			var changePercent = (current - prev) / current * 100;
			var change = Math.Floor(changePercent);
			return change;
		}
		private decimal? getValueOfBooking(SpotBooking booking)
		{
			return _priceCalculationService.GetTotalAfterDiscount(booking);
		}
	}

}