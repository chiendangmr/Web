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
	[Service(ServiceType = typeof(ITimeBandSliceDurationByTypeRepository))]
	public class TimeBandSliceDurationByTypeRepository : Repository<TimeBandSliceDurationByType>, ITimeBandSliceDurationByTypeRepository
	{
		public TimeBandSliceDurationByTypeRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<TimeBandSliceDurationByType> Get(Guid id)
		{
			return _context.Query<TimeBandSliceDurationByType>()
				.Where( a=> a.Id == id)
				.Include( a => a.Type);
		}

		public override IQueryable<TimeBandSliceDurationByType> List()
		{
			return _context.Query<TimeBandSliceDurationByType>()
				.Include(a => a.Type);

		}
		
	}
}
