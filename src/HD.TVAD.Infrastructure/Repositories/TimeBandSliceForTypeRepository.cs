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
	[Service(ServiceType = typeof(ITimeBandSliceForTypeRepository))]
	public class TimeBandSliceForTypeRepository : Repository<TimeBandSliceForType>, ITimeBandSliceForTypeRepository
	{
		public TimeBandSliceForTypeRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<TimeBandSliceForType> Get(Guid id)
		{
			return _context.Query<TimeBandSliceForType>()
				.Where( a=> a.Id == id)
				.Include( a => a.Type)
				.Include( a => a.TimeBandSlice)
				.ThenInclude( a => a.TimeBand)
				.ThenInclude(a => a.TimeBandBase);
		}

		public override IQueryable<TimeBandSliceForType> List()
		{
			return _context.Query<TimeBandSliceForType>()
				.Include(a => a.Type)
				.Include(a => a.TimeBandSlice)
				.ThenInclude(a => a.TimeBand)
				.ThenInclude(a => a.TimeBandBase);

		}
		
	}
}
