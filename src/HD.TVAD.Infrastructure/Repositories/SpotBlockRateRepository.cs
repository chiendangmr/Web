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
	[Service(ServiceType = typeof(ISpotBlockRateRepository))]
	public class SpotBlockRateRepository : Repository<SpotBlockRate>, ISpotBlockRateRepository
	{
		public SpotBlockRateRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<SpotBlockRate> Get(Guid id)
		{
			return _context.Query<SpotBlockRate>()
				.Where(a => a.Id == id)
				.Include(a => a.SpotBlock);
		}

		public override IQueryable<SpotBlockRate> List()
		{
			return _context.Query<SpotBlockRate>()
				.Include(a => a.SpotBlock);

		}
		
	}
}
