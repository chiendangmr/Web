using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HD.Station;

namespace HD.TVAD.Web.Services
{
	[Service(ServiceType = typeof(IChannelService))]
	public class ChannelService : Service<Channel, IChannelRepository>, IChannelService
	{
		private readonly ITimeBandService _timeBandService;
		public ChannelService(IChannelRepository repository,
			ITimeBandService timeBandService) : base(repository)
		{
			_timeBandService = timeBandService;
		}

		public bool Exist(Channel channel)
		{
			return GetAll().Any(c =>
			c.TimeBandBase.ParentId == channel.TimeBandBase.ParentId
			&& c.TimeBandBase.Name == channel.TimeBandBase.Name);
		}
		public bool ExistName(string name)
		{
			return GetAll().Any(c => c.TimeBandBase.Name == name);
		}

		public async Task<Guid> GetChannelIdOfTimeBandAsync(Guid timeBandId)
		{
			var timeBand = await _timeBandService.Get(timeBandId).FirstOrDefaultAsync(); // timeband level 1
			if (_repository.List().Any(c => c.Id == timeBand.TimeBandBase.ParentId)) 
				return timeBand.TimeBandBase.ParentId.Value;

			var timeBandLevel2 = await _timeBandService.Get(timeBand.TimeBandBase.ParentId.Value).FirstOrDefaultAsync(); // timeband level 2
			if (_repository.List().Any(c => c.Id == timeBandLevel2.TimeBandBase.ParentId))
				return timeBandLevel2.TimeBandBase.ParentId.Value;

			var timeBandLevel3 = await _timeBandService.Get(timeBandLevel2.TimeBandBase.ParentId.Value).FirstOrDefaultAsync(); // timeband level 2
			if (_repository.List().Any(c => c.Id == timeBandLevel3.TimeBandBase.ParentId))
				return timeBandLevel3.TimeBandBase.ParentId.Value;

			throw new Exception("Not support many level timeband");
		}

		public async Task<Channel> GetChannelOfTimeBandAsync(Guid timeBandId)
		{
			var timeBand = await _timeBandService.Get(timeBandId).FirstOrDefaultAsync(); // timeband level 1
			if (_repository.List().Any(c => c.Id == timeBand.TimeBandBase.ParentId))
				return await _repository.Get(timeBand.TimeBandBase.ParentId.Value).FirstOrDefaultAsync();

			var timeBandLevel2 = await _timeBandService.Get(timeBand.TimeBandBase.ParentId.Value).FirstOrDefaultAsync(); // timeband level 2
			if (_repository.List().Any(c => c.Id == timeBandLevel2.TimeBandBase.ParentId))
				return await _repository.Get(timeBandLevel2.TimeBandBase.ParentId.Value).FirstOrDefaultAsync();

			var timeBandLevel3 = await _timeBandService.Get(timeBandLevel2.TimeBandBase.ParentId.Value).FirstOrDefaultAsync(); // timeband level 2
			if (_repository.List().Any(c => c.Id == timeBandLevel3.TimeBandBase.ParentId))
				return await _repository.Get(timeBandLevel3.TimeBandBase.ParentId.Value).FirstOrDefaultAsync();

			throw new Exception("Not support many level timeband");
		}

		public async Task<List<Guid>> GetParentIdsOfTimeBandAsync(Guid timeBandId)
		{
			var parentIds = new List<Guid>();
			var timeBand = await _timeBandService.Get(timeBandId).FirstOrDefaultAsync(); // timeband level 1
			if (_repository.List().Any(c => c.Id == timeBand.TimeBandBase.ParentId))
			{
				parentIds.Add(timeBand.TimeBandBase.ParentId.Value);
				return parentIds;
			}

			var timeBandLevel2 = await _timeBandService.Get(timeBand.TimeBandBase.ParentId.Value).FirstOrDefaultAsync(); // timeband level 2
			if (_repository.List().Any(c => c.Id == timeBandLevel2.TimeBandBase.ParentId))
			{
				parentIds.Add(timeBandLevel2.TimeBandBase.ParentId.Value);
				return parentIds;
			}
			var timeBandLevel3 = await _timeBandService.Get(timeBandLevel2.TimeBandBase.ParentId.Value).FirstOrDefaultAsync(); // timeband level 2
			if (_repository.List().Any(c => c.Id == timeBandLevel3.TimeBandBase.ParentId))
			{
				parentIds.Add(timeBandLevel3.TimeBandBase.ParentId.Value);
				return parentIds;
			}

			throw new Exception("Not support many level timeband");
		}
	}
}
