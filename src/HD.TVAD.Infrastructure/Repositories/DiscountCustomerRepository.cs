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
	[Service(ServiceType = typeof(IDiscountCustomerRepository))]
	public class DiscountCustomerRepository : Repository<DiscountCustomer>, IDiscountCustomerRepository
	{
		public DiscountCustomerRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<DiscountCustomer> Get(Guid id)
		{
			return _context.Query<DiscountCustomer>()
				.Where(d => d.Id == id)
				.Include(c => c.Customer).ThenInclude(c => c.CustomerPartners)
				;
		}

		public override IQueryable<DiscountCustomer> List()
		{
			return _context.Query<DiscountCustomer>()
				.Include(c => c.Customer).ThenInclude(c => c.CustomerPartners)
				;			
		}
	}
}
