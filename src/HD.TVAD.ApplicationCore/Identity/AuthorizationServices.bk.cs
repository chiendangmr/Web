//using HD.TVAD.ApplicationCore.Entities;
//using HD.TVAD.Data;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace HD.TVAD.Infrastructure.Identity
//{
//    public class AuthorizationServices : IAuthorizationServices
//	{
//		private IDataContext _dbContext;
//		public AuthorizationServices(IServiceProvider serviceProvider)
//		{
//			_dbContext = serviceProvider.GetRequiredService<TVADWEBContext>();
//			//_dbContext = context;
//		}

//		public bool CheckPermission(string userName, ModuleEnum module, PermissionEnum action)
//		{
//			var user = _dbContext.Query<User>()
//				.Where(u => u.UserName == userName)
//				.Include(u => u.UserGroupUser)
//				.FirstOrDefault();
//			if (user == null)
//				throw new Exception("No user");
//			var permission = _dbContext.Query<Permission>().Where(p => (p.ModuleId == (int)module) && (p.ActionId == (int)action)).FirstOrDefault();
//			if (permission == null)
//				throw new Exception("No permission");

//			var groupIds = user.GroupUser.Select(a => a.GroupId).ToList();

//			var groupsOfUser = user.GroupUser.Select(a => a.Group).ToList();


//			var groups = _dbContext.Query<UserGroup>().ToList();
//			foreach (var group in groupsOfUser)
//			{
//				groupIds = AddParentGroupRecursion(group, groupIds);
//			}
//			if (groupIds.Count() == 0)
//				return false; // No belong any group
//			var roleIds = _dbContext.Query<GroupRole>().Where(gr => groupIds.Contains(gr.GroupId)).Select(a => a.RoleId).ToList();
//			var permissionIds = _dbContext.Query<RolePermission>().Where(rp => roleIds.Contains(rp.RoleId)).Select(a => a.PermissionId).ToList();

//			return permissionIds.Contains(permission.Id);

//		}
//		public List<Guid> AddParentGroup(List<Guid> groupIds)
//		{
//			for (int i = 0; i < groupIds.Count; i++)
//			{
//				var parentGroupId = GetParentGroupId(groupIds.ElementAt(i));
//				if (parentGroupId != null)
//				{
//					groupIds.Add(parentGroupId.Value);
//				}
//			}

//		//	AddParentGroup(groupIds);

//			return groupIds;
//		}

//		public List<Guid> AddParentGroupRecursion(Group group, List<Guid> groupIds)
//		{
//			if (group.ParentId == null)
//			{
//				return groupIds;
//			}
//			else
//			{
//				groupIds.Add(group.ParentId.Value);
//				group = _dbContext.Query<Group>().Where(g => g.Id == group.ParentId).FirstOrDefault();
//				return AddParentGroupRecursion(group, groupIds);
//			}

//		}



//		public Guid? GetParentGroupId(Guid currentId)
//		{
//			var groupCurrent = _dbContext.Query<Group>().Where(g => g.Id == currentId).FirstOrDefault();

//			if (groupCurrent.ParentId.HasValue)
//			{
//				return groupCurrent.ParentId.Value;
//			}
//			else
//			{
//				return null;
//			}
//		}
//	}
//}
