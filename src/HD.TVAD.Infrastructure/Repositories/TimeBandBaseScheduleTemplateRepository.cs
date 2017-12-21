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
	[Service(ServiceType = typeof(ITimeBandBaseScheduleTemplateRepository))]
	public class TimeBandBaseScheduleTemplateRepository : Repository<TimeBandBaseScheduleTemplate>, ITimeBandBaseScheduleTemplateRepository
	{
		public TimeBandBaseScheduleTemplateRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<TimeBandBaseScheduleTemplate> Get(Guid id)
		{
			return _context.Query<TimeBandBaseScheduleTemplate>()
				.Where( a=> a.Id == id)
				.Include(a => a.ScheduleTemplate)
				.Include(a => a.TimeBandBase);
		}

		public override IQueryable<TimeBandBaseScheduleTemplate> List()
		{
			return _context.Query<TimeBandBaseScheduleTemplate>()
				.Include(a => a.ScheduleTemplate)
				.Include(a => a.TimeBandBase);

		}
		
	}
}
