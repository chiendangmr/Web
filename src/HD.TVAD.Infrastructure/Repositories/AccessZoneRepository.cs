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
    [Service(ServiceType = typeof(IAccessZoneRepository))]
    public class AccessZoneRepository : Repository<AccessZone>, IAccessZoneRepository
    {
        public AccessZoneRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<AccessZone> Get(Guid id)
        {
            return _context.Query<AccessZone>()
                .Where(a => a.Id == id)
                .Include(a => a.StorageLocationAccessZones);               

        }
        public override IQueryable<AccessZone> List()
        {
            return _context.Query<AccessZone>()
                .Include(a => a.StorageLocationAccessZones);                
        }
    }
}
