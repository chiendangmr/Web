using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using HD.TVAD.Entities.Entities.Security;
using HD.TVAD.Entities.Repositories;
using HD.TVAD.Entities.Repositories.Security;
using HD.TVAD.Web.Features.Managers.UserGroup.Models;
using HD.TVAD.Web.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Managers.UserGroup
{
    [Route("api/managers/[controller]/[action]")]
    [Authorize]
    public class UserGroupWebAPIController : Controller
    {
        readonly UserManager<HD.TVAD.Entities.Entities.Security.User> _userManager;

        readonly IGroupRepository<Group> _groupRepository;

        readonly IUserRepository<Entities.Entities.Security.User> _userRepository;

        readonly Entities.Repositories.IRepository<Entities.Entities.Security.Permission> _permissionRepository;

        readonly Entities.Repositories.IRepository<Group_Permission> _groupPermissionReposiroty;

        readonly IStringLocalizer<UserGroupWebAPIController> _localizer;

        public UserGroupWebAPIController(UserManager<HD.TVAD.Entities.Entities.Security.User> userManager,
            IGroupRepository<Group> groupRepository,
            IUserRepository<Entities.Entities.Security.User> userRepository,
            Entities.Repositories.IRepository<Entities.Entities.Security.Permission> permissionRepository,
            Entities.Repositories.IRepository<Group_Permission> groupPermissionReposiroty,
            IStringLocalizer<UserGroupWebAPIController> localizer)
        {
            _userManager = userManager;
            _groupRepository = groupRepository;
            _userRepository = userRepository;
            _permissionRepository = permissionRepository;
            _groupPermissionReposiroty = groupPermissionReposiroty;
            _localizer = localizer;
        }

        [HttpGet]
        public async Task<object> Get(DataSourceLoadOptions loadOptions)
        {
            var userId = Guid.Parse(_userManager.GetUserId(User));

            var groups = await _userRepository.GetGroupAndInheritableOfUser(userId);

            var lstResult = groups.Select(g => new UserGroupViewModel()
            {
                id = g.Id,
                parentId = g.ParentId,
                name = g.Name
            }).ToList();
            foreach (var group in lstResult.Where(g => g.parentId != null && !groups.Any(gp => gp.Id == g.parentId)).ToList())
                group.parentId = null;

            return DataSourceLoader.Load(lstResult, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            try
            {
                var groupModel = new UserGroupViewModel();
                JsonConvert.PopulateObject(values, groupModel);

                if (!TryValidateModel(groupModel))
                    return BadRequest(ModelState.GetFullErrorMessage());

                if (_groupRepository.Datas.Any(g => g.ParentId == groupModel.parentId && g.Name == groupModel.name))
                    throw new Exception(string.Format(_localizer["Group {0} has exists"].Value, groupModel.name));

                var newGroup = new Group()
                {
                    Name = groupModel.name,
                    ParentId = groupModel.parentId
                };

                await _groupRepository.InsertAsync(newGroup);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Guid key, string values)
        {
            try
            {
                var group = _groupRepository.Datas.Find(key);
                var groupModel = new UserGroupViewModel()
                {
                    id = group.Id,
                    parentId = group.ParentId,
                    name = group.Name
                };
                JsonConvert.PopulateObject(values, groupModel);

                if (!TryValidateModel(groupModel))
                    return BadRequest(ModelState.GetFullErrorMessage());

                if (groupModel.parentId == null || groupModel.parentId == new Guid())
                    throw new Exception(_localizer["You could not edit root group"].Value);

                if (_groupRepository.Datas.Any(g => g.Id != key && g.ParentId == groupModel.parentId && g.Name == groupModel.name))
                    throw new Exception(string.Format(_localizer["Group {0} has exists"].Value, groupModel.name));

                group.ParentId = groupModel.parentId;
                group.Name = groupModel.name;

                await _groupRepository.UpdateAsync(group);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        void GetGroupToRemove(Guid key, List<Group> groupToRemoves)
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

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid key)
        {
            try
            {
                List<Group> groupToRemoves = new List<Group>();

                GetGroupToRemove(key, groupToRemoves);

                await _groupRepository.DeleteAsync(groupToRemoves);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        void RemovePermissionAndInheritable(Entities.Entities.Security.Permission permission, List<Entities.Entities.Security.Permission> lstPermission)
        {
            if (lstPermission.Contains(permission))
            {
                foreach (var children in lstPermission.Where(g => g.ParentId == permission.Id).ToList())
                    RemovePermissionAndInheritable(children, lstPermission);

                lstPermission.Remove(permission);
            }
        }

        [HttpGet]
        public async Task<object> GetPermissionCanSetForGroup(Guid groupId)
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

                foreach(var permission in lstResult)
                {
                    permission.permissionDisplayName = _localizer[permission.permissionDisplayName].Value;
                }
                return Json(lstResult);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public class GroupPermissions
        {
            public Guid groupId { get; set; }

            public string permissionIds { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> SetPermissionForGroup([FromBody] GroupPermissions groupPermissions)
        {
            try
            {
                var group = _groupRepository.Datas.Where(g => g.Id == groupPermissions.groupId)
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
                var permissionIdsSet = JsonConvert.DeserializeObject<List<string>>(groupPermissions.permissionIds).Select(str => Guid.Parse(str)).ToList();
                
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
                var premoves = pers.Where(p => p.ParentId != null && !pers.Any(pp => pp.Id == p.ParentId)).Select(p=>p.Id).ToList();
                // Xóa các quyền của group không có cha
                foreach (var permission in group.Group_Permissions.Where(p => premoves.Contains(p.PermissionId)).ToList())
                    group.Group_Permissions.Remove(permission);
                
                await _groupPermissionReposiroty.SaveChangesAsync();

                return Json(groupPermissions);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
