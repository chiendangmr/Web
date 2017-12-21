using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HD.Station;
using HD.TVAD.ApplicationCore.Entities.Booking;

namespace HD.TVAD.Web.Services
{
	[Service(ServiceType = typeof(ITimeBandSliceService))]
	public class TimeBandSliceService : Service<TimeBandSlice, ITimeBandSliceRepository>, ITimeBandSliceService
	{
		private readonly ITimeBandSliceDurationService _timeBandSliceDurationService;
		public TimeBandSliceService(ITimeBandSliceRepository repository,
			ITimeBandSliceDurationService timeBandSliceDurationService) : base(repository)
		{
			_timeBandSliceDurationService = timeBandSliceDurationService;
		}

		public async Task<int> GetMaxDurationAsync(Guid timeBandSliceId, DateTime broadcastDate)
		{
			try
			{
				var timebandslice = await _repository.Get(timeBandSliceId).FirstOrDefaultAsync();
				var maxDuration = timebandslice.TimeBandSliceDurations
					.Where(t => t.StartDate <= broadcastDate)
					.OrderByDescending(t => t.StartDate)
					.FirstOrDefault()
					.Duration;
				return maxDuration;
			}
			catch (Exception)
			{
				return 0;
			}
		}

		public int GetMaxDuration(Guid timeBandSliceId, DateTime broadcastDate)
		{
			try
			{
				var timebandslice = _repository.Get(timeBandSliceId).FirstOrDefault();
				var maxDuration = timebandslice.TimeBandSliceDurations
					.Where(t => t.StartDate <= broadcastDate)
					.OrderByDescending(t => t.StartDate)
					.FirstOrDefault()
					.Duration;
				return maxDuration;
			}
			catch (Exception)
			{
				return 0;
			}
		}
		public string GetTimeBandSliceDescriptionByDate(Guid timeBandSliceId, DateTime broadcastDate)
		{

			var timeBandSliceDescription = "";
			var _timeBand = _repository.Get(timeBandSliceId)
				.FirstOrDefault();

			var timeBandDescriptions = _timeBand.TimeBandSliceDescriptions;

			if (timeBandDescriptions.Count > 0)
			{
				var result = timeBandDescriptions
				  .Where(a => a.StartDate <= broadcastDate && (a.EndDate >= broadcastDate || a.EndDate == null))
				  .OrderByDescending(a => a.StartDate)
				  .FirstOrDefault();
				if (result != null)
				{
					timeBandSliceDescription = result.Description;
				}

			}
			return timeBandSliceDescription;
		}

		public int GetMaxDurationByBookingType(Guid timeBandSliceId, DateTime broadcastDate, BookingTypeEnum bookingType)
		{
			try
			{
				var timebandslice = _repository.Get(timeBandSliceId).FirstOrDefault();
				var _timeBandSliceDuration = timebandslice.TimeBandSliceDurations
					.Where(t => t.StartDate <= broadcastDate)
					.OrderByDescending(t => t.StartDate)
					.FirstOrDefault();
				if (_timeBandSliceDuration == null)
					throw new NullReferenceException(_timeBandSliceDuration.GetType().Name);

				var timeBandSliceDuration = _timeBandSliceDurationService.Get(_timeBandSliceDuration.Id).FirstOrDefault();

				if (timeBandSliceDuration == null)
					throw new NullReferenceException(timeBandSliceDuration.GetType().Name);

				var maxDurationByBookingType = timeBandSliceDuration.TimeBandSliceDurationByTypes
					.Where(t => t.TypeId == (int)bookingType)
					.FirstOrDefault();

				if (maxDurationByBookingType == null)
					throw new NullReferenceException(maxDurationByBookingType.GetType().Name);

				return maxDurationByBookingType.Duration;
			}
			catch (Exception)
			{
				return 0;
			}
		}
	}
}
