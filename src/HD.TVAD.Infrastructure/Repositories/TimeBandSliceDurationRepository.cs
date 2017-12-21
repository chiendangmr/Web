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
	[Service(ServiceType = typeof(ITimeBandSliceDurationRepository))]
	public class TimeBandSliceDurationRepository : Repository<TimeBandSliceDuration>, ITimeBandSliceDurationRepository
	{
		public TimeBandSliceDurationRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<TimeBandSliceDuration> Get(Guid id)
		{
			return _context.Query<TimeBandSliceDuration>()
				.Where( a=> a.Id == id)
				.Include(a => a.TimeBandSliceDurationByTypes)
				.ThenInclude( a => a.Type);
		}

		public override IQueryable<TimeBandSliceDuration> List()
		{
			return _context.Query<TimeBandSliceDuration>()
				.Include(a => a.TimeBandSliceDurationByTypes)
				.ThenInclude(a => a.Type);

		}
		
	}
}
