using HD.TVAD.ApplicationCore.Entities.Booking;
using HD.TVAD.Services.PriceCalculation;
using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.CheckDurationAndValueSpot
{
	public class CheckDurationAndValueSpotDataSource : DataSource<CheckDurationAndValueSpotViewModel>
	{
		public CheckDurationAndValueSpotDataSource(IServiceProvider serviceProvider, CheckDurationAndValueSpotParameter parameter)
		{
			var parameterHelper = new ParameterHelper<CheckDurationAndValueSpotParameter>(parameter);

			var spotService = serviceProvider.GetService(typeof(ISpotService)) as ISpotService;
			var timeBandSliceService = serviceProvider.GetService(typeof(ITimeBandSliceService)) as ITimeBandSliceService;
			var priceCalculationService = serviceProvider.GetService(typeof(IPriceCalculationService)) as IPriceCalculationService;

			var spots = spotService.GetAll().ToList()
				.Where(s => parameterHelper.IsAllTime ? true : s.BroadcastDate >= parameterHelper.FromDate && s.BroadcastDate <= parameterHelper.ToDate)
				.Where(s => parameter.ChannelId.HasValue ? s.ChannelId == parameter.ChannelId.Value : true)
				.Where(s => parameter.TimeBandId.HasValue ? s.TimeBandId == parameter.TimeBandId.Value : true)
				.OrderBy(s => s.BroadcastDate)
				.ToList();


			var bookings = spots.SelectMany(s => s.SpotBookings)
				.Where(s => parameter.IsApproved? s.IsApproved: true);

			foreach (var spot in spots)
			{
				var maximumBookingDuration = timeBandSliceService.GetMaxDurationByBookingType(spot.TimeBandSliceId, spot.BroadcastDate, BookingTypeEnum.Contract_Booking);
				var maximumSponsorDuration = timeBandSliceService.GetMaxDurationByBookingType(spot.TimeBandSliceId, spot.BroadcastDate, BookingTypeEnum.Contract_Sponsor_InProgram);
				maximumSponsorDuration += timeBandSliceService.GetMaxDurationByBookingType(spot.TimeBandSliceId, spot.BroadcastDate, BookingTypeEnum.Contract_Sponsor_OutProgram);
				var usedBookingDuration = 0;
				var usedSponsorDuration = 0;
				var bookingValue = 0M;
				var sponsorValue = 0M;
				var timeBandSliceDescription = timeBandSliceService.GetTimeBandSliceDescriptionByDate(spot.TimeBandSliceId, spot.BroadcastDate);
				foreach (var booking in spot.SpotBookings
										.Where(s => parameter.IsApproved ? s.IsApproved : true))
				{
					if (booking.IsNormalContractBooking)
					{
						usedBookingDuration += booking.AssetDuration;
						bookingValue += priceCalculationService.GetTotalAfterDiscount(booking).GetValueOrDefault();
					}
					if (booking.IsOutProgramBooking || booking.IsInProgramBooking)
					{
						usedSponsorDuration += booking.AssetDuration;
						sponsorValue += priceCalculationService.GetTotalAfterDiscount(booking).GetValueOrDefault();
					}
				}
				if (parameter.IsByValueOrDuration)
				{
					Data.Add(new CheckDurationAndValueSpotViewModel()
					{
						Day = spot.BroadcastDate.Day,
						TimeBandName = spot.TimeBandName,
						TimeBandSliceDescription = timeBandSliceDescription,
						TimeBandSliceName = spot.TimeBandSliceName,
						BroadcastDate = spot.BroadcastDate,
						TimeBandId = spot.TimeBandId,
						BookingValue = bookingValue,
						SponsorValue = sponsorValue,
					});
				}
				else
				{
					Data.Add(new CheckDurationAndValueSpotViewModel()
					{
						Day = spot.BroadcastDate.Day,
						TimeBandName = spot.TimeBandName,
						TimeBandSliceDescription = timeBandSliceDescription,
						TimeBandSliceName = spot.TimeBandSliceName,
						BroadcastDate = spot.BroadcastDate,
						TimeBandId = spot.TimeBandId,
						BookingValue = usedBookingDuration,
						SponsorValue = usedSponsorDuration,
					});
				}

			}
		}
	}
}
