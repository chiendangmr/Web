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
	[Service(ServiceType = typeof(ICustomerPartnerRepository))]
	public class CustomerPartnerRepository : Repository<CustomerPartner>, ICustomerPartnerRepository
	{
		public CustomerPartnerRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<CustomerPartner> Get(Guid id)
		{
			return _context.Query<CustomerPartner>()
				.Where(a => a.Id == id)
				.Include(c => c.Customer.Type)
				.Include(c => c.InverseParent)
				;
		}

		public override IQueryable<CustomerPartner> List()
		{
			return _context.Query<CustomerPartner>()
				.Include(c => c.Customer.Type)
				.Include(c => c.InverseParent);
			
		}
		
	}
}
