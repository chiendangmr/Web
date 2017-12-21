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
    [Service(ServiceType = typeof(IBenefitPriceRepository))]
    public class BenefitPriceRepository : Repository<BenefitPrice>, IBenefitPriceRepository
    {
        public BenefitPriceRepository(IDataContext context) : base(context)
        {
        }

        public override IQueryable<BenefitPrice> Get(Guid id)
        {
            return _context.Query<BenefitPrice>()
                .Where(a => a.Id == id)
				.Include(a => a.BenefitType).ThenInclude(a => a.TypeDetail)
				.Include(a => a.BenefitPriceTimeBands).ThenInclude(a => a.TimeBand).ThenInclude(a=> a.TimeBandBase)
				.Include(a => a.BenefitPriceSponsorPrograms).ThenInclude(a => a.SponsorProgram)
				;

        }
        public override IQueryable<BenefitPrice> List()
        {
            return _context.Query<BenefitPrice>()
				.Include(a => a.BenefitType).ThenInclude(a => a.TypeDetail)
				.Include(a => a.BenefitPriceTimeBands).ThenInclude(a => a.TimeBand).ThenInclude(a => a.TimeBandBase)
				.Include(a => a.BenefitPriceSponsorPrograms).ThenInclude(a => a.SponsorProgram)
				;
        }
    }    
}
