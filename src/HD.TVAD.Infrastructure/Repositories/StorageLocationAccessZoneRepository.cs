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
    [Service(ServiceType = typeof(IStorageLocationAccessZoneRepository))]
    public class StorageLocationAccessZoneRepository : Repository<StorageLocationAccessZone>, IStorageLocationAccessZoneRepository
    {
        public StorageLocationAccessZoneRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<StorageLocationAccessZone> Get(Guid id)
        {
            return _context.Query<StorageLocationAccessZone>()
                .Where(a => a.Id == id)
                .Include(a => a.AccessZone).Include(a => a.StorageLocationAccess);               

        }
        public override IQueryable<StorageLocationAccessZone> List()
        {
            return _context.Query<StorageLocationAccessZone>()
                .Include(a => a.AccessZone).Include(a => a.StorageLocationAccess);                
        }
    }
}
