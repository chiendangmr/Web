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
    [Service(ServiceType = typeof(IStorageLocationAccessTypeRepository))]
    public class StorageLocationAccessTypeRepository : Repository<StorageLocationAccessType>, IStorageLocationAccessTypeRepository
    {
        public StorageLocationAccessTypeRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<StorageLocationAccessType> Get(Guid id)
        {
            return _context.Query<StorageLocationAccessType>()
                .Where(a => a.Id == id)
                .Include(a => a.StorageLocationAccesses);               

        }
        public override IQueryable<StorageLocationAccessType> List()
        {
            return _context.Query<StorageLocationAccessType>()
                .Include(a => a.StorageLocationAccesses);
        }
    }
}
