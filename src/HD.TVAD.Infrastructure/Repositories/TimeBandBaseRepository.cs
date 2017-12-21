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
	[Service(ServiceType = typeof(ITimeBandBaseRepository))]
	public class TimeBandBaseRepository : Repository<TimeBandBase>, ITimeBandBaseRepository
	{
		public TimeBandBaseRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<TimeBandBase> Get(Guid id)
		{
			return _context.Query<TimeBandBase>()
				.Where(t => t.Id == id)
				.Include(t => t.Channels)
				.Include(t => t.TimeBands);
		}		

		public override IQueryable<TimeBandBase> List()
		{
			return _context.Query<TimeBandBase>()
				.Include(t => t.Channels)
				.Include(t => t.TimeBands);

		}
		
	}
}
