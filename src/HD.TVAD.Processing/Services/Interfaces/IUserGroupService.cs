using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Entities.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Services
{
    public interface IUserGroupService : IService<Group>
	{

		List<Group> GetInheritOfGroup(Group group);
		Task<List<Group>> GetAllGroupOfAdminCanSet(Guid adminUserId);
		Task<List<Group>> GetAllGroupOfUserCanSet(Guid userId);
	}
}
