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
using HD.TVAD.ApplicationCore.Entities.Security;

namespace HD.TVAD.Infrastructure.Repositories
{
	[Service(ServiceType = typeof(IPermissionRepository))]
	public class PermissionRepository : Repository<Permission>, IPermissionRepository
	{
		public PermissionRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<Permission> Get(Guid id)
		{
			return _context.Query<Permission>()
				.Where(u => u.Id == id);
		}

		public override IQueryable<Permission> List()
		{
			return _context.Query<Permission>();
		}
		
	}
}
