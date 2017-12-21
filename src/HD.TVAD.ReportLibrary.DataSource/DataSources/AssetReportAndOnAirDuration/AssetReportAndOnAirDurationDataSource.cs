using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.AssetReportAndOnAirDuration
{
	public class AssetReportAndOnAirDurationDataSource : DataSource<AssetReportAndOnAirDurationViewModel>
	{
		public AssetReportAndOnAirDurationDataSource(IServiceProvider serviceProvider, AssetReportAndOnAirDurationParameter parameter,Guid channelId, DateTime date)
		{

			var spotService = serviceProvider.GetService(typeof(ISpotService)) as ISpotService;
			var parameterHelper = new ParameterHelper<AssetReportAndOnAirDurationParameter>(parameter);

			var spots = spotService.GetAll()
				.Where(s => parameterHelper.IsFromDateToDate ?
				s.BroadcastDate >= parameterHelper.FromDate && s.BroadcastDate <= parameterHelper.ToDate
				: s.BroadcastDate == date)
				.ToList()
				.Where(s => s.ChannelId == channelId);
			var firstDayOfMonth = new DateTime();
			if (parameterHelper.IsFromDateToDate)
				firstDayOfMonth = parameterHelper.FromDate.AddDays(1 - parameterHelper.FromDate.Day);
			else
				firstDayOfMonth = date.AddDays(1 - date.Day);

			var spotsFromFirstDayOfMonth = spotService.GetAll()
				.Where(s => parameterHelper.IsFromDateToDate ?
				s.BroadcastDate >= firstDayOfMonth && s.BroadcastDate <= parameterHelper.ToDate
				: s.BroadcastDate >= firstDayOfMonth && s.BroadcastDate <= date)
				.ToList()
				.Where(s => s.ChannelId == channelId);

			var bookings = spots.SelectMany(s => s.SpotBookings);
			var bookingsFromFirstDayOfMonth = spotsFromFirstDayOfMonth
				.SelectMany(s => s.SpotBookings)
				.Where(s => parameter.IsApproved ? s.IsApproved : true);

			var groups = bookings
				.Where(s => parameter.IsApproved ? s.IsApproved : true)
				.GroupBy(b => b.Spot.TimeBandName);

			foreach (var group in groups)
			{
				var duration = 0;
				var freeDuration = 0;
				foreach (var booking in group)
				{
					if (booking.IsFreeBooking)
						freeDuration += booking.AssetDuration;
					else
						duration += booking.AssetDuration;
				}

				var freeInMonthDuration = 0;
				var inMonthDuration = 0;
				var bookingsOfTimeBand = bookingsFromFirstDayOfMonth.Where(s => s.Spot.TimeBandName == group.Key);
				foreach (var booking in bookingsOfTimeBand)
				{
					if (booking.IsFreeBooking)
						freeInMonthDuration += booking.AssetDuration;
					else
						inMonthDuration += booking.AssetDuration;
				}

				Data.Add(new AssetReportAndOnAirDurationViewModel() // demo
				{
					Duration = duration,
					FreeDuration = freeDuration,
					FreeInMonthDuration = freeInMonthDuration,
					InMonthDuration = inMonthDuration,
					TimeBandName = group.Key,
				});
			}
		}
	}
}
