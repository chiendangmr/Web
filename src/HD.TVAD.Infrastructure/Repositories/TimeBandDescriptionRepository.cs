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
	[Service(ServiceType = typeof(ITimeBandDescriptionRepository))]
	public class TimeBandDescriptionRepository : Repository<TimeBandDescription>, ITimeBandDescriptionRepository
	{
		public TimeBandDescriptionRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<TimeBandDescription> Get(Guid id)
		{
			return _context.Query<TimeBandDescription>()
				.Where(a => a.Id == id)
				.Include(t => t.TimeBand).ThenInclude(t => t.TimeBandBase);
		}

		public override IQueryable<TimeBandDescription> List()
		{
			return _context.Query<TimeBandDescription>()
				.Include(t => t.TimeBand).ThenInclude(t => t.TimeBandBase);

		}
		
	}
}
