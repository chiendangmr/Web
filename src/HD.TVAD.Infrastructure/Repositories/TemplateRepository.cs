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
	[Service(ServiceType = typeof(ITemplateRepository))]
	public class TemplateRepository : Repository<Template>, ITemplateRepository
	{
		public TemplateRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<Template> Get(Guid id)
		{
			return _context.Query<Template>()
				.Where( a=> a.Id == id)
				.Include( a=> a.TimeBandBaseScheduleTemplates)
				.ThenInclude(a => a.TimeBandBase)
				.Include( a => a.TemplateItems);
		}

		public override IQueryable<Template> List()
		{
			return _context.Query<Template>()
				.Include(a => a.TimeBandBaseScheduleTemplates)
				.ThenInclude(a => a.TimeBandBase)
				.Include(a => a.TemplateItems);

		}
		
	}
}
