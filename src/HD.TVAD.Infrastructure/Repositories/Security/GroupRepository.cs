using HD.Station;
using HD.TVAD.ApplicationCore.Entities.Security;
using HD.TVAD.ApplicationCore.Repositories.Security;
using HD.TVAD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Infrastructure.Repositories.Security
{
    [Service(ServiceType = typeof(IGroupRepository))]
	public class GroupRepository : Repository<Group>, IGroupRepository
	{
		public GroupRepository(IDataContext context) : base(context)
		{
		}

		public override IQueryable<Group> Get(Guid id)
		{
			return _context.Query<Group>()
				.Include(u => u.GroupPermissions)
				.Where(u => u.Id == id);
		}

		public override IQueryable<Group> List()
		{
			return _context.Query<Group>();
		}
		

        public Task<bool> IsInRole(Group group, Guid permissionId)
        {
            return Task.Run(() =>
            {
                return List().Where(g => g.Id == group.Id).Include(g => g.GroupPermissions).First().GroupPermissions.Any(p => p.PermissionId == permissionId);
            });
        }
    }
}
