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
	[Service(ServiceType = typeof(ITimeBandTimeRepository))]
	public class TimeBandTimeRepository : Repository<TimeBandTime>, ITimeBandTimeRepository
	{
		public TimeBandTimeRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<TimeBandTime> Get(Guid id)
		{
			return _context.Query<TimeBandTime>()
				.Where(a => a.Id == id)
				.Include(t => t.TimeBand).ThenInclude(t => t.TimeBandBase);
		}

		public override IQueryable<TimeBandTime> List()
		{
			return _context.Query<TimeBandTime>()
				.Include(t => t.TimeBand).ThenInclude(t => t.TimeBandBase);

		}
		
	}
}
