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
	[Service(ServiceType = typeof(ITimeBandSliceDescriptionRepository))]
	public class TTimeBandSliceDescriptionRepository : Repository<TimeBandSliceDescription>, ITimeBandSliceDescriptionRepository
	{
		public TTimeBandSliceDescriptionRepository(IDataContext context) : base(context)
		{

		}

		public override IQueryable<TimeBandSliceDescription> Get(Guid id)
		{
			return _context.Query<TimeBandSliceDescription>()
				.Where(a => a.Id == id)
				.Include(a => a.TimeBandSlice);
		}

		public override IQueryable<TimeBandSliceDescription> List()
		{
			return _context.Query<TimeBandSliceDescription>()
				.Include(a => a.TimeBandSlice);

		}
		
	}
}
