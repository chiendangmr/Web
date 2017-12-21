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
	[Service(ServiceType = typeof(IAnnexContractPartnerPriceAtSignDateRepository))]
	public class AnnexContractPartnerPriceAtSignDateRepository : Repository<AnnexContractPartnerPriceAtSignDate>, IAnnexContractPartnerPriceAtSignDateRepository
	{
		public AnnexContractPartnerPriceAtSignDateRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<AnnexContractPartnerPriceAtSignDate> Get(Guid id)
		{
			return _context.Query<AnnexContractPartnerPriceAtSignDate>()
				.Where( a=> a.Id == id)
				.Include(a => a.AnnexContract)
				.ThenInclude(a => a.AnnexContract);
		}

		public override IQueryable<AnnexContractPartnerPriceAtSignDate> List()
		{
			return _context.Query<AnnexContractPartnerPriceAtSignDate>()
				.Include(a => a.AnnexContract)
				.ThenInclude(a => a.AnnexContract);

		}
		
	}
}
