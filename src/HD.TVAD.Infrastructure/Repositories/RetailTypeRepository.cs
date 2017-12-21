using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Infrastructure.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HD.TVAD.ApplicationCore.Repositories;
using HD.Station;

namespace HD.TVAD.Infrastructure.Repositories
{
	[Service(ServiceType = typeof(IRetailTypeRepository))]
	public class RetailTypeRepository : TypeRepository<RetailType>, IRetailTypeRepository
	{
		public RetailTypeRepository(IDataContext context) : base(context)
		{
		}
		public override IQueryable<RetailType> List()
		{
			return _context.Query<RetailType>();
		}
	}
}
