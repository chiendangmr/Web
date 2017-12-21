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
	[Service(ServiceType = typeof(IRetailPriceRepository))]
	public class RetailPriceRepository : Repository<RetailPrice>, IRetailPriceRepository
	{
		public RetailPriceRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<RetailPrice> Get(Guid id)
		{
			return _context.Query<RetailPrice>()
				.Where( a=> a.Id == id)
				.Include( a => a.RetailType)
				.ThenInclude(a => a.TypeDetail);
		}

		public override IQueryable<RetailPrice> List()
		{
			return _context.Query<RetailPrice>()
				.Include(a => a.RetailType)
				.ThenInclude(a => a.TypeDetail);

		}
		
	}
}
