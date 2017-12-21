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
	[Service(ServiceType = typeof(IRateSpotBlockRepository))]
	public class RateSpotBlockRepository : Repository<RateSpotBlock>, IRateSpotBlockRepository
	{
		public RateSpotBlockRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<RateSpotBlock> Get(Guid id)
		{
			return _context.Query<RateSpotBlock>()
				.Where(a => a.Id == id)
				.Include(a => a.SpotBlock)
				.Include(a => a.TypeDetail)
				.ThenInclude(b => b.Type);
		}

		public override IQueryable<RateSpotBlock> List()
		{
			return _context.Query<RateSpotBlock>()
				.Include(a => a.SpotBlock)
				.Include(a => a.TypeDetail)
				.ThenInclude(b => b.Type);

		}
		
	}
}
