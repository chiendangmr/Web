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
    [Authorize(Roles = "Manager_User")]
    public class UserController : Controller
    {
        readonly UserManager<User> _UserManager;

        readonly IService<Group> _GroupService;
        readonly IService<User> _UserService;
        readonly IService<Group_User> _Group_UserService;
        readonly IPasswordHasher<User> _PasswordHasher;
        readonly IService<Permission> _PermissionService;
        readonly IService<Group_Permission> _Group_PermissionService;
        //readonly IService<Permission_Request> _Permission_RequestService;

        public UserController(UserManager<User> userManager,
            IService<Group> groupService,
            IService<User> userService,
            IService<Group_User> group_UserService,
            IPasswordHasher<User> passwordHasher, 
            IService<Permission> permissionService,
            IService<Group_Permission> group_PermissionService)
            //IService<Permission_Request> permission_RequestService)
        {
            _UserManager = userManager;
            _GroupService = groupService;
            _UserService = userService;
            _Group_UserService = group_UserService;
            _PasswordHasher = passwordHasher;
            _PermissionService = permissionService;
            _Group_PermissionService = group_PermissionService;
            //_Permission_RequestService = permission_RequestService;
        }

        public IActionResult Index()
        {
            return View();
        }

        void GetGroupChildrensOfGroup(Group group, List<Group> lstGroup)
        {
            if(!lstGroup.Any(g=>g.Id == group.Id))
            {
                group = _GroupService.Datas
                    .Where(g => g.Id == group.Id)
                    .Include(g => g.Childrens)
                    .First();
                lstGroup.Add(group);
                foreach (var child in group.Childrens)
                    GetGroupChildrensOfGroup(child, lstGroup);
            }
        }

        [HttpGet]
        public object GetUserOfCurrentUser(DataSourceLoadOptions loadOptions)
        {
            var userId = Guid.Parse(_UserManager.GetUserId(User));

            List<Group> lstGroup = new List<Group>();
            // Lấy các nhóm ngoài cùng mà tài khoản đang quản lý
            foreach (var group in _Group_UserService.Datas
                .Where(gu => gu.UserId == userId)
                .Join(_GroupService.Datas,
                    gu => gu.GroupId,
                    g => g.Id,
                    (gu, g) => new { Group = g, GroupUser = gu })
                .Select(gu => gu.Group)
                .ToList())
            {
                GetGroupChildrensOfGroup(group, lstGroup);
            }

            // Chỉ lấy user ở các nhóm trong hoặc những user không thuộc nhóm nào
            foreach (var group in lstGroup.Where(g => g.ParentId == null || !lstGroup.Any(gg => gg.Id == g.ParentId)).ToList())
                lstGroup.Remove(group);
            var groupIdsToGet = lstGroup.Select(g => g.Id).ToList();

            var query = _UserService.Datas
                .Where(user => !_Group_UserService.Datas.Any(gu => gu.UserId == user.Id)
                    || _Group_UserService.Datas.Any(gu => gu.UserId == user.Id && groupIdsToGet.Contains(gu.GroupId)))
                .Select(user => new UserViewModel
                {
                    Id = user.Id,
                    Name = user.Name,
                    FullName = user.FullName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Active = user.Active
                });

            return DataSourceLoader.Load(query, loadOptions);
        }

        [HttpPost]
        [Authorize(Roles = "Manager_User_Edit")]
        public async Task<IActionResult> PostUser(string values)
        {
            try
            {
                var userModel = new UserViewModel();
                JsonConvert.PopulateObject(values, userModel);

                if (!TryValidateModel(userModel))
                    throw new Exception(ModelState.GetFullErrorMessage());

                if (string.IsNullOrEmpty(userModel.Password))
                    throw new Exception("Chưa nhập mật khẩu ban đầu");

                if (_UserService.Datas.Any(u => u.Name == userModel.Name))
                    throw new Exception("Đã tồn tại tài khoản " + userModel.Name + " trong hệ thống");

                var newUser = new User()
                {
                    Name = userModel.Name,
                    PasswordHash = _PasswordHasher.HashPassword(null, userModel.Password),
                    FullName = userModel.FullName,
                    Email = userModel.Email,
                    PhoneNumber = userModel.PhoneNumber,
                    Active = userModel.Active
                };

                await _UserService.Create(newUser);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "Manager_User_Edit")]
        public async Task<IActionResult> PutUser(Guid key, string values)
        {
            try
            {
                var user = _UserService.Datas.First(e => e.Id == key);

                var userModel = new UserViewModel()
                {
                    Id = user.Id,
                    Name = user.Name,
                    Password = "",
                    FullName = user.FullName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Active = user.Active
                };
                JsonConvert.PopulateObject(values, userModel);
                if (!TryValidateModel(userModel))
                    throw new Exception(ModelState.GetFullErrorMessage());
                
                if (_UserService.Datas.Any(u => u.Id != key && u.Name == userModel.Name))
                    throw new Exception("Đã tồn tại tài khoản " + userModel.Name + " trong hệ thống");

                user.Name = userModel.Name;
                if (!string.IsNullOrEmpty(userModel.Password))
                    user.PasswordHash = _PasswordHasher.HashPassword(null, userModel.Password);
                user.FullName = userModel.FullName;
                user.Email = userModel.Email;
                user.PhoneNumber = userModel.PhoneNumber;
                user.Active = userModel.Active;

                await _UserService.Update(user);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Manager_User_Edit")]
        public async Task<IActionResult> DeleteUser(Guid key)
        {
            try
            {
                var user = _UserService.Datas.First(e => e.Id == key);

                await _UserService.Delete(user);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Manager_User_UserGroup")]
        public IActionResult SetGroup(Guid userId)
        {
            return View(new User_GroupViewModel()
            {
                UserId = userId
            });
        }

        void RemoveGroupAndChilds(Group group, List<Group> lstGroup)
        {
            if(lstGroup.Contains(group))
            {
                foreach (var child in lstGroup.Where(g => g.ParentId == group.Id).ToList())
                    RemoveGroupAndChilds(child, lstGroup);
                lstGroup.Remove(group);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Manager_User_UserGroup")]
        public object GetGroupCanSetForUser(string groupIds)
        {
            var userGroupController = new UserGroupController(_UserManager, _GroupService, _UserService, _Group_UserService, _PermissionService, _Group_PermissionService);
            var currentUserId = Guid.Parse(_UserManager.GetUserId(User));
            var userGroups = userGroupController.GetGroupsOfUser(currentUserId);

            // Bỏ các nhóm đã set cho tài khoản và các nhóm trong của nó
            if(groupIds != null && groupIds != "")
            {
                var groupIdsSet = JsonConvert.DeserializeObject<List<string>>(groupIds).Select(idstr => Guid.Parse(idstr)).ToList();
                foreach (var group in userGroups.Where(g => groupIdsSet.Contains(g.Id)).ToList())
                    RemoveGroupAndChilds(group, userGroups);
            }

            // Chỉ lấy các nhóm bên trong nhóm mà tài khoản đang thuộc
            foreach (var group in userGroups.Where(g => g.ParentId == null || !userGroups.Any(gg => gg.Id == g.ParentId)).ToList())
                userGroups.Remove(group);

            var modelViews = userGroups.Select(g => new GroupViewModel()
            {
                Id = g.Id,
                ParentId = g.ParentId,
                Name = g.Name
            }).ToList();

            foreach (var model in modelViews.Where(m => m.ParentId != null && !modelViews.Any(mm => mm.Id == m.ParentId)))
                model.ParentId = null;

            return Json(modelViews);
        }

        void CheckGroupHasParent(Group groupCheck, Group groupCurrent, List<Group> lstGroup)
        {
            if (groupCurrent.ParentId == null)
                return;

            if(lstGroup.Any(g=>g.Id == groupCurrent.ParentId))
            {
                lstGroup.Remove(groupCheck);
                return;
            }

            groupCurrent = _GroupService.Datas.Where(g => g.Id == groupCurrent.ParentId).First();
            CheckGroupHasParent(groupCheck, groupCurrent, lstGroup);
        }

        [HttpGet]
        [Authorize(Roles = "Manager_User_UserGroup")]
        public object GetCurrentGroupOfUser(Guid userId, string groupIds)
        {
            if(groupIds == "")
                return Json(new List<GroupViewModel>());

            List<Group> lstGroups = new List<Group>();
            if (groupIds == null)
            {
                lstGroups = _Group_UserService.Datas
                    .Where(gu => gu.UserId == userId)
                    .Join(_GroupService.Datas,
                        gu => gu.GroupId,
                        g => g.Id,
                        (gu, g) => new { GroupUser = gu, Group = g })
                    .Select(gu => gu.Group)
                    .ToList();
            }
            else
            {
                var gIds = JsonConvert.DeserializeObject<List<string>>(groupIds).Select(idstr => Guid.Parse(idstr)).ToList();
                if (gIds.Count > 0)
                {
                    lstGroups = _GroupService.Datas.Where(g => gIds.Contains(g.Id)).ToList();
                }
            }

            // Chỉ lấy các group trong số các group có thể set được
            var userGroupController = new UserGroupController(_UserManager, _GroupService, _UserService, _Group_UserService, _PermissionService, _Group_PermissionService);
            var currentUserId = Guid.Parse(_UserManager.GetUserId(User));
            var groupsCanSet = userGroupController.GetGroupsOfUser(currentUserId);
            foreach (var group in groupsCanSet.Where(g => g.ParentId == null || !groupsCanSet.Any(gg => gg.Id == g.ParentId)).ToList())
                groupsCanSet.Remove(group);
            foreach (var group in lstGroups.Where(g => !groupsCanSet.Any(gg => gg.Id == g.Id)).ToList())
                lstGroups.Remove(group);

            // Bỏ các nhóm con nếu đã được phân vào nhóm cha
            foreach (var group in lstGroups.ToList())
                CheckGroupHasParent(group, group, lstGroups);

            return Json(lstGroups.Select(g => new GroupViewModel()
            {
                Id = g.Id,
                ParentId = g.ParentId,
                Name = g.Name
            }));
        }

        public class User_Groups
        {
            public Guid UserId { get; set; }

            public string GroupIds { get; set; }
        }

        [HttpPost]
        [Authorize(Roles = "Manager_User_UserGroup")]
        public async Task<IActionResult> SetGroup([FromBody] User_Groups userGroups)
        {
            try
            {
                var groupIds = JsonConvert.DeserializeObject<List<string>>(userGroups.GroupIds).Select(idstr => Guid.Parse(idstr)).ToList();
                // Chỉ phân các group trong số các group có thể set được
                var userGroupController = new UserGroupController(_UserManager, _GroupService, _UserService, _Group_UserService, _PermissionService, _Group_PermissionService);
                var currentUserId = Guid.Parse(_UserManager.GetUserId(User));
                var groupsCanSet = userGroupController.GetGroupsOfUser(currentUserId);
                foreach (var group in groupsCanSet.Where(g => g.ParentId == null || !groupsCanSet.Any(gg => gg.Id == g.ParentId)).ToList())
                    groupsCanSet.Remove(group);

                var groupIdsCanSet = groupsCanSet.Select(g => g.Id).ToList();
                groupIds = groupIds.Where(id => groupIdsCanSet.Contains(id)).ToList();

                var currentGroupOfUser = _Group_UserService.Datas
                    .Where(gu => gu.UserId == userGroups.UserId && groupIdsCanSet.Contains(gu.GroupId))
                    .ToList();

                // Xóa các nhóm không được set nữa
                _Group_UserService.DataSets.RemoveRange(currentGroupOfUser.Where(g => !groupIds.Contains(g.GroupId)));
                // Thêm các nhóm chưa có
                _Group_UserService.DataSets.AddRange(groupIds.Where(id => !currentGroupOfUser.Any(gu => gu.GroupId == id)).Select(id => new Group_User()
                {
                    GroupId = id,
                    UserId = userGroups.UserId
                }));

                await _Group_UserService.SaveAllChanged();

                return Json(userGroups);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
