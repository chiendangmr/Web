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
	[Service(ServiceType = typeof(ITimeBandPriceRepository))]
	public class TimeBandPriceRepository : Repository<TimeBandPrice>, ITimeBandPriceRepository
	{
		public TimeBandPriceRepository(IDataContext context) : base(context)
		{
			
		}

		public override IQueryable<TimeBandPrice> Get(Guid id)
		{
			return _context.Query<TimeBandPrice>()
				.Where( a=> a.Id == id)
				.Include(t => t.SpotBlock)
				.Include(t => t.TimeBand)
				.ThenInclude(m => m.TimeBandBase).ThenInclude(t => t.Parent);
		}

		public override IQueryable<TimeBandPrice> List()
		{
			return _context.Query<TimeBandPrice>()
				.Include(t => t.SpotBlock)
				.Include(t => t.TimeBand)
				.ThenInclude(m => m.TimeBandBase).ThenInclude(t => t.Parent);

		}
		
	}
}
