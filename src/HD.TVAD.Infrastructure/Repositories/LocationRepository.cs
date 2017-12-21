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
    [Service(ServiceType = typeof(ILocationRepository))]
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<Location> Get(Guid id)
        {
            return _context.Query<Location>()
                .Where(a => a.Id == id)
                .Include(a => a.LocationAccessZones);
                
                

        }
        public override IQueryable<Location> List()
        {
            return _context.Query<Location>()
                .Include(a => a.LocationAccessZones);                
        }
    }    
}
