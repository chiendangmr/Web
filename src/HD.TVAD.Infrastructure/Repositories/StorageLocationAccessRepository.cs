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
    [Service(ServiceType = typeof(IStorageLocationAccessRepository))]
    public class StorageLocationAccessRepository : Repository<StorageLocationAccess>, IStorageLocationAccessRepository
    {
        public StorageLocationAccessRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<StorageLocationAccess> Get(Guid id)
        {
            return _context.Query<StorageLocationAccess>()
                .Where(a => a.Id == id)
                .Include(a => a.StorageLocation).Include(a => a.StorageLocationAccessZones).Include(a => a.StorageLocationAccessType);               

        }
        public override IQueryable<StorageLocationAccess> List()
        {
            return _context.Query<StorageLocationAccess>()
                .Include(a => a.StorageLocation).Include(a => a.StorageLocationAccessZones).Include(a => a.StorageLocationAccessType);                
        }
    }
}
