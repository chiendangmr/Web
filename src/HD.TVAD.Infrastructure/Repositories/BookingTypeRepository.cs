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
	[Service(ServiceType = typeof(IBookingTypeRepository))]
	public class BookingTypeRepository : TypeRepository<BookingType>, IBookingTypeRepository
	{
		public BookingTypeRepository(IDataContext context) : base(context)
		{
		}
		public override IQueryable<BookingType> List()
		{
			return _context.Query<BookingType>()
				.Include(b => b.Parent);
		}
	}
}
