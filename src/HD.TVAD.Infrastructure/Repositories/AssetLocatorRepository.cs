using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HD.TVAD.Infrastructure.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HD.TVAD.ApplicationCore.Repositories;
using HD.TVAD.ApplicationCore.Entities.MediaAsset;
using HD.Station;

namespace HD.TVAD.Infrastructure.Repositories
{
    [Service(ServiceType = typeof(IAssetLocatorRepository))]
    public class AssetLocatorRepository : Repository<AssetLocator>, IAssetLocatorRepository
    {
        public AssetLocatorRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<AssetLocator> Get(Guid id)
        {
            return _context.Query<AssetLocator>()
                .Where(a => a.Id == id)
                .Include(a => a.MimeType).Include(a => a.StorageLocation).Include(a => a.Asset);               

        }
        public override IQueryable<AssetLocator> List()
        {
            return _context.Query<AssetLocator>()
                .Include(a => a.MimeType).Include(a => a.StorageLocation).Include(a => a.Asset);                
        }
    }
}
