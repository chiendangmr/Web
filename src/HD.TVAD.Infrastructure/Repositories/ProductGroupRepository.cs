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
    [Service(ServiceType = typeof(IProductGroupRepository))]
    public class ProductGroupRepository : Repository<ProductGroup>, IProductGroupRepository
    {
        public ProductGroupRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<ProductGroup> Get(Guid id)
        {
            return _context.Query<ProductGroup>()
                .Where(a => a.Id == id);

        }
        public override IQueryable<ProductGroup> List()
        {
            return _context.Query<ProductGroup>();
        }
    }    
}
