using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Infrastructure.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HD.TVAD.ApplicationCore.Repositories;
using HD.Station;

namespace HD.TVAD.Infrastructure.Repositories
{
    [Service(ServiceType = typeof(IContentRepository))]
    public class ContentRepository : Repository<Content>, IContentRepository
    {
        public ContentRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<Content> Get(Guid id)
        {
            return _context.Query<Content>()
                .Where(a => a.Id == id)
                .Include(a => a.Type)
                .Include(a => a.Producer)
                .Include(a => a.ProductGroup)
                .Include(a => a.Register)
                .Include(a => a.SpotAssetByAssets)
                .Include(a => a.AnnexContractAssets)
                .Include(a => a.Versions)
				.Include(a => a.LastProductModelNavigation);
        }
        public override IQueryable<Content> List()
        {
            return _context.Query<Content>()
                .Include(a => a.Type)
                .Include(a => a.Producer)
                .Include(a => a.ProductGroup)
                .Include(a => a.Register)
                .Include(a => a.Versions)
                .Include(a => a.SpotAssetByAssets)
                .Include(a => a.AnnexContractAssets)
                .Include(a => a.LastProductModelNavigation);
        }
    }
}
