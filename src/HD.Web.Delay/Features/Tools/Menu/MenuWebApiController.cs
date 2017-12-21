using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using HD.TVAD.Entities.Repositories;
using HD.TVAD.Web.Features.Tools.Menu.Models;
using Newtonsoft.Json;
using HD.TVAD.Web.Infrastructure;
using Microsoft.Extensions.Localization;
using Microsoft.EntityFrameworkCore;
using HD.TVAD.Entities.Entities.Security;

namespace HD.TVAD.Web.Features.Tools.Menu
{
    [Area("Tools")]
    [Route("api/tools/[controller]/[action]")]
    public class MenuWebApiController : Controller
    {
        IRepository<HD.TVAD.Entities.Entities.UI.Menu> _menuRepository;

        IRepository<HD.TVAD.Entities.Entities.Security.Permission> _permissionRepository;

        IRepository<HD.TVAD.Entities.Entities.UI.Menu_Permission> _menuPermissionRepository;

        readonly IStringLocalizer<MenuWebApiController> _localizer;

        public MenuWebApiController(IRepository<HD.TVAD.Entities.Entities.UI.Menu> menuRepository,
            IRepository<HD.TVAD.Entities.Entities.Security.Permission> permissionRepository,
            IRepository<HD.TVAD.Entities.Entities.UI.Menu_Permission> menuPermissionRepository,
            IStringLocalizer<MenuWebApiController> localizer)
        {
            _menuRepository = menuRepository;
            _permissionRepository = permissionRepository;
            _menuPermissionRepository = menuPermissionRepository;

            _localizer = localizer;
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loaderOption)
        {
            var query = _menuRepository.Datas
                .Select(m => new MenuViewModel()
                {
                    id = m.Id,
                    parentId = m.ParentId,
                    name = m.Name,
                    icon = m.Icon,
                    groupIndex = m.GroupIndex,
                    index = m.Index,
                    url = m.Url,
                    controlerName = m.Controller,
                    actionName = m.Action,
                    areaName = m.Area
                });
            return DataSourceLoader.Load(query, loaderOption);
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            try
            {
                var model = new MenuViewModel();
                JsonConvert.PopulateObject(values, model);

                if (!TryValidateModel(model))
                    return BadRequest(ModelState.GetFullErrorMessage());

                if (_menuRepository.Datas.Any(g => g.ParentId == model.parentId && g.Name == model.name))
                    throw new Exception(string.Format(_localizer["Menu {0} has exists"].Value, model.name));

                var newMenu = new HD.TVAD.Entities.Entities.UI.Menu()
                {
                    ParentId = model.parentId,
                    Name = model.name,
                    Icon = model.icon,
                    GroupIndex = model.groupIndex,
                    Index = model.index,
                    Url = model.url,
                    Controller = model.controlerName,
                    Action = model.actionName,
                    Area = model.areaName
                };

                await _menuRepository.InsertAsync(newMenu);

                HttpContext.Session.Remove("lstMenu");

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
                var menu = _menuRepository.Datas.Find(key);
                var model = new MenuViewModel()
                {
                    id = menu.Id,
                    parentId = menu.ParentId,
                    name = menu.Name,
                    icon = menu.Icon,
                    groupIndex = menu.GroupIndex,
                    index = menu.Index,
                    url = menu.Url,
                    controlerName = menu.Controller,
                    actionName = menu.Action,
                    areaName = menu.Area
                };
                JsonConvert.PopulateObject(values, model);

                if (!TryValidateModel(model))
                    return BadRequest(ModelState.GetFullErrorMessage());

                if (_menuRepository.Datas.Any(g => g.Id != key && g.ParentId == model.parentId && g.Name == model.name))
                    throw new Exception(string.Format(_localizer["Menu {0} has exists"].Value, model.name));

                menu.ParentId = model.parentId;
                menu.Name = model.name;
                menu.Icon = model.icon;
                menu.GroupIndex = model.groupIndex;
                menu.Index = model.index;
                menu.Url = model.url;
                menu.Controller = model.controlerName;
                menu.Action = model.actionName;
                menu.Area = model.areaName;

                await _menuRepository.UpdateAsync(menu);

                HttpContext.Session.Remove("lstMenu");

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        void GetMenuToRemove(Guid key, List<HD.TVAD.Entities.Entities.UI.Menu> menuToRemoves)
        {
            var menu = _menuRepository.Datas
                .Where(g => g.Id == key)
                .Include(g => g.Childrens)
                .First();

            if (menu.Childrens.Count > 0)
            {
                foreach (var child in menu.Childrens)
                    GetMenuToRemove(child.Id, menuToRemoves);
            }

            menuToRemoves.Add(menu);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid key)
        {
            try
            {
                List<HD.TVAD.Entities.Entities.UI.Menu> menuToRemoves = new List<Entities.Entities.UI.Menu>();

                GetMenuToRemove(key, menuToRemoves);

                await _menuRepository.DeleteAsync(menuToRemoves);

                HttpContext.Session.Clear();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public object GetParentCanSet(Guid? menuId, DataSourceLoadOptions loaderOption)
        {
            var query = _menuRepository.Datas
                .Where(m => menuId == null || (m.Id != menuId && m.ParentId != menuId))
                .Select(m => new MenuViewModel()
                {
                    id = m.Id,
                    parentId = m.ParentId,
                    name = m.Name,
                    icon = m.Icon,
                    groupIndex = m.GroupIndex,
                    index = m.Index,
                    url = m.Url,
                    controlerName = m.Controller,
                    actionName = m.Action,
                    areaName = m.Area
                });
            return DataSourceLoader.Load(query, loaderOption);
        }

        [HttpGet]
        public object GetRequiredPermissionsOfMenu(Guid menuId)
        {
            var query = _menuPermissionRepository.Datas.Where(mp => mp.MenuId == menuId)
                .Include(mp => mp.Menu)
                .Include(mp => mp.Permission)
                .Select(mp => new MenuPermissionModel
                {
                    permissionId = mp.PermissionId,
                    permissionDisplayName = _localizer["{0}", mp.Permission.DisplayName].Value
                });
            return Json(query.ToList());
        }

        [HttpGet]
        public object GetAllUsePermissions(DataSourceLoadOptions loaderOption)
        {
            var query = _permissionRepository.Datas.Where(p => p.Type == PermissionTypeEnum.UserPermission.ToString())
                .Select(p => new PermissionModel
                {
                    id = p.Id,
                    parentId = p.ParentId,
                    displayName = _localizer["{0}", p.DisplayName].Value
                });
            return DataSourceLoader.Load(query, loaderOption);
        }

        public class MenuPermissions
        {
            public Guid menuId { get; set; }

            public string permissionIds { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> SetRequiredPermissionsOfMenu([FromBody] MenuPermissions menuPermissions)
        {
            try
            {
                var menu = _menuRepository.Datas
                    .Where(m => m.Id == menuPermissions.menuId)
                    .Include(m => m.Menu_Permissions)
                    .FirstOrDefault();

                if (menu == null)
                    throw new Exception(_localizer["Menu not found"].Value);

                var permissionIds = JsonConvert.DeserializeObject<List<string>>(menuPermissions.permissionIds)
                    .Select(idstr => Guid.Parse(idstr)).ToList();

                bool changed = false;
                var removes = menu.Menu_Permissions.Where(p => !permissionIds.Contains(p.PermissionId)).ToList();
                if(removes.Count > 0)
                {
                    foreach (var p in removes)
                        menu.Menu_Permissions.Remove(p);
                    changed = true;
                }

                foreach(var pId in permissionIds.Where(p=>!menu.Menu_Permissions.Any(pp=>pp.PermissionId == p)).ToList())
                {
                    menu.Menu_Permissions.Add(new Entities.Entities.UI.Menu_Permission
                    {
                        Menu = menu,
                        PermissionId = pId
                    });
                    changed = true;
                }

                if (changed)
                    _menuRepository.SaveChanges();

                return Json(menuPermissions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}