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
	[Service(ServiceType = typeof(ITemplateItemAssetTypeRequestRepository))]
	public class TemplateItemAssetTypeRequestRepository : Repository<TemplateItemAssetTypeRequest>, ITemplateItemAssetTypeRequestRepository
	{
		public TemplateItemAssetTypeRequestRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<TemplateItemAssetTypeRequest> Get(Guid id)
		{
			return _context.Query<TemplateItemAssetTypeRequest>()
				.Where( a=> a.Id == id)
				.Include(a => a.AssetType)
				.Include(a => a.TemplateItem);
		}

		public override IQueryable<TemplateItemAssetTypeRequest> List()
		{
			return _context.Query<TemplateItemAssetTypeRequest>()
				.Include(a => a.AssetType)
				.Include(a => a.TemplateItem);

		}
		
	}
}
