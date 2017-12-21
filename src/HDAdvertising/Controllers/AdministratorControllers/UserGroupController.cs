using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using HDAdvertising.Datas.Security;
using HDAdvertising.Models.AdministratorViewModels;
using HDAdvertising.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDAdvertising.Controllers.AdministratorControllers
{
    [Area("Manager")]
    //[Authorize(Roles = "Manager_UserGroup")]
    public class UserGroupController : Controller
    {
        readonly UserManager<User> _UserManager;

        readonly IService<Group> _GroupService;
        readonly IService<User> _UserService;
        readonly IService<Group_User> _Group_UserService;
        readonly IService<Permission> _PermissionService;
        readonly IService<Group_Permission> _Group_PermissionService;
        //readonly IService<Permission_Request> _Permission_RequestService;

        public UserGroupController(UserManager<User> userManager,
            IService<Group> groupService,
            IService<User> userService,
            IService<Group_User> group_UserService,
            IService<Permission> permissionService,
            IService<Group_Permission> group_PermissionService)
            //IService<Permission_Request> permission_RequestService)
        {
            _UserManager = userManager;
            _GroupService = groupService;
            _UserService = userService;
            _Group_UserService = group_UserService;
            _PermissionService = permissionService;
            _Group_PermissionService = group_PermissionService;
            //_Permission_RequestService = permission_RequestService;
        }

        public IActionResult Index()
        {
            return View();
        }

        void GetGroupChildrens(Group group, List<Group> result)
        {
            foreach (var child in group.Childrens)
            {
                if (result.SingleOrDefault(g => g.Id == child.Id) == null)
                {
                    var childDB = _GroupService.Datas
                        .Include(g => g.Childrens)
                        .SingleOrDefault(g => g.Id == child.Id);
                    result.Add(childDB);
                    GetGroupChildrens(childDB, result);
                }
            }
        }

        internal List<Group> GetGroupsOfUser(Guid userId)
        {
            // Chỉ lấy các nhóm mà tài khoản thuộc nhóm đó và các nhóm con
            var groups = _GroupService.Datas
                .Join(_Group_UserService.Datas,
                    g => g.Id,
                    gu => gu.GroupId,
                    (g, gu) => new { Group = g, GroupUser = gu })
                .Where(gu => gu.GroupUser.UserId == userId)
                .Select(gu => gu.Group)
                .Include(g => g.Childrens)
                .ToList();

            foreach (var group in groups.ToList())
                GetGroupChildrens(group, groups);

            return groups;
        }

        [HttpGet]
        public object GetGroupsOfCurrentUser(DataSourceLoadOptions loadOptions)
        {
            var userId = Guid.Parse(_UserManager.GetUserId(User));

            var modelViews = GetGroupsOfUser(userId).Select(g =>
                new GroupViewModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    ParentId = g.ParentId
                }).ToList();

            foreach (var model in modelViews.Where(m => m.ParentId != null && !modelViews.Any(mm => mm.Id == m.ParentId)))
                model.ParentId = null;

            return DataSourceLoader.Load(modelViews, loadOptions);
        }

        [HttpPost]
        [Authorize(Roles = "Manager_UserGroup_Edit")]
        public async Task<IActionResult> PostGroup(string values)
        {
            try
            {
                var groupModel = new GroupViewModel();
                JsonConvert.PopulateObject(values, groupModel);

                if (groupModel.ParentId == null || groupModel.ParentId == new Guid())
                    throw new Exception("Không được thêm nhóm tài khoản gốc");

                if (!TryValidateModel(groupModel))
                    throw new Exception(ModelState.GetFullErrorMessage());

                if (_GroupService.Datas.Any(g => g.Name == groupModel.Name))
                    throw new Exception("Trùng tên nhóm tài khoản");

                var newGroup = new Group()
                {
                    Name = groupModel.Name,
                    ParentId = groupModel.ParentId
                };

                await _GroupService.Create(newGroup);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "Manager_UserGroup_Edit")]
        public async Task<IActionResult> PutGroup(Guid key, string values)
        {
            try
            {
                var group = _GroupService.Datas.First(e => e.Id == key);

                var groupModel = new GroupViewModel()
                {
                    Id = group.Id,
                    ParentId = group.ParentId,
                    Name = group.Name
                };
                JsonConvert.PopulateObject(values, groupModel);
                if (!TryValidateModel(groupModel))
                    throw new Exception(ModelState.GetFullErrorMessage());

                if (groupModel.ParentId == null || groupModel.ParentId == new Guid())
                    throw new Exception("Không được sửa nhóm tài khoản gốc");

                if (_GroupService.Datas.Any(g => g.Id != key && g.Name == groupModel.Name))
                    throw new Exception("Trùng tên nhóm tài khoản");

                group.ParentId = groupModel.ParentId;
                group.Name = groupModel.Name;

                await _GroupService.Update(group);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        void GetGroupToRemove(Guid key, List<Group> groupToRemoves)
        {
            var group = _GroupService.Datas
                .Include(g => g.Childrens)
                .First(e => e.Id == key);
            
            if (group.Childrens.Count > 0)
            {
                foreach (var child in group.Childrens)
                    GetGroupToRemove(child.Id, groupToRemoves);
            }

            groupToRemoves.Add(group);
        }

        [HttpDelete]
        [Authorize(Roles = "Manager_UserGroup_Edit")]
        public async Task<IActionResult> DeleteGroup(Guid key)
        {
            try
            {
                List<Group> groupToRemoves = new List<Group>();

                GetGroupToRemove(key, groupToRemoves);

                await _GroupService.Delete(groupToRemoves);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        void CheckPermissionOfCurrentUser(Permission permission, List<Permission> permissions)
        {
            if(!User.IsInRole(permission.Value))
            {
                foreach (var permissionChild in permissions.Where(p => p.ParentId == permission.Id).ToList())
                    CheckPermissionOfCurrentUser(permissionChild, permissions);

                if (permissions.Contains(permission))
                    permissions.Remove(permission);
            }
        }

        [HttpGet]
        public object GetPermissionsCanSetForGroup(Guid groupId)
        {
            var group = _GroupService.Datas.First(g => g.Id == groupId);

            List<GroupPermissionViewModel> result = new List<GroupPermissionViewModel>();
            if (group.ParentId == null)
            {
                var permissions = _Group_PermissionService.Datas
                    .Where(gp=>gp.GroupId == groupId)
                    .Join(_PermissionService.Datas,
                        gp => gp.PermissionId,
                        p => p.Id,
                        (gp, p) => new { Group = gp, Permission = p })
                    .Select(gp => gp.Permission)
                    .ToList();

                foreach (var permission in permissions.ToList())
                    CheckPermissionOfCurrentUser(permission, permissions);

                foreach (var permission in permissions.Where(p => p.ParentId != null && !permissions.Any(pp => pp.Id == p.ParentId)).ToList())
                    permissions.Remove(permission);

                result = permissions.Select(p =>
                    new GroupPermissionViewModel()
                    {
                        Check = true,
                        GroupId = groupId,
                        PermissionId = p.Id,
                        PermissionParentId = p.ParentId,
                        PermissionDisplayName = p.DisplayName
                    }).ToList();
            }
            else
            {
                var permissionParents = _Group_PermissionService.Datas
                    .Where(gp => gp.GroupId == group.ParentId)
                    .Join(_PermissionService.Datas,
                        gp => gp.PermissionId,
                        p => p.Id,
                        (gp, p) => new { Group = gp, Permission = p })
                    .Select(gp => gp.Permission)
                    .ToList();

                foreach (var permission in permissionParents.ToList())
                    CheckPermissionOfCurrentUser(permission, permissionParents);

                foreach (var permission in permissionParents.Where(p => p.ParentId != null && !permissionParents.Any(pp => pp.Id == p.ParentId)).ToList())
                    permissionParents.Remove(permission);

                var permissions = _Group_PermissionService.Datas
                    .Where(gp => gp.GroupId == groupId)
                    .Join(_PermissionService.Datas,
                        gp => gp.PermissionId,
                        p => p.Id,
                        (gp, p) => new { UserGroup = gp, Permission = p })
                    .Select(gp => gp.Permission)
                    .ToList();

                result = permissionParents.Select(p =>
                    new GroupPermissionViewModel()
                    {
                        Check = permissions.Any(pp => pp.Id == p.Id),
                        GroupId = groupId,
                        PermissionId = p.Id,
                        PermissionParentId = p.ParentId,
                        PermissionDisplayName = p.DisplayName
                    }).ToList();
            }
            
            return Json(result);
        }

        public class GroupPermissions
        {
            public Guid groupId { get; set; }

            public string permissionIds { get; set; }
        }

        [HttpPost]
        [Authorize(Roles = "Manager_UserGroup_Permission")]
        public async Task<IActionResult> SetPermissionForGroup([FromBody] GroupPermissions groupPermission)
        {
            try
            {
                var permissionIds = JsonConvert.DeserializeObject<List<string>>(groupPermission.permissionIds).Select(str => Guid.Parse(str)).ToList();

                // Lấy tất cả các quyền mà tài khoản đang dùng được phép phân
                var userPermissions = _PermissionService.Datas.ToList();
                foreach (var permission in userPermissions.ToList())
                    CheckPermissionOfCurrentUser(permission, userPermissions);

                var permissionIdsCanSet = userPermissions.Select(p => p.Id).ToList();

                // Xóa các quyền mà user không được set
                foreach (var permissionId in permissionIds.Where(pid => !permissionIdsCanSet.Contains(pid)).ToList())
                    permissionIds.Remove(permissionId);

                // Lấy các quyền cần set trong DB
                var permissions = _PermissionService.Datas
                    .Where(p => permissionIds.Contains(p.Id))
                    .ToList();

                // Xóa các quyền không có quyền cha
                foreach (var permission in permissions.Where(p => p.ParentId != null && !permissions.Any(pp => pp.Id == p.Id)).ToList())
                    permissions.Remove(permission);

                var permissionIdsNeedSet = permissions.Select(p => p.Id).ToList();

                var userGroup = _GroupService.Datas
                    .Where(g => g.Id == groupPermission.groupId)
                    .Include(g => g.Permissions)
                    .First();

                // Xóa các quyền không còn nữa
                _Group_PermissionService.DataSets.RemoveRange(userGroup.Permissions
                    .Where(gp => permissionIdsCanSet.Contains(gp.PermissionId))
                    .Where(gp => !permissionIdsNeedSet.Contains(gp.PermissionId)));

                // Thêm các quyền chưa có
                _Group_PermissionService.DataSets.AddRange(permissionIdsNeedSet.Where(pid => !userGroup.Permissions.Any(p => p.PermissionId == pid))
                    .Select(pid => new Group_Permission()
                    {
                        GroupId = userGroup.Id,
                        PermissionId = pid
                    }));

                await _Group_UserService.SaveAllChanged();

                return Json(groupPermission);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
