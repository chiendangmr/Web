using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HD.TVAD.Infrastructure.Data;
using HD.Station;

namespace HD.TVAD.Web.Services
{
	[Service(ServiceType = typeof(ITimeBandService))]
	public class TimeBandService : Service<TimeBand, ITimeBandRepository>, ITimeBandService
	{
		public TimeBandService(ITimeBandRepository repository) : base(repository)
		{
		}

		public bool Exist(TimeBand TimeBand)
		{
			var result = _repository.List().Any( t => t.TimeBandBase.Name == TimeBand.TimeBandBase.Name);
			return result;
		}

		public async Task<List<TimeBand>> GetAllTimeBandByChannelIdAsync(Guid channelId)
		{
			var _timeBands = await _repository.List()
				.Where(t => t.TimeBandBase.ParentId == channelId)
				.OrderBy(t => t.TimeBandBase.Name)
				.ToListAsync();

			var timeBands = await _repository.List()
				.Where(t => t.TimeBandBase.ParentId == channelId || _timeBands.Any(_t => t.TimeBandBase.ParentId == _t.Id)) // just get chirend level 2
				.OrderBy(t => t.TimeBandBase.Name)
				.ToListAsync(); //TODO: Get All inherit

			return timeBands;
		}

		public Task<List<TimeBand>> GetAllTimeBandOfDayPart1Async(DateTime broadcastDate)
		{
			var _12h = new TimeSpan(16, 0, 0);
			var timebands = _repository.List()
				.Where(t => t.TimeBandTimes.Any(s => (s.StartTimeOfDay < _12h)
				&& (s.StartDate <= broadcastDate && (s.EndDate >= broadcastDate || s.EndDate == null))));

			return timebands.ToListAsync();
		}

		public Task<List<TimeBand>> GetAllTimeBandOfDayPart2Async(DateTime broadcastDate)
		{
			var _12h = new TimeSpan(16, 0, 0);
			var timebands = _repository.List()
				.Where(t => t.TimeBandTimes.Any(s => (s.StartTimeOfDay >= _12h)
				&& (s.StartDate <= broadcastDate && (s.EndDate >= broadcastDate || s.EndDate == null))));

			return timebands.ToListAsync();
		}

		public string GetTimeBandDescriptionByDate(Guid timeBandId, DateTime date)
		{
			var timeBandDescription = "";
			var _timeBand = _repository.Get(timeBandId)
				.FirstOrDefault();

			var timeBandDescriptions = _timeBand.TimeBandDescriptions;

			if (timeBandDescriptions.Count > 0)
			{
				var result = timeBandDescriptions
				  .Where(a => a.StartDate <= date && (a.EndDate >= date || a.EndDate == null) )
				  .OrderByDescending(a => a.StartDate)
				  .FirstOrDefault();
				if (result != null)
				{
					timeBandDescription = result.Description;
				}

			}
			return timeBandDescription;
		}
	}
}
