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
    [Service(ServiceType = typeof(IRegisterRepository))]
    public class RegisterRepository : Repository<Register>, IRegisterRepository
    {
        public RegisterRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<Register> Get(Guid id)
        {
            return _context.Query<Register>()
                .Where(a => a.Id == id);

        }
        public override IQueryable<Register> List()
        {
            return _context.Query<Register>();
        }
    }
}
