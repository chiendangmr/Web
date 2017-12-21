using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Infrastructure.Data;
using System.Threading.Tasks;
using HD.TVAD.ApplicationCore.Repositories;
using Microsoft.EntityFrameworkCore;
using HD.Station;

namespace HD.TVAD.Infrastructure.Repositories
{
	[Service(ServiceType = typeof(IChannelRepository))]
	public class ChannelRepository :  Repository<Channel>, IChannelRepository
	{
		public ChannelRepository(IDataContext context) : base(context)
		{
		}		
		public override IQueryable<Channel> Get(Guid id)
		{
			return _context.Query<Channel>()
				.Where(c => c.Id == id)
				.Include(c => c.TimeBandBase);
		}		

		public override IQueryable<Channel> List()
		{
			return _context.Query<Channel>()
				.Include(c => c.TimeBandBase);

		}
	}
}
