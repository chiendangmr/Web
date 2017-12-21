using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Infrastructure.Data;
using System.Threading.Tasks;
using HD.TVAD.ApplicationCore.Repositories;
using HD.Station;
using Microsoft.EntityFrameworkCore;

namespace HD.TVAD.Infrastructure.Repositories
{
	[Service(ServiceType = typeof(ISponorProgramRepository))]
	public class SponorProgramRepository : Repository<SponsorProgram>, ISponorProgramRepository
	{
		public SponorProgramRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<SponsorProgram> Get(Guid id)
		{
			return _context.Query<SponsorProgram>()
				.Include(s => s.InverseParent)
				.Include(s => s.AnnexContractType)
				.Where(s => s.Id == id);
		}

		public override IQueryable<SponsorProgram> List()
		{
			return _context.Query<SponsorProgram>()
				.Include(s => s.AnnexContractType)
				.Include(s => s.InverseParent);
			
		}
	}
}
