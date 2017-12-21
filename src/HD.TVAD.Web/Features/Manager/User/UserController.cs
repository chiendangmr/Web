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
using HD.TVAD.Web.Features.Managers.UserGroup.Models;
using HD.TVAD.Entities.Repositories;
using HD.TVAD.Web.Models;
using Newtonsoft.Json;
using HD.TVAD.Web.Features.Manager;
using HD.TVAD.Web.Features.Managers.User.Models;
using HD.TVAD.Web.Infrastructure;
using HD.TVAD.Web.StartData;

namespace HD.TVAD.Features.Manager
{
    [Area("Manager")]
	[Authorize]
	public class UserController : TVADController
	{
		private readonly IUserRepository<User> _userRepository;
		readonly IRepository<Group_User> _groupUserRepository;
		private readonly IGroupRepository<Group> _groupRepository;
		readonly IRepository<Entities.Entities.Security.Permission> _permissionRepository;
		readonly IRepository<Group_Permission> _groupPermissionReposiroty;
		readonly IPasswordHasher<User> _passwordHasher;

		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		readonly IStringLocalizer<UserController> _localizer;

		public UserController(
			IUserRepository<User> userRepository,
			IGroupRepository<Group> groupRepository,
			IRepository<Group_User> groupUserRepository,
			IRepository<Entities.Entities.Security.Permission> permissionRepository,
			IRepository<Group_Permission> groupPermissionReposiroty,
			UserManager<User> userManager,
			SignInManager<User> signInManager,
			IPasswordHasher<User> passwordHasher,
			  IStringLocalizer<UserController> localizer)
		{
			_userRepository = userRepository;
			_groupRepository = groupRepository;
			_groupUserRepository = groupUserRepository;
			_userManager = userManager;
			_signInManager = signInManager;
			_localizer = localizer;
			_passwordHasher = passwordHasher;
		}

		[RequiresPermission(UserPermissions.Manager_User)]
		public async Task<IActionResult> Index()
		{

			return View();
		}

