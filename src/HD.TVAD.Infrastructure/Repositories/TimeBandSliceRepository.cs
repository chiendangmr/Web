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
	[Service(ServiceType = typeof(ITimeBandSliceRepository))]
	public class TimeBandSliceRepository : Repository<TimeBandSlice>, ITimeBandSliceRepository
	{
		public TimeBandSliceRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<TimeBandSlice> Get(Guid id)
		{
			return _context.Query<TimeBandSlice>()
				.Where(a => a.Id == id)
				.Include(a => a.TimeBand)
				.ThenInclude(a => a.TimeBandBase)
				.Include(a => a.TimeBandSliceDurations)
				.Include(a => a.TimeBandSliceDescriptions);
		}

		public override IQueryable<TimeBandSlice> List()
		{
			return _context.Query<TimeBandSlice>()
				.Include(a => a.TimeBand)
				.ThenInclude(a => a.TimeBandBase)
				.Include(a => a.TimeBandSliceDurations)
				.Include(a => a.TimeBandSliceDescriptions);
		}
	}
}
