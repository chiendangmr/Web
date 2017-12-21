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
	[Service(ServiceType = typeof(ITemplateItemRepository))]
	public class TemplateItemRepository : Repository<TemplateItem>, ITemplateItemRepository
	{
		public TemplateItemRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<TemplateItem> Get(Guid id)
		{
			return _context.Query<TemplateItem>()
				.Where( a=> a.Id == id)
				.Include(a => a.Template)
				.Include( a => a.TemplateItemAssetTypeRequests)
				.ThenInclude(a => a.AssetType);
		}

		public override IQueryable<TemplateItem> List()
		{
			return _context.Query<TemplateItem>()
				.Include(a => a.Template)
				.Include(a => a.TemplateItemAssetTypeRequests)
				.ThenInclude(a => a.AssetType);

		}
		
	}
}
