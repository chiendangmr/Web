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
	[Service(ServiceType = typeof(ICustomerRepository))]
	public class CustomerRepository : Repository<Customer>, ICustomerRepository
	{
		public CustomerRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<Customer> Get(Guid id)
		{
			return _context.Query<Customer>()
				.Where(a => a.Id == id)
				.Include(c => c.Type)
				.Include(c => c.CustomerPartners)
				.ThenInclude(c => c.InverseParent)
				;
		}

		public override IQueryable<Customer> List()
		{
			return _context.Query<Customer>()
				.Include(c => c.Type)
				.Include(c => c.CustomerPartners)
				.ThenInclude(c => c.InverseParent);
			
		}
		
	}
}
