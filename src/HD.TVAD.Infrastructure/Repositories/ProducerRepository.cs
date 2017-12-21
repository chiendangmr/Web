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
    [Service(ServiceType = typeof(IProducerRepository))]
    public class ProducerRepository : Repository<Producer>, IProducerRepository
    {
        public ProducerRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<Producer> Get(Guid id)
        {
            return _context.Query<Producer>()
                .Where(a => a.Id == id);

        }
        public override IQueryable<Producer> List()
        {
            return _context.Query<Producer>();
        }
    }
}
