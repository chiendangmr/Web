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
	[Service(ServiceType = typeof(IPositionRateRepository))]
	public class PositionRateRepository : Repository<PositionRate>, IPositionRateRepository
	{
		public PositionRateRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<PositionRate> Get(Guid id)
		{
			return _context.Query<PositionRate>()
				.Where(a => a.Id == id);
		}

		public override IQueryable<PositionRate> List()
		{
			return _context.Query<PositionRate>()
				.Where(p => p.TimeBandId == null)
				;

		}

		public IQueryable<PositionRate> ListIncludeTimeBand()
		{
			return _context.Query<PositionRate>()
					.Include(t => t.TimeBand)
					.ThenInclude(m => m.TimeBandBase)
				;

		}
	}
}
