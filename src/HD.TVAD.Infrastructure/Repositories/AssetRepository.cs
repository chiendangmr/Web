using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HD.TVAD.ApplicationCore.Entities.MediaAsset;
using HD.TVAD.Infrastructure.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HD.TVAD.ApplicationCore.Repositories;
using HD.Station;

namespace HD.TVAD.Infrastructure.Repositories
{
    [Service(ServiceType = typeof(IAssetRepository))]
    public class AssetRepository : Repository<Asset>, IAssetRepository
    {
        public AssetRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<Asset> Get(Guid id)
        {
            return _context.Query<Asset>()
                .Where(a => a.Id == id)
                .Include(a => a.Scenes)
                .Include(a => a.MediaAsset)
                .Include(a => a.AssetType)
                .Include(a => a.AssetLocators)
                .Include(a => a.MimeTypeObj);

        }
        public override IQueryable<Asset> List()
        {
            return _context.Query<Asset>()
                .Include(a => a.Scenes)
                .Include(a => a.MediaAsset)
                .Include(a => a.AssetType)
                .Include(a => a.AssetLocators)
                .Include(a => a.MimeTypeObj);
        }
    }
}
