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
	[Service(ServiceType = typeof(IAnnexContractRepository))]
	public class AnnexContractRepository : Repository<AnnexContract>, IAnnexContractRepository
	{
		public AnnexContractRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<AnnexContract> Get(Guid id)
		{
			return _context.Query<AnnexContract>()
				.Where( a=> a.Id == id)
				.Include(a => a.Customer)
				.Include(a => a.BookingType)
				.Include(a => a.AnnexContractType)
				.Include(a => a.AnnexContractPartners).ThenInclude(a => a.SponsorProgram)
				.Include(a => a.AnnexContractPartners).ThenInclude(a => a.SponsorType)
				.Include(a => a.AnnexContractAssets)
				.ThenInclude(m => m.PriceTypeDetail)
				.Include(a => a.AnnexContractAssets)
				.ThenInclude(b => b.Content);
		}

		public override IQueryable<AnnexContract> List()
		{
			return _context.Query<AnnexContract>()
				.Include(a => a.Customer)
				.Include(a => a.BookingType)
				.Include(a => a.AnnexContractType)
				.Include(a => a.AnnexContractPartners).ThenInclude(a => a.SponsorProgram)
				.Include(a => a.AnnexContractPartners).ThenInclude(a => a.SponsorType)
				.Include(a => a.AnnexContractAssets)
				.ThenInclude( m => m.PriceTypeDetail)
				.Include(a => a.AnnexContractAssets)
				.ThenInclude(b => b.Content);
			
		}
		
	}
}
