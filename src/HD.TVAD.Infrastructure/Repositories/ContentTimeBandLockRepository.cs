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
    [Service(ServiceType = typeof(IContentTimeBandLockRepository))]
    public class ContentTimeBandLockRepository : Repository<ContentTimeBandLock>, IContentTimeBandLockRepository
    {
        public ContentTimeBandLockRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<ContentTimeBandLock> Get(Guid id)
        {
            return _context.Query<ContentTimeBandLock>()
                .Where(a => a.Id == id)
                .Include(a => a.TimeBand)                
                .Include(a => a.Content);
        }
        public override IQueryable<ContentTimeBandLock> List()
        {
            return _context.Query<ContentTimeBandLock>()
                .Include(a => a.TimeBand)                
                .Include(a => a.Content);
        }
    }
}
