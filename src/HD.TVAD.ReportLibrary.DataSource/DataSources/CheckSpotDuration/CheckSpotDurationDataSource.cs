using HD.TVAD.ApplicationCore.Entities.Booking;
using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.CheckSpotDuration
{
	public class CheckSpotDurationDataSource : DataSource<CheckSpotDurationViewModel>
	{
		public CheckSpotDurationDataSource(IServiceProvider serviceProvider, CheckSpotDurationParameter parameter)
		{

			var parameterHelper = new ParameterHelper<CheckSpotDurationParameter>(parameter);

			var spotService = serviceProvider.GetService(typeof(ISpotService)) as ISpotService;
			var timeBandSliceService = serviceProvider.GetService(typeof(ITimeBandSliceService)) as ITimeBandSliceService;

			var spots = spotService.GetAll().ToList()
				.Where(s => parameterHelper.IsAllTime ? true : s.BroadcastDate >= parameterHelper.FromDate && s.BroadcastDate <= parameterHelper.ToDate)
				.Where(s => parameter.ChannelId.HasValue? s.ChannelId == parameter.ChannelId.Value : true)
				.Where(s => parameter.TimeBandId.HasValue ? s.TimeBandId == parameter.TimeBandId.Value : true)
				.OrderBy(s => s.BroadcastDate)
				.ToList();


			var bookings = spots.SelectMany(s => s.SpotBookings)
				.Where(s => s.IsApproved);
			foreach (var spot in spots)
			{
				var maximumBookingDuration = timeBandSliceService.GetMaxDurationByBookingType(spot.TimeBandSliceId, spot.BroadcastDate, BookingTypeEnum.Contract_Booking);
				var maximumSponsorDuration = timeBandSliceService.GetMaxDurationByBookingType(spot.TimeBandSliceId, spot.BroadcastDate, BookingTypeEnum.Contract_Sponsor_InProgram);
				maximumSponsorDuration += timeBandSliceService.GetMaxDurationByBookingType(spot.TimeBandSliceId, spot.BroadcastDate, BookingTypeEnum.Contract_Sponsor_OutProgram);
				var usedBookingDuration = 0;
				var usedSponsorDuration = 0;
				var timeBandSliceDescription = timeBandSliceService.GetTimeBandSliceDescriptionByDate(spot.TimeBandSliceId, spot.BroadcastDate);
				foreach (var booking in spot.SpotBookings)
				{
					if (booking.IsNormalContractBooking)
					{
						usedBookingDuration += booking.AssetDuration;
					}
					if (booking.IsOutProgramBooking || booking.IsInProgramBooking)
					{
						usedSponsorDuration += booking.AssetDuration;
					}
				}

				Data.Add(new CheckSpotDurationViewModel()
				{
					Day = spot.BroadcastDate.Day,
					MaximumBookingDuration = maximumBookingDuration,
					MaximumSponsorDuration = maximumSponsorDuration,
					Month = spot.BroadcastDate.Month,
					TimeBandName = spot.TimeBandName,
					TimeBandSliceDescription = timeBandSliceDescription,
					TimeBandSliceName = spot.TimeBandSliceName,
					UsedBookingDuration = usedBookingDuration,
					UsedSponsorDuration = usedSponsorDuration,
					Year = spot.BroadcastDate.Year,
				});

			}
		}
	}
}
