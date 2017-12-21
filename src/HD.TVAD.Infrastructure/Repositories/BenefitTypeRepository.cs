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
    [Service(ServiceType = typeof(IBenefitTypeRepository))]
    public class BenefitTypeRepository : Repository<BenefitType>, IBenefitTypeRepository
	{
        public BenefitTypeRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<BenefitType> Get(Guid id)
        {
            return _context.Query<BenefitType>()
                .Where(a => a.Id == id)
				.Include(a => a.TypeDetail)
				.ThenInclude(a => a.Type)
				;
        }
        public override IQueryable<BenefitType> List()
        {
            return _context.Query<BenefitType>()
				.Include(a => a.TypeDetail)
				.ThenInclude(a => a.Type)
				;
        }
    }
}
