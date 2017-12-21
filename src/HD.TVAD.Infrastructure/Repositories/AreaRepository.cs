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
    [Service(ServiceType = typeof(IAreaRepository))]
    public class AreaRepository : Repository<Areas>, IAreaRepository
    {
        public AreaRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<Areas> Get(Guid id)
        {
            return _context.Query<Areas>()
                .Where(a => a.Id == id);

        }
        public override IQueryable<Areas> List()
        {
            return _context.Query<Areas>();
        }
    }    
}
