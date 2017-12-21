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
	[Service(ServiceType = typeof(IDiscountSponsorProgramRepository))]
	public class DiscountSponsorProgramRepository : Repository<DiscountSponsorProgram>, IDiscountSponsorProgramRepository
	{
		public DiscountSponsorProgramRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<DiscountSponsorProgram> Get(Guid id)
		{
			return _context.Query<DiscountSponsorProgram>()
				.Where(a => a.Id == id)
				.Include(c => c.Program).ThenInclude(c => c.AnnexContractType);
		}

		public override IQueryable<DiscountSponsorProgram> List()
		{
			return _context.Query<DiscountSponsorProgram>()
				.Include(c => c.Program).ThenInclude(c => c.AnnexContractType);

		}
	}
}
