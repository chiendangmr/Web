using HD.Station;
using HD.TVAD.ApplicationCore.Entities.Security;
using HD.TVAD.ApplicationCore.Repositories.Security;
using HD.TVAD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace HD.TVAD.Infrastructure.Repositories.Security
{
    [Service(ServiceType = typeof(IUserRepository))]
	public class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<User> Get(Guid id)
		{
			return _context.Query<User>()
				.Where(u => u.Id == id)
				.Include(u => u.GroupUsers)
				.ThenInclude(g => g.Group);
		}

		public override IQueryable<User> List()
		{
			return _context.Query<User>();
		}
		
	}
}