		[RequiresPermission(UserPermissions.Manager_User_Create)]
		public async Task<IActionResult> Create()
		{

			return View();
		}
		[HttpPost]
		[RequiresPermission(UserPermissions.Manager_UserGroup_Create)]
		public async Task<IActionResult> Create(UserCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var userModel = new UserViewModel() {
						name = viewModel.Name,
						active = viewModel.Active,
						email = viewModel.Email,
						fullName = viewModel.FullName,
						password = viewModel.Password,
						phoneNumber = viewModel.PhoneNumber,
						userName = viewModel.UserName
					};

					if (_userRepository.Datas.Any(u => u.UserName == userModel.userName))
						throw new Exception(_localizer["User " + userModel.userName + " has exists"].Value);

					var newUser = new User()
					{
						UserName = userModel.userName,
						Name = userModel.name,
						PasswordHash = _passwordHasher.HashPassword(null, userModel.password),
						FullName = userModel.fullName,
						Email = userModel.email,
						PhoneNumber = userModel.phoneNumber,
						Active = userModel.active
					};

					await _userRepository.InsertAsync(newUser);

					return JsonResponse(1, ActionType.Create, newUser.Id);
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
		[RequiresPermission(UserPermissions.Manager_User_Create)]
		public async Task<IActionResult> Edit(Guid id)
		{
			var user = _userRepository.Datas.Find(id);
			var viewModel = new UserEditViewModel()
			{
				UserName = user.UserName,
				Id = user.Id,
				PhoneNumber = user.PhoneNumber,
				Name = user.Name,
				Email = user.Email,
				FullName = user.FullName,
				Active = user.Active
			};
			return View(viewModel);
		}
		[HttpPost]
		[RequiresPermission(UserPermissions.Manager_User_Edit)]
		public async Task<IActionResult> Edit(UserEditViewModel editModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var user = _userRepository.Datas.Find(editModel.Id);			

					if (_userRepository.Datas.Any(u => u.Id != editModel.Id && u.UserName == editModel.UserName))
						throw new Exception(string.Format(_localizer["User name {0} has exists"].Value, editModel.UserName));

			//		user.UserName = editModel.UserName;
					if (!string.IsNullOrEmpty(editModel.Password))
						user.PasswordHash = _passwordHasher.HashPassword(null, editModel.Password);
					user.Name = editModel.Name;
					user.FullName = editModel.FullName;
					user.Email = editModel.Email;
					user.PhoneNumber = editModel.PhoneNumber;
					user.Active = editModel.Active;

					await _userRepository.UpdateAsync(user);

					return JsonResponse(1, ActionType.Edit, user.Id);

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
		[RequiresPermission(UserPermissions.Manager_User_Delete)]
		public async Task<IActionResult> Delete(Guid id)
		{
			var user = _userRepository.Datas.Find(id);
			var model = new DeleteViewModel()
			{
				Id = user.Id,
				Name = user.UserName
			};
			return View(model);
		}

		[HttpPost]
		[RequiresPermission(UserPermissions.Manager_User_Delete)]
		public async Task<IActionResult> Delete(DeleteViewModel model)
		{
			try
			{
				var user = _userRepository.Datas.Find(model.Id);
				await _userRepository.DeleteAsync(user);
				return JsonResponse(1, ActionType.Delete);
			}
			catch (Exception ex)
			{
				return JsonResponse(StatusType.ERROR, ex.Message);
			}
		}
		[HttpGet]
		[RequiresPermission(UserPermissions.Manager_User_SetUserGroup)]
		public async Task<IActionResult> SetGroup(Guid id)
		{
			var user = _userRepository.Datas.Find(id);
			var viewModel = new SetGroupIndexViewModel()
			{
				UserId = id,
				UserName = user.UserName,
			};
			return View(viewModel);
		}

		[HttpGet]
		[RequiresPermission(UserPermissions.Manager_User_Access)]
		public async Task<IActionResult> GetAllUser([DataSourceRequest]DataSourceRequest request, bool includeDisabled = false)
		{
			try
			{
				var userId = Guid.Parse(_userManager.GetUserId(User));

				var groups = (await _userRepository.GetGroupAndInheritableOfUser(userId)).ToList();

				// Lấy các user trong các nhóm mình quản lý
				foreach (var group in groups.Where(g => g.ParentId == null || !groups.Any(gp => gp.Id == g.ParentId)).ToList())
					groups.Remove(group);
				var groupIds = groups.Select(g => g.Id).ToList();

				var userIds = _groupUserRepository.Datas.Where(gu => groupIds.Contains(gu.GroupId)).Select(gu => gu.UserId).Distinct().ToList();

				var query = _userRepository.Datas
					.Where(u => userIds.Contains(u.Id) || !_groupUserRepository.Datas.Any(gu => gu.UserId == u.Id))
					.Where(u => includeDisabled ? true : u.Active )
					.Select(u => new UserViewModel
					{
						id = u.Id,
						name = u.Name,
						userName = u.UserName,
						fullName = u.FullName,
						email = u.Email,
						phoneNumber = u.PhoneNumber,
						active = u.Active
					});

				var dataSource = query.ToDataSourceResult(request);

				return Json(dataSource);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpGet]
		[RequiresPermission(UserPermissions.Manager_User_SetUserGroup)]
		public async Task<IActionResult> GetGroupsOfUser([DataSourceRequest]DataSourceRequest request, Guid userId)
		{
			try
			{
				var currentUserId = Guid.Parse(_userManager.GetUserId(User));

				var groupCanSets = (await _userRepository.GetGroupAndInheritableOfUser(currentUserId)).ToList();

				// Chỉ set các nhóm trong
				foreach (var group in groupCanSets.Where(g => g.ParentId == null || !groupCanSets.Any(gg => gg.Id == g.ParentId)).ToList())
					groupCanSets.Remove(group);

				var groupSets = (await _userRepository.GetGroupAndInheritableOfUser(userId)).ToList();

				List<UserGroupSetModel> lstResult = new List<UserGroupSetModel>();

				foreach (var group in groupCanSets.Where(g => !groupCanSets.Any(gg => gg.Id == g.ParentId)))
					CreateGroupSetAndInheritable(group, groupCanSets, groupSets, lstResult, true);

				foreach (var group in lstResult.Where(g => g.parentId != null && !lstResult.Any(gg => gg.id == g.parentId)))
					group.parentId = null;

				return Json(lstResult.ToDataSourceResult(request));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		private void CreateGroupSetAndInheritable(Group group, List<Group> lstSource, List<Group> lstSet, List<UserGroupSetModel> lstResult, bool check = true)
		{
			if (!lstResult.Any(g => g.id == group.Id))
			{
				var isSet = check ? lstSet.Any(g => g.Id == group.Id) : true;
				lstResult.Add(new UserGroupSetModel()
				{
					check = isSet,
					id = group.Id,
					parentId = group.ParentId,
					name = group.Name
				});

				foreach (var child in lstSource.Where(g => g.ParentId == group.Id))
				{
					CreateGroupSetAndInheritable(child, lstSource, lstSet, lstResult, !isSet);
				}
			}
		}

		[HttpPost]
		[RequiresPermission(UserPermissions.Manager_User_SetUserGroup)]
		public async Task<IActionResult> SetGroup(Guid userId, IEnumerable<Guid> groupIds)
		{
			//TODO: Check admin perrmission
			try
			{
				var currentUserId = Guid.Parse(_userManager.GetUserId(User));

				var groupCanSets = (await _userRepository.GetGroupAndInheritableOfUser(currentUserId)).ToList();

				// Chỉ set các nhóm trong
				foreach (var group in groupCanSets.Where(g => g.ParentId == null || !groupCanSets.Any(gg => gg.Id == g.ParentId)).ToList())
					groupCanSets.Remove(group);

				// Group cần set
				var _groupIds = groupIds.ToList();

				// Chỉ set trong số các group được set
				foreach (var id in _groupIds.Where(i => !groupCanSets.Any(g => g.Id == i)).ToList())
					_groupIds.Remove(id);

				var groupSets = groupCanSets.Where(g => _groupIds.Contains(g.Id)).ToList();
				// Không cần set các group trong
				foreach (var group in groupSets.Where(gs => groupSets.Any(gg => gg.Id == gs.ParentId)).ToList())
					groupSets.Remove(group);

				var user = _userRepository.Datas.Where(u => u.Id == userId)
					.Include(u => u.Group_Users)
					.First();

				// Xóa các group không còn nữa
				foreach (var group in user.Group_Users.Where(g => groupCanSets.Any(gs => gs.Id == g.GroupId) && !groupSets.Any(gs => gs.Id == g.GroupId)).ToList())
					user.Group_Users.Remove(group);
				// Thêm các group mới
				foreach (var group in groupSets.Where(g => !user.Group_Users.Any(gg => gg.GroupId == g.Id)).ToList())
					user.Group_Users.Add(new Group_User()
					{
						UserId = user.Id,
						GroupId = group.Id
					});
				await _userRepository.UpdateAsync(user);

				return JsonResponse(StatusType.OK, _localizer["Set group success"].Value);
			}
			catch (Exception ex)
			{
				return JsonResponse(StatusType.ERROR, ex.Message);
			}
		}


		[HttpGet]
		[RequiresPermission(UserPermissions.Manager_User_SetPermission)]
		public async Task<IActionResult> LoadPermission(Guid id)
		{
			var user = _userRepository.Datas.Find(id);
			var model = new LoadUserPermissionIndexViewModel()
			{
				UserId = id,
				UserName = user.UserName
			};
			return View(model);
		}
		[HttpGet]
		[RequiresPermission(UserPermissions.Manager_User_SetPermission)]
		public async Task<IActionResult> GetPermissionsOfUser([DataSourceRequest]DataSourceRequest request, Guid userId)
		{
			try
			{
				// Lấy các nhóm của tài khoản hiện tại
				var currentUserId = Guid.Parse(_userManager.GetUserId(User));
				var user = _userRepository.Datas.Where(u => u.Id == currentUserId)
					.Include(u => u.User_Permissions).First();
				var pers = await _userRepository.GetUserPermissionIdsAsync(user);

				var groups = (await _userRepository.GetGroupAndInheritableOfUser(currentUserId)).ToList();

				// Chỉ cần lấy các quyền của các nhóm ngoài
				foreach (var group in groups.Where(g => groups.Any(gg => gg.Id == g.ParentId)).ToList())
					groups.Remove(group);

				List<Entities.Entities.Security.Permission> lstPermission = new List<Entities.Entities.Security.Permission>();
				foreach (var group in groups)
				{
					var permissions = await _groupRepository.GetAllPermission(group.Id, pers);
					var perNews = permissions.Where(p => !lstPermission.Any(pp => pp.Id == p.Id)).ToList();
					if (perNews.Count > 0)
						lstPermission.AddRange(perNews);
				}

				foreach (var permission in lstPermission.Where(p => p.ParentId != null && !lstPermission.Any(pp => pp.Id == p.ParentId)).ToList())
					lstPermission.Remove(permission);

				user = _userRepository.Datas.Where(u => u.Id == userId)
					.Include(u => u.User_Permissions).First();

				List<UserPermissionSetModel> lstResult = lstPermission.OrderBy(p => p.Index).Select(p => new UserPermissionSetModel()
				{
					check = user.User_Permissions.Any(pp => pp.PermissionId == p.Id),
					id = p.Id,
					parentId = p.ParentId,
					name = _localizer[p.DisplayName].Value
				}).ToList();

				foreach (var permission in lstResult.Where(p => p.id != null && !lstResult.Any(pp => pp.id == p.parentId)).ToList())
					permission.parentId = null;

				return Json(lstResult.ToDataSourceResult(request));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpPost]
		[RequiresPermission(UserPermissions.Manager_User_SetPermission)]
		public async Task<IActionResult> SetPermission(Guid userId, IEnumerable<Guid> permissionIds)
		{
			try
			{
				var currentUserId = Guid.Parse(_userManager.GetUserId(User));
				var user = _userRepository.Datas.Where(u => u.Id == currentUserId)
					.Include(u => u.User_Permissions).First();
				var pers = await _userRepository.GetUserPermissionIdsAsync(user);
				var groups = (await _userRepository.GetGroupAndInheritableOfUser(currentUserId)).ToList();
				// Chỉ cần lấy các quyền của các nhóm ngoài
				foreach (var group in groups.Where(g => groups.Any(gg => gg.Id == g.ParentId)).ToList())
					groups.Remove(group);
				List<Entities.Entities.Security.Permission> lstPermissionCanSet = new List<Entities.Entities.Security.Permission>();
				foreach (var group in groups)
				{
					var permissions = await _groupRepository.GetAllPermission(group.Id, pers);
					var perNews = permissions.Where(p => !lstPermissionCanSet.Any(pp => pp.Id == p.Id)).ToList();
					if (perNews.Count > 0)
						lstPermissionCanSet.AddRange(perNews);
				}
				foreach (var permission in lstPermissionCanSet.Where(p => p.ParentId != null && !lstPermissionCanSet.Any(pp => pp.Id == p.ParentId)).ToList())
					lstPermissionCanSet.Remove(permission);

				// Permission cần set
				var _permissionIds = permissionIds.ToList();

				// Chỉ set trong số các permission được set
				foreach (var id in _permissionIds.Where(i => !lstPermissionCanSet.Any(g => g.Id == i)).ToList())
					_permissionIds.Remove(id);

				var permissionSets = lstPermissionCanSet.Where(p => _permissionIds.Contains(p.Id)).ToList();

				user = _userRepository.Datas.Where(u => u.Id == userId)
					.Include(u => u.User_Permissions).First();

				using (var transaction = _userRepository.BeginTransaction())
				{
					// Xóa các quyền không có cha
					foreach (var permission in permissionSets.Where(p => p.ParentId != null && !permissionSets.Any(pp => pp.Id == p.ParentId)).ToList())
						permissionSets.Remove(permission);

					// Xóa các quyền của user đã bị bỏ
					foreach (var permission in user.User_Permissions.Where(p => lstPermissionCanSet.Any(ps => ps.Id == p.PermissionId) && !permissionSets.Any(ps => ps.Id == p.PermissionId)).ToList())
						user.User_Permissions.Remove(permission);
					// Thêm các quyền mới
					foreach (var permission in permissionSets.Where(p => !user.User_Permissions.Any(pp => pp.PermissionId == p.Id)).ToList())
						user.User_Permissions.Add(new User_Permission()
						{
							UserId = user.Id,
							PermissionId = permission.Id
						});

					await _userRepository.UpdateAsync(user);

					transaction.Commit();

					return JsonResponse(StatusType.OK, _localizer["Set permission success"].Value);
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}