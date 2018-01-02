using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Entities.Security;
using HD.TVAD.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Infrastructure.Identity
{
	public class AuthorizationTvadService : IAuthorizationTvadService
	{
		private IDataContext _dbContext;
		public AuthorizationTvadService(IServiceProvider serviceProvider, IDataContext context)
		{

		//	_dbContext = serviceProvider.GetRequiredService<TVADWEBContext>();
			_dbContext = context;
		}

		public bool CheckPermission(string userName, ModuleType module, PermissionActionType action)
		{
			//var user = _dbContext.Query<User>()
			//	.Where(u => u.UserName == userName)
			//	.Include(u => u.UserGroupUser)
			//	.FirstOrDefault();
			//if (user == null)
			//	return false;
			//var permission = _dbContext.Query<ModulePermission>().Where(p => (p.ModuleId == (int)module) && (p.PermisstionId == (int)action)).FirstOrDefault();
			//if (permission == null)
			//	return false;

			//var groupIds = user.UserGroupUser.Select(a => a.UserGroupId).ToList();

			//var groupsOfUser = user.UserGroupUser.Select(a => a.UserGroup).ToList();


			//var groups = _dbContext.Query<UserGroup>().ToList();
			////foreach (var group in groupsOfUser)
			////{
			////	groupIds = AddParentGroupRecursion(group, groupIds);
			////}
			//if (groupIds.Count() == 0)
			//	return false; // No belong any group
			////var roleIds = _dbContext.Query<GroupRole>().Where(gr => groupIds.Contains(gr.GroupId)).Select(a => a.RoleId).ToList();

			//var permissionIds = _dbContext.Query<UserGroupModulePermission>().Where(rp => groupIds.Contains(rp.UserGroupId)).Select(a => a.ModulePermissionId).ToList();


			//return permissionIds.Contains(permission.ModulePermissionId);
			throw new NotImplementedException();

		}
		public List<Guid> AddParentGroup(List<Guid> groupIds)
		{
			for (int i = 0; i < groupIds.Count; i++)
			{
				var parentGroupId = GetParentGroupId(groupIds.ElementAt(i));
				if (parentGroupId != null)
				{
					groupIds.Add(parentGroupId.Value);
				}
			}

			//	AddParentGroup(groupIds);

			return groupIds;
		}

		public List<Guid> AddParentGroupRecursion(Group group, List<Guid> groupIds)
		{
			if (group.ParentId == null)
			{
				return groupIds;
			}
			else
			{
				groupIds.Add(group.ParentId.Value);
				group = _dbContext.Query<Group>().Where(g => g.Id == group.ParentId).FirstOrDefault();
				return AddParentGroupRecursion(group, groupIds);
			}

		}



		public Guid? GetParentGroupId(Guid currentId)
		{
			var groupCurrent = _dbContext.Query<Group>().Where(g => g.Id == currentId).FirstOrDefault();

			if (groupCurrent.ParentId.HasValue)
			{
				return groupCurrent.ParentId.Value;
			}
			else
			{
				return null;
			}
		}
	}
}
