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
    [Service(ServiceType = typeof(IContentChannelLockRepository))]
    public class ContentChannelLockRepository : Repository<ContentChannelLock>, IContentChannelLockRepository
    {
        public ContentChannelLockRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<ContentChannelLock> Get(Guid id)
        {
            return _context.Query<ContentChannelLock>()
                .Where(a => a.Id == id)
                .Include(a => a.Channel)
                .Include(a => a.ContentChannelLockTimeBandBaseNoLocks)
                .Include(a => a.Content);
        }
        public override IQueryable<ContentChannelLock> List()
        {
            return _context.Query<ContentChannelLock>()
                .Include(a => a.Channel)
                .Include(a => a.ContentChannelLockTimeBandBaseNoLocks)
                .Include(a => a.Content);
        }
    }
}
