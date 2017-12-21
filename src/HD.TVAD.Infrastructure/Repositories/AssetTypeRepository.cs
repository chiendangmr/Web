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
    [Service(ServiceType = typeof(IAssetTypeRepository))]
    public class AssetTypeRepository : Repository<AssetType>, IAssetTypeRepository
    {
        public AssetTypeRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<AssetType> Get(Guid id)
        {
            return _context.Query<AssetType>()
                .Where(a => a.Id == id).Include(a => a.Assets).Include(a => a.StorageLocations);

        }
        public override IQueryable<AssetType> List()
        {
            return _context.Query<AssetType>().Include(a => a.Assets).Include(a => a.StorageLocations);
        }
    }
}
