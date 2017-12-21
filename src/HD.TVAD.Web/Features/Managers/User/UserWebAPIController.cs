using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using HD.TVAD.Entities.Entities.Security;
using HD.TVAD.Entities.Repositories;
using HD.TVAD.Entities.Repositories.Security;
using HD.TVAD.Web.Features.Managers.User.Models;
using HD.TVAD.Web.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Managers.User
{
    [Route("api/managers/[controller]/[action]")]
    [Authorize]
    public class UserWebAPIController : Controller
    {
        readonly UserManager<HD.TVAD.Entities.Entities.Security.User> _userManager;

        readonly IGroupRepository<Group> _groupRepository;

        readonly IUserRepository<HD.TVAD.Entities.Entities.Security.User> _userRepository;

        readonly IRepository<Group_User> _groupUserRepository;

        readonly IPasswordHasher<HD.TVAD.Entities.Entities.Security.User> _passwordHasher;

        readonly IStringLocalizer<UserWebAPIController> _localizer;

        public UserWebAPIController(UserManager<HD.TVAD.Entities.Entities.Security.User> userManager,
            IGroupRepository<Group> groupRepository,
            IUserRepository<HD.TVAD.Entities.Entities.Security.User> userRepository,
            IRepository<Group_User> groupUserRepository,
            IPasswordHasher<HD.TVAD.Entities.Entities.Security.User> passwordHasher,
            IStringLocalizer<UserWebAPIController> localizer)
        {
            _userManager = userManager;
            _groupRepository = groupRepository;
            _userRepository = userRepository;
            _groupUserRepository = groupUserRepository;
            _passwordHasher = passwordHasher;
            _localizer = localizer;
        }

        [HttpGet]
        public async Task<object> Get(DataSourceLoadOptions loadOptions)
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

                return DataSourceLoader.Load(query, loadOptions);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            try
            {
                var userModel = new UserViewModel();
                JsonConvert.PopulateObject(values, userModel);

                if (!TryValidateModel(userModel))
                    return BadRequest(ModelState.GetFullErrorMessage());

                if (string.IsNullOrEmpty(userModel.password))
                    throw new Exception(_localizer["Please enter start password"].Value);

                if (_userRepository.Datas.Any(u => u.UserName == userModel.userName))
                    throw new Exception(_localizer["User " + userModel.userName + " has exists"].Value);

                var newUser = new HD.TVAD.Entities.Entities.Security.User()
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

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            try
            {
                var user = _userRepository.Datas.Find(key);
                var userModel = new UserViewModel()
                {
                    id = user.Id,
                    userName = user.UserName,
                    password = user.PasswordHash,
                    name = user.Name,
                    fullName = user.FullName,
                    email = user.Email,
                    phoneNumber = user.PhoneNumber,
                    active = user.Active
                };
                JsonConvert.PopulateObject(values, userModel);

                if (!TryValidateModel(userModel))
                    return BadRequest(ModelState.GetFullErrorMessage());

                if (_userRepository.Datas.Any(u => u.Id != key && u.UserName == userModel.userName))
                    throw new Exception(string.Format(_localizer["User name {0} has exists"].Value, userModel.userName));

                user.UserName = userModel.userName;
                if (!string.IsNullOrEmpty(userModel.password))
                    user.PasswordHash = _passwordHasher.HashPassword(null, userModel.password);
                user.Name = userModel.name;
                user.FullName = userModel.fullName;
                user.Email = userModel.email;
                user.PhoneNumber = userModel.phoneNumber;
                user.Active = userModel.active;

                await _userRepository.UpdateAsync(user);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid key)
        {
            try
            {
                var user = _userRepository.Datas.Find(key);

                await _userRepository.DeleteAsync(user);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        void CreateGroupSetAndInheritable(Group group, List<Group> lstSource, List<Group> lstSet, List<UserGroupSetModel> lstResult, bool check = true)
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

                foreach(var child in lstSource.Where(g=>g.ParentId == group.Id))
                {
                    CreateGroupSetAndInheritable(child, lstSource, lstSet, lstResult, !isSet);
                }
            }
        }

        [HttpGet]
        public async Task<object> GetGroupsOfUser(Guid userId, DataSourceLoadOptions loadOptions)
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

                return DataSourceLoader.Load(lstResult, loadOptions);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public class UserSetGroups
        {
            public Guid userId { get; set; }

            public string groupIds { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> SetGroupsOfUser([FromBody] UserSetGroups userSetGroups)
        {
            try
            {
                var currentUserId = Guid.Parse(_userManager.GetUserId(User));

                var groupCanSets = (await _userRepository.GetGroupAndInheritableOfUser(currentUserId)).ToList();

                // Chỉ set các nhóm trong
                foreach (var group in groupCanSets.Where(g => g.ParentId == null || !groupCanSets.Any(gg => gg.Id == g.ParentId)).ToList())
                    groupCanSets.Remove(group);

                // Group cần set
                var groupIds = JsonConvert.DeserializeObject<List<string>>(userSetGroups.groupIds).Select(idstr => Guid.Parse(idstr)).ToList();

                // Chỉ set trong số các group được set
                foreach (var id in groupIds.Where(i => !groupCanSets.Any(g => g.Id == i)).ToList())
                    groupIds.Remove(id);

                var groupSets = groupCanSets.Where(g => groupIds.Contains(g.Id)).ToList();
                // Không cần set các group trong
                foreach (var group in groupSets.Where(gs => groupSets.Any(gg => gg.Id == gs.ParentId)).ToList())
                    groupSets.Remove(group);

                var user = _userRepository.Datas.Where(u => u.Id == userSetGroups.userId)
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

                return Json(userSetGroups);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<object> GetPermissionsOfUser(Guid userId, DataSourceLoadOptions loadOptions)
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

				List<UserPermissionSetModel> lstResult = lstPermission.OrderBy(p=>p.Index).Select(p => new UserPermissionSetModel()
                {
                    check = user.User_Permissions.Any(pp => pp.PermissionId == p.Id),
                    id = p.Id,
                    parentId = p.ParentId,
                    name = _localizer[p.DisplayName].Value
                }).ToList();

                foreach (var permission in lstResult.Where(p => p.id != null && !lstResult.Any(pp => pp.id == p.parentId)).ToList())
                    permission.parentId = null;

                return DataSourceLoader.Load(lstResult, loadOptions);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public class UserSetPermissions
        {
            public Guid userId { get; set; }

            public string permissionIds { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> SetPermissionsOfUser([FromBody] UserSetPermissions userSetPermissions)
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
                var permissionIds = JsonConvert.DeserializeObject<List<string>>(userSetPermissions.permissionIds).Select(idstr => Guid.Parse(idstr)).ToList();

                // Chỉ set trong số các permission được set
                foreach (var id in permissionIds.Where(i => !lstPermissionCanSet.Any(g => g.Id == i)).ToList())
                    permissionIds.Remove(id);

                var permissionSets = lstPermissionCanSet.Where(p => permissionIds.Contains(p.Id)).ToList();

				user = _userRepository.Datas.Where(u => u.Id == userSetPermissions.userId)
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

                    return Json(userSetPermissions);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
