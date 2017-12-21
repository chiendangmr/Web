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
	[Service(ServiceType = typeof(IRetailCustomerRepository))]
	public class RetailCustomerRepository : Repository<RetailCustomer>, IRetailCustomerRepository
	{
		public RetailCustomerRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<RetailCustomer> Get(Guid id)
		{
			return _context.Query<RetailCustomer>()
				.Where(a => a.Id == id)
				.Include(c => c.Customer.Type)
				;
		}
		public override IQueryable<RetailCustomer> List()
		{
			return _context.Query<RetailCustomer>()
				.Include(c => c.Customer.Type);
			
		}
		
	}
}
