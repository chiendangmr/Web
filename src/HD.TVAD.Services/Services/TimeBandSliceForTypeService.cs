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
	[Service(ServiceType = typeof(ITimeBandSliceForTypeService))]
	public class TimeBandSliceForTypeService : Service<TimeBandSliceForType, ITimeBandSliceForTypeRepository>, ITimeBandSliceForTypeService
	{
		private readonly ITimeBandService _timeBandService;
		private readonly ITimeBandSliceService _timeBandSliceService;
		public TimeBandSliceForTypeService(ITimeBandSliceForTypeRepository repository,
			ITimeBandService timeBandService,
			ITimeBandSliceService timeBandSliceService
			) : base(repository)
		{
			_timeBandService = timeBandService;
			_timeBandSliceService = timeBandSliceService;
		}

		public async Task<IList<TimeBand>> GetTimeBandsForTypeAsync(BookingTypeEnum bookingType)
		{
			var timeBands = await _repository.List()
				.Where(s => s.TypeId == (int)bookingType)
				.Select(s => s.TimeBandSlice.TimeBand)
				.ToListAsync();
			var timeBandResults = new List<TimeBand>();
			foreach (var timeband in timeBands)
			{
				var timebandFull = await _timeBandService.Get(timeband.Id).FirstOrDefaultAsync();
				if (!timeBandResults.Any(t => t.Id == timebandFull.Id))
				{
					timeBandResults.Add(timebandFull);
				}
			}
			return timeBandResults;
		}

		public async Task<IList<TimeBandSlice>> GetTimeBandSliceForType(Guid timeBandId, BookingTypeEnum bookingType)
		{
			var timeBandSlices = await _repository.List()
				.Where(s => s.TypeId == (int)bookingType)
				.Where(s => s.TimeBandSlice.TimeBandId == timeBandId)
				.Select(s => s.TimeBandSlice)
				.ToListAsync();

			var timeBandSliceResults = new List<TimeBandSlice>();

			foreach (var timebandSlice in timeBandSlices)
			{
				if (!timeBandSliceResults.Any(t => t.Id == timebandSlice.Id))
				{
					timeBandSliceResults.Add(timebandSlice);
				}
			}
			return timeBandSliceResults;
		}
	}
}
