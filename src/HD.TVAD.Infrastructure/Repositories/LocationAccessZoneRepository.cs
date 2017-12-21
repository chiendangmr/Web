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
    [Service(ServiceType = typeof(ILocationAccessZoneRepository))]
    public class LocationAccessZoneRepository : Repository<LocationAccessZone>, ILocationAccessZoneRepository
    {
        public LocationAccessZoneRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<LocationAccessZone> Get(Guid id)
        {
            return _context.Query<LocationAccessZone>()
                .Where(a => a.Id == id)
                .Include(a => a.LocationAccessZoneUri);
                
                

        }
        public override IQueryable<LocationAccessZone> List()
        {
            return _context.Query<LocationAccessZone>()
                .Include(a => a.LocationAccessZoneUri);                
        }
    }    
}
