using HD.TVAD.Web.Services;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HD.TVAD.Entities.Entities.Security;
using HD.TVAD.Entities.Entities;
using HD.TVAD.Entities.Repositories.Security;
using Microsoft.Extensions.Localization;
using HD.TVAD.Entities.Repositories;
using HD.TVAD.Web.Models;
using Newtonsoft.Json;
using HD.TVAD.Web.Features.Manager;
using HD.TVAD.Web.Infrastructure;
using HD.TVAD.Web.StartData;
using HD.TVAD.Web.Features.Managers.UserGroup.Models;

namespace HD.TVAD.Features.Manager
{
    [Area("Manager")]
	[Authorize]
	public class UserGroupController : TVADController
	{

		private readonly UserManager<User> _userManager;
		private readonly IGroupRepository<Group> _groupRepository;
		private readonly IUserRepository<User> _userRepository;
		readonly IRepository<Entities.Entities.Security.Permission> _permissionRepository;
		readonly IRepository<Group_Permission> _groupPermissionReposiroty;
		readonly IStringLocalizer<UserGroupController> _localizer;

		public UserGroupController(
			UserManager<User> userManager,
			IUserRepository<User> userRepository,
			IGroupRepository<Group> groupRepository,
			IRepository<Entities.Entities.Security.Permission> permissionRepository,
			IRepository<Group_Permission> groupPermissionReposiroty,
			IStringLocalizer<UserGroupController> localizer
			)
		{
			_userManager = userManager;
			_userRepository = userRepository;
			_groupRepository = groupRepository;
			_permissionRepository = permissionRepository;
			_groupPermissionReposiroty = groupPermissionReposiroty;
			_localizer = localizer;
		}
		[HttpGet]
		[RequiresPermission(UserPermissions.Manager_UserGroup)]
		public async Task<IActionResult> Index()
		{

			return View();
		}
		[HttpGet]
		[RequiresPermission(UserPermissions.Manager_UserGroup_Create)]
		public async Task<IActionResult> Create(Guid id)
		{
			var model = new UserGroupCreateViewModel()
			{
				ParentId = id,
			};
			return View(model);
		}

