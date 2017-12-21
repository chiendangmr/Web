using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Infrastructure.Data;
using System.Threading.Tasks;
using HD.TVAD.ApplicationCore.Repositories;
using Microsoft.EntityFrameworkCore;
using HD.Station;

namespace HD.TVAD.Infrastructure.Repositories
{
	[Service(ServiceType = typeof(IDiscountAnnexContractRepository))]
	public class DiscountAnnexContractRepository : Repository<DiscountAnnexContract>, IDiscountAnnexContractRepository
	{
		public DiscountAnnexContractRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<DiscountAnnexContract> Get(Guid id)
		{
			return _context.Query<DiscountAnnexContract>()
				.Where(d => d.Id == id)
				.Include(c => c.AnnexContract)
				.ThenInclude(c => c.AnnexContract);
		}

		public override IQueryable<DiscountAnnexContract> List()
		{
			return _context.Query<DiscountAnnexContract>()
				.Include(c => c.AnnexContract)
				.ThenInclude(c => c.AnnexContract);
		}
		
	}
}
