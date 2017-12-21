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
	[Service(ServiceType = typeof(IRetailContractRepository))]
	public class RetailContractRepository : Repository<RetailContract>, IRetailContractRepository
	{
		public RetailContractRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<RetailContract> Get(Guid id)
		{
			return _context.Query<RetailContract>()
				.Where( a=> a.Id == id)
				.Include(a => a.AnnexContract).ThenInclude(a => a.Customer)
				.Include(a => a.AnnexContract).ThenInclude(a => a.BookingType)
				.Include(a => a.AnnexContract).ThenInclude(a => a.AnnexContractType)
				.Include(a => a.AnnexContract).ThenInclude(a => a.AnnexContractAssets).ThenInclude(m => m.PriceTypeDetail)
				.Include(a => a.AnnexContract).ThenInclude(a => a.AnnexContractAssets).ThenInclude(b => b.Content);
		}

		public override IQueryable<RetailContract> List()
		{
			return _context.Query<RetailContract>()
				.Include(a => a.AnnexContract).ThenInclude(a => a.Customer)
				.Include(a => a.AnnexContract).ThenInclude(a => a.BookingType)
				.Include(a => a.AnnexContract).ThenInclude(a => a.AnnexContractType)
				.Include(a => a.AnnexContract).ThenInclude(a => a.AnnexContractAssets).ThenInclude(m => m.PriceTypeDetail)
				.Include(a => a.AnnexContract).ThenInclude(a => a.AnnexContractAssets).ThenInclude(b => b.Content);

		}
		
	}
}
