using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using HDAdvertising.Datas.Menu;
using HDAdvertising.Models;
using HDAdvertising.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDAdvertising.Controllers
{
    public class MenuController : Controller
    {
        IService<Datas.UI.Menu> _MenuService;
        IService<Datas.UI.Menu_Permission> _MenuPermissionService;
        IService<Datas.Security.Permission> _PermissionService;

        public MenuController(IService<Datas.UI.Menu> menuService, IService<Datas.UI.Menu_Permission> menuPermissionService, IService<Datas.Security.Permission> permissionService)
        {
            _MenuService = menuService;
            _MenuPermissionService = menuPermissionService;
            _PermissionService = permissionService;
        }

        MenuViewModel GetMenu(Datas.UI.Menu menu, List<MenuViewModel> lstMenu)
        {
            var dbMenu = _MenuService.Datas.Where(m => m.Id == menu.Id)
                .Include(m => m.Permissions)
                .Include(m => m.Childrens)
                .First();

            var permissionIds = dbMenu.Permissions.Select(p => p.PermissionId).ToList();
            var permissionNeed = _PermissionService.Datas.Where(p => permissionIds.Contains(p.Id)).Select(p => p.Value).ToList();

            bool havePermission = true;
            if (permissionNeed.Count > 0)
            {
                foreach (var permission in permissionNeed)
                {
                    if (!User.IsInRole(permission))
                    {
                        havePermission = false;
                        break;
                    }
                }
            }

            if (havePermission)
            {
                var cmenu = new MenuViewModel()
                {
                    text = dbMenu.Name,
                    icon = dbMenu.Icon,
                    url = dbMenu.Url,
                    disabled = !havePermission
                };
                lstMenu.Add(cmenu);

                if (dbMenu.Childrens.Count() > 0)
                {
                    cmenu.items = new List<MenuViewModel>();

                    int lastGroupIndex = -1;

                    foreach (var child in dbMenu.Childrens.OrderBy(c => c.GroupIndex).ThenBy(c => c.Index))
                    {
                        var newMenu = GetMenu(child, cmenu.items);
                        if (newMenu != null)
                        {
                            if (child.GroupIndex != lastGroupIndex)
                            {
                                newMenu.beginGroup = true;
                                lastGroupIndex = child.GroupIndex;
                            }
                        }
                    }
                }

                return cmenu;
            }

            return null;
        }

        [HttpGet]
        public ActionResult GetMenus(DataSourceLoadOptions loadOptions)
        {
            List<MenuViewModel> menus = new List<MenuViewModel>();

            foreach (var menu in _MenuService.Datas.Where(m => m.ParentId == null).OrderBy(m => m.Index))
                GetMenu(menu, menus);

            return Content(JsonConvert.SerializeObject(DataSourceLoader.Load(menus, loadOptions)), "application/json");
        }
    }
}
