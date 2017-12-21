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
    [Service(ServiceType = typeof(IOriginRepository))]
    public class OriginRepository : Repository<Origin>, IOriginRepository
    {
        public OriginRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<Origin> Get(Guid id)
        {
            return _context.Query<Origin>()
                .Where(a => a.Id == id)
                .Include(a => a.Scenes);                
        }
        public override IQueryable<Origin> List()
        {
            return _context.Query<Origin>()                
                .Include(a => a.Scenes);
                
        }
    }
}