		[HttpPost]
		[RequiresPermission(UserPermissions.Manager_UserGroup_Create)]
		public async Task<IActionResult> Create(UserGroupCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var groupModel = viewModel;

					if (_groupRepository.Datas.Any(g => g.ParentId == groupModel.ParentId && g.Name == groupModel.Name))
						throw new Exception(string.Format(_localizer["Group {0} has exists"].Value, groupModel.Name));

					var newGroup = new Group()
					{
						Name = groupModel.Name,
						ParentId = groupModel.ParentId,
						Active = true,
					};

					await _groupRepository.InsertAsync(newGroup);

					return JsonResponse(1, ActionType.Create, newGroup.Id);
				}
				catch (Exception ex)
				{
					return JsonResponse(StatusType.ERROR, ex.Message);
				}
			}
			else
			{
				return JsonResponse(StatusType.ERROR, ModelState);
			}
		}
		[HttpGet]
		[RequiresPermission(UserPermissions.Manager_UserGroup_Edit)]
		public async Task<IActionResult> Edit(Guid id)
		{
			var group = _groupRepository.Datas.Find(id);
			var groupModel = new UserGroupViewModel()
			{
				id = group.Id,
				parentId = group.ParentId,
				name = group.Name,
				active = group.Active
			};
			return View(groupModel);
		}

		[HttpPost]
		[RequiresPermission(UserPermissions.Manager_UserGroup_Edit)]
		public async Task<IActionResult> Edit(UserGroupViewModel editModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var group = _groupRepository.Datas.Find(editModel.id);
					var groupModel = new UserGroupViewModel()
					{
						id = group.Id,
						parentId = group.ParentId,
						name = group.Name,
						active = group.Active
					};

					if (groupModel.parentId == null || groupModel.parentId == new Guid())
						throw new Exception(_localizer["You could not edit root group"].Value);

					if (_groupRepository.Datas.Any(g => g.Id != editModel.id && g.ParentId == groupModel.parentId && g.Name == editModel.name))
						throw new Exception(string.Format(_localizer["Group {0} has exists"].Value, groupModel.name));

				//	group.ParentId = groupModel.parentId;
					group.Name = editModel.name;
					group.Active = editModel.active;

					await _groupRepository.UpdateAsync(group);

					return JsonResponse(1, ActionType.Edit, group.Id);

				}
				catch (Exception ex)
				{
					return JsonResponse(StatusType.ERROR, ex.Message);
				}
			}
			else
			{
				return JsonResponse(StatusType.ERROR, ModelState);
			}
		}

		[HttpGet]
		[RequiresPermission(UserPermissions.Manager_UserGroup_Delete)]
		public async Task<IActionResult> Delete(Guid id)
		{
			var group = _groupRepository.Datas.Find(id);
			var model = new DeleteViewModel()
			{
				Id = group.Id,
				Name = group.Name
			};
			return View(model);
		}

		[HttpPost]
		[RequiresPermission(UserPermissions.Manager_UserGroup_Delete)]
		public async Task<IActionResult> Delete(DeleteViewModel model)
		{
			try
			{
				List<Group> groupToRemoves = new List<Group>();

				GetGroupToRemove(model.Id, groupToRemoves);

				await _groupRepository.DeleteAsync(groupToRemoves);

				return JsonResponse(1, ActionType.Delete);

			}
			catch (Exception ex)
			{
				return JsonResponse(StatusType.ERROR, ex.Message);
			}
		}

		private void GetGroupToRemove(Guid key, List<Group> groupToRemoves)
		{
			var group = _groupRepository.Datas
				.Where(g => g.Id == key)
				.Include(g => g.Childrens)
				.First();

			if (group.Childrens.Count > 0)
			{
				foreach (var child in group.Childrens)
					GetGroupToRemove(child.Id, groupToRemoves);
			}

			groupToRemoves.Add(group);
		}
		[HttpGet]
		[RequiresPermission(UserPermissions.Manager_UserGroup_Access)]
		public async Task<IActionResult> GetAllUserGroup([DataSourceRequest]DataSourceRequest request, bool includeDisabled = false)
		{
			var userId = Guid.Parse(_userManager.GetUserId(User));

			var groups = await _userRepository.GetGroupAndInheritableOfUser(userId);

			var lstResult = groups
				.Where( g => includeDisabled ? true : g.Active)
				.Select(g => new UserGroupViewModel()
			{
				id = g.Id,
				parentId = g.ParentId,
				name = g.Name,
				active = g.Active
			}).ToList();

			foreach (var group in lstResult.Where(g => g.parentId != null && !groups.Any(gp => gp.Id == g.parentId)).ToList())
				group.parentId = null;

			var dataSource = lstResult.ToDataSourceResult(request);

			foreach (UserGroupViewModel group in dataSource.Data)
			{
				if (!dataSource.Data.Cast<UserGroupViewModel>().Any(a => a.id == group.parentId))
				{
					group.parentId = null;
				}
			}

			return Json(dataSource);
		}

		[HttpGet]
		[RequiresPermission(UserPermissions.Manager_UserGroup_Access)]
		public async Task<IActionResult> GetPermissionCanSetForGroup([DataSourceRequest]DataSourceRequest request, Guid groupId)
		{
			try
			{
				var group = _groupRepository.Datas.Find(groupId);

				var currentUserId = Guid.Parse(_userManager.GetUserId(User));
				var currentUser = _userRepository.Datas.Find(currentUserId);
				var userPermissions = await _userRepository.GetUserPermissionIdsAsync(currentUser);

				List<GroupPermissionViewModel> lstResult = new List<GroupPermissionViewModel>();

				if (group.ParentId == null)
				{
					var permissions = await _groupRepository.GetAllPermission(group.Id, userPermissions);

					lstResult = permissions.OrderBy(p => p.Index).Select(p => new GroupPermissionViewModel()
					{
						check = true,
						groupId = groupId,
						permissionId = p.Id,
						permissionParentId = p.ParentId,
						permissionDisplayName = p.DisplayName
					}).ToList();
				}
				else
				{
					var parentPermissions = await _groupRepository.GetAllPermission((Guid)group.ParentId, userPermissions);

					var pType = PermissionTypeEnum.UserPermission.ToString();
					var groupPermissions = await _groupPermissionReposiroty.Datas.Where(gp => gp.GroupId == group.Id)
						.Include(gp => gp.Permission)
						.Select(gp => gp.Permission)
						.Where(p => p.Type == pType)
						.ToListAsync();
					foreach (var permission in groupPermissions.Where(p => p.ParentId != null && !groupPermissions.Any(pp => pp.Id == p.ParentId)).ToList())
						RemovePermissionAndInheritable(permission, groupPermissions);

					lstResult = parentPermissions.OrderBy(p => p.Index).Select(p => new GroupPermissionViewModel()
					{
						check = groupPermissions.Any(pp => pp.Id == p.Id),
						groupId = groupId,
						permissionId = p.Id,
						permissionParentId = p.ParentId,
						permissionDisplayName = p.DisplayName
					}).ToList();
				}

				foreach (var permission in lstResult)
				{
					permission.permissionDisplayName = _localizer[permission.permissionDisplayName].Value;
				}
				return Json(lstResult.ToDataSourceResult(request));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		[RequiresPermission(UserPermissions.Manager_UserGroup_SetPermission)]
		public async Task<IActionResult> LoadPermission(Guid id)
		{
			var group = _groupRepository.Datas.Find(id);
			var model = new LoadPermissionIndexViewModel()
			{
				UserGroupID = id,
				UserGroupName = group.Name
			};
			return View(model);
		}

		[HttpPost]
		[RequiresPermission(UserPermissions.Manager_UserGroup_SetPermission)]
		public async Task<IActionResult> SetPermission(Guid groupId, IEnumerable<Guid> permissionIds)
		{
			try
			{
				var group = _groupRepository.Datas.Where(g => g.Id == groupId)
					.Include(g => g.Parent)
					.Include(g => g.Group_Permissions)
					.First();

				var userId = Guid.Parse(_userManager.GetUserId(User));
				var user = _userRepository.Datas.Find(userId);
				var userPermissions = await _userRepository.GetUserPermissionIdsAsync(user);
				var groups = await _userRepository.GetGroupAndInheritableOfUser(userId);

				if (group.Parent == null || !groups.Any(g => g.Id == group.Parent.Id))
					throw new Exception(_localizer["You could not change permission for your group.<br/>Contact to your superior."].Value);

				// Lấy các quyền của nhóm cha mà người dùng hiện tại đang được set
				var permissionCanSets = await _groupRepository.GetAllPermission(group.Parent.Id, userPermissions);
				// Các quyền set cho group
				var permissionIdsSet = permissionIds.ToList();

				// Xóa các quyền mà người dùng hiện tại không được set
				foreach (var id in permissionIdsSet.Where(pid => !permissionCanSets.Any(p => p.Id == pid)).ToList())
					permissionIdsSet.Remove(id);

				// Lấy các quyền cần set trong db
				var permissions = _permissionRepository.Datas
					.Where(p => permissionIdsSet.Contains(p.Id))
					.ToList();

				// Xóa các quyền mà không có quyền cha
				foreach (var permission in permissions.Where(p => p.ParentId != null && !permissions.Any(pp => pp.Id == p.ParentId)).ToList())
					permissions.Remove(permission);

				// Xóa các quyền không còn nữa
				foreach (var permission in group.Group_Permissions.Where(p => permissionCanSets.Any(ps => ps.Id == p.PermissionId) && !permissions.Any(ps => ps.Id == p.PermissionId)).ToList())
					group.Group_Permissions.Remove(permission);

				// Thêm các quyền chưa có
				foreach (var permission in permissions.Where(p => !group.Group_Permissions.Any(ps => ps.PermissionId == p.Id)).ToList())
					group.Group_Permissions.Add(new Group_Permission()
					{
						GroupId = group.Id,
						PermissionId = permission.Id
					});

				var pIds = group.Group_Permissions.Select(p => p.PermissionId).ToList();
				var pers = _permissionRepository.Datas.Where(p => pIds.Contains(p.Id)).ToList();
				var premoves = pers.Where(p => p.ParentId != null && !pers.Any(pp => pp.Id == p.ParentId)).Select(p => p.Id).ToList();
				// Xóa các quyền của group không có cha
				foreach (var permission in group.Group_Permissions.Where(p => premoves.Contains(p.PermissionId)).ToList())
					group.Group_Permissions.Remove(permission);

				await _groupPermissionReposiroty.SaveChangesAsync();

				return JsonResponse(StatusType.OK, _localizer["Set permission success"].Value);
			}
			catch (Exception ex)
			{
				return JsonResponse(StatusType.ERROR, ex.Message);
			}
		}
		private void RemovePermissionAndInheritable(Entities.Entities.Security.Permission permission, List<Entities.Entities.Security.Permission> lstPermission)
		{
			if (lstPermission.Contains(permission))
			{
				foreach (var children in lstPermission.Where(g => g.ParentId == permission.Id).ToList())
					RemovePermissionAndInheritable(children, lstPermission);

				lstPermission.Remove(permission);
			}
		}


	}
}