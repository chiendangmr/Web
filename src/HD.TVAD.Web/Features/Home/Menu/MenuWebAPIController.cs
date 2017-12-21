using DevExtreme.AspNet.Mvc;
using HD.TVAD.Entities.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HD.TVAD.Entities.Entities.UI;
using HD.TVAD.Web.Features.Home.Menu.Models;
using Microsoft.EntityFrameworkCore;
using HD.TVAD.Entities.Entities.Security;
using DevExtreme.AspNet.Data;
using Microsoft.Extensions.Localization;
using HD.TVAD.Entities.Repositories.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Text;

namespace HD.TVAD.Web.Features.Home.Menu
{
    [Route("api/home/[controller]/[action]")]
    public class MenuWebAPIController : Controller
    {
        readonly Entities.Repositories.IRepository<Entities.Entities.UI.Menu> _menuRepository;
        readonly IUserRepository<User> _userRepository;
        readonly UserManager<User> _userManager;
        readonly SignInManager<User> _signInManager;
        readonly IStringLocalizer<MenuWebAPIController> _localizer;

        public MenuWebAPIController(Entities.Repositories.IRepository<Entities.Entities.UI.Menu> menuRepository,
            IUserRepository<User> userRepository,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IStringLocalizer<MenuWebAPIController> localizer)
        {
            _menuRepository = menuRepository;
            _userRepository = userRepository;
            _localizer = localizer;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        MenuViewModel GetMenu(Entities.Entities.UI.Menu menu, IList<Guid> permissionIds, List<MenuViewModel> lstMenu)
        {
            bool hasPermission = !menu.Menu_Permissions.Any(mp=>!permissionIds.Contains(mp.PermissionId));

            if (hasPermission)
            {
                var cmenu = new MenuViewModel()
                {
                    originText = menu.Name,
                    text = _localizer[menu.Name].Value,
                    url = menu.Url,
                    controllerName = menu.Controller,
                    actionName = menu.Action,
                    areaName = menu.Area
                };
                if (!string.IsNullOrWhiteSpace(menu.Icon))
                    cmenu.icon = menu.Icon;
                lstMenu.Add(cmenu);
                
                if (menu.Childrens.Count > 0)
                {
                    int lastGroupIndex = -1;
                    foreach (var child in menu.Childrens.OrderBy(c => c.GroupIndex).ThenBy(c => c.Index))
                    {
                        var newMenu = GetMenu(child, permissionIds, cmenu.items);
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

        void GetMenuText(MenuViewModel menu)
        {
            menu.text = _localizer[menu.originText].Value;

            foreach (var child in menu.items)
                GetMenuText(child);
        }
        // GET: api/values
        [HttpGet]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        public async Task<object> Get(DataSourceLoadOptions loadOptions)
        {
            List<MenuViewModel> lstMenu = new List<MenuViewModel>();

            byte[] menuData = null;
            bool changedLanguage = false;
            if (!HttpContext.Session.TryGetValue("lstMenu", out menuData) || menuData == null || menuData.Length == 0)
            {
                IList<Guid> permissionIds = new List<Guid>();

                var menus = _menuRepository.Datas.Include(m => m.Childrens).Include(m => m.Menu_Permissions).ToList();

                if (_signInManager.IsSignedIn(User))
                {
                    var userId = Guid.Parse(_userManager.GetUserId(User));
                    var user = _userRepository.Datas.Find(userId);
                    permissionIds = await _userRepository.GetUserPermissionIdsAsync(user);
                }

                foreach (var menu in menus.Where(m => m.ParentId == null).OrderBy(m => m.GroupIndex).ThenBy(m => m.Index).ToList())
                    GetMenu(menu, permissionIds, lstMenu);

                menuData = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(lstMenu));
                HttpContext.Session.Set("lstMenu", menuData);

                changedLanguage = true;
            }
            else
                lstMenu = JsonConvert.DeserializeObject<List<MenuViewModel>>(System.Text.Encoding.UTF8.GetString(menuData));

            if (!changedLanguage)
            {
                byte[] changedLangData = null;
                if (HttpContext.Session.TryGetValue("ChangedLanguage", out changedLangData) && Encoding.UTF8.GetString(changedLangData) == "true")
                    changedLanguage = true;
            }
            
            if(changedLanguage)
            {
                foreach (var menu in lstMenu)
                    GetMenuText(menu);

                menuData = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(lstMenu));
                HttpContext.Session.Set("lstMenu", menuData);
            }

            var changedLang = Encoding.UTF8.GetBytes("false");
            HttpContext.Session.Set("ChangedLanguage", changedLang);

            return DataSourceLoader.Load(lstMenu, loadOptions);
        }
    }
}
