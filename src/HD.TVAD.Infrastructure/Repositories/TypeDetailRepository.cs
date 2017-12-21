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
	[Service(ServiceType = typeof(ITypeDetailRepository))]
	public class TypeDetailRepository : Repository<TypeDetail>, ITypeDetailRepository
	{
		public TypeDetailRepository(IDataContext context) : base(context)
		{
		}
		public override IQueryable<TypeDetail> List()
		{
			return _context.Query<TypeDetail>()
				.Include(t => t.Type)
				.ThenInclude(t => t.BookingTypePriceTypes);
		}
	}
}
