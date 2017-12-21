using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using HD.TVAD.ApplicationCore.Repositories;
using HD.Station;

namespace HD.TVAD.Infrastructure.Repositories
{
	[Service(ServiceType = typeof(ITimeBandRepository))]
	public class TimeBandRepository : Repository<TimeBand>, ITimeBandRepository
	{
		public TimeBandRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<TimeBand> Get(Guid id)
		{
			return _context.Query<TimeBand>()
				.Where(t => t.Id == id)
				.Include(t => t.TimeBandBase)
				.ThenInclude(t => t.Parent)
				.Include(t => t.TimeBandSlices)
				.Include(t => t.TimeBandDescriptions)
				.Include(t => t.TimeBandDays)
				.Include(t => t.TimeBandTimes);
		}		

		public override IQueryable<TimeBand> List()
		{
			return _context.Query<TimeBand>()
				.Include(t => t.TimeBandBase)
				.ThenInclude(t => t.Parent)
				.Include(t => t.TimeBandSlices)
				.Include(t => t.TimeBandDescriptions)
				.Include(t => t.TimeBandDays)
				.Include(t => t.TimeBandTimes);

		}
		
	}
}
