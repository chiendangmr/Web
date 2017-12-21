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
    [Service(ServiceType = typeof(IStorageLocationRepository))]
    public class StorageLocationRepository : Repository<StorageLocation>, IStorageLocationRepository
    {
        public StorageLocationRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<StorageLocation> Get(Guid id)
        {
            return _context.Query<StorageLocation>()
                .Where(a => a.Id == id)
                .Include(a => a.AssetLocators)
            .Include(a => a.AssetType).Include(a => a.Storage).Include(a => a.StorageLocationAccesses);

        }
        public override IQueryable<StorageLocation> List()
        {
            return _context.Query<StorageLocation>()
                .Include(a => a.AssetLocators)
            .Include(a => a.AssetType).Include(a => a.Storage).Include(a => a.StorageLocationAccesses);
        }
    }
}
