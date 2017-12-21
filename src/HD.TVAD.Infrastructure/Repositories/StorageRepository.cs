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
    [Service(ServiceType = typeof(IStorageRepository))]
    public class StorageRepository : Repository<Storage>, IStorageRepository
    {
        public StorageRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<Storage> Get(Guid id)
        {
            return _context.Query<Storage>()
                .Where(a => a.Id == id)
                .Include(a => a.StorageLocations);               

        }
        public override IQueryable<Storage> List()
        {
            return _context.Query<Storage>()
                .Include(a => a.StorageLocations);                
        }
    }
}
