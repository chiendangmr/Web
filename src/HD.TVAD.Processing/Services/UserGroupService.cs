using HD.Station;
using HD.TVAD.ApplicationCore.Entities.Security;
using HD.TVAD.ApplicationCore.Repositories.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Services
{
    [Service(ServiceType = typeof(IUserGroupService))]
	public class UserGroupService : Service<Group, IGroupRepository>, IUserGroupService
	{
		private IUserService _userService;
		public UserGroupService(
			IGroupRepository repository,
			IUserService userService)
			: base(repository)
		{
			_userService = userService;
		}
		
		public List<Group> GetInheritOfGroup(Group group)
		{
			var result = new List<Group>();
			if (group.Childrens != null)
			{
				foreach (var _group in group.Childrens)
				{
					result.Add(_group);
					result.AddRange(GetInheritOfGroup(_group));
				}
			}
			return result;
		}
		public async Task<List<Group>> GetAllGroupOfAdminCanSet(Guid adminUserId)
		{
			var user = await _userService.Get(adminUserId).FirstOrDefaultAsync();
			var groupOfUser = user.GroupUsers;
			var allGroups = await this.GetAll().ToListAsync();
			var inheritGroups = new List<Group>();
			foreach (var group in groupOfUser)
			{
				var thisGroup = allGroups.Find(a => a.Id == group.GroupId);
				inheritGroups.Add(thisGroup);
				inheritGroups.AddRange(this.GetInheritOfGroup(thisGroup));

			}
			return inheritGroups;
		}
		public async Task<List<Group>> GetAllGroupOfUserCanSet(Guid userId)
		{
			var user = await _userService.Get(userId).FirstOrDefaultAsync();
			var groupOfUser = user.GroupUsers;
			var allGroups = await this.GetAll().ToListAsync();
			var inheritGroups = new List<Group>();
			foreach (var group in groupOfUser)
			{
				var thisGroup = allGroups.Find(a => a.Id == group.GroupId);
				if (thisGroup.Parent != null)
				{
					thisGroup = thisGroup.Parent;
				}
				inheritGroups.Add(thisGroup);
				inheritGroups.AddRange(this.GetInheritOfGroup(thisGroup));

			}
			return inheritGroups;
		}
	}
}
