using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Infrastructure.Data;
using System.Threading.Tasks;
using HD.TVAD.ApplicationCore.Repositories;
using HD.Station;

namespace HD.TVAD.Infrastructure.Repositories
{
	[Service(ServiceType = typeof(ISpotBlockRepository))]
	public class SpotBlockRepository : Repository<SpotBlock>, ISpotBlockRepository
	{
		public SpotBlockRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<SpotBlock> Get(Guid id)
		{
			return _context.Query<SpotBlock>()
				.Where(s => s.Id == id);
		}

		public override IQueryable<SpotBlock> List()
		{
			return _context.Query<SpotBlock>();
		}
	}

}
