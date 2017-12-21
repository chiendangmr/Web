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
    [Service(ServiceType = typeof(IVersionRepository))]
    public class VersionRepository : Repository<ApplicationCore.Entities.Version>, IVersionRepository
    {
        public VersionRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<ApplicationCore.Entities.Version> Get(Guid id)
        {
            return _context.Query<ApplicationCore.Entities.Version>()
                .Where(a => a.Id == id)                
                .Include(a => a.Asset)
                .Include(a => a.Scene);
        }
        public override IQueryable<ApplicationCore.Entities.Version> List()
        {
            return _context.Query<ApplicationCore.Entities.Version>()
                .Include(a => a.Asset)
                .Include(a => a.Scene);
        }
    }
}
