using HD.TVAD.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Services
{
    public interface IChannelService : IService<Channel>
	{
		bool Exist(Channel channel);
		bool ExistName(string name);
		Task<Guid> GetChannelIdOfTimeBandAsync(Guid timeBandId);
		Task<Channel> GetChannelOfTimeBandAsync(Guid timeBandId);
		Task<List<Guid>> GetParentIdsOfTimeBandAsync(Guid timeBandId);
	}
}
