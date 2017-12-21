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
	[Service(ServiceType = typeof(ITimeBandDayRepository))]
	public class TimeBandDayRepository : Repository<TimeBandDay>, ITimeBandDayRepository
	{
		public TimeBandDayRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<TimeBandDay> Get(Guid id)
		{
			return _context.Query<TimeBandDay>()
				.Where(a => a.Id == id)
				.Include(t => t.TimeBand).ThenInclude(t => t.TimeBandBase);
		}

		public override IQueryable<TimeBandDay> List()
		{
			return _context.Query<TimeBandDay>()
				.Include(t => t.TimeBand).ThenInclude(t => t.TimeBandBase);

		}
		
	}
}
