using HDAdvertising.Datas;
using HDAdvertising.Datas.Security;
using HDAdvertising.Datas.Permission;
using HDAdvertising.Services;
using HDAdvertising.Services.Account;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HDAdvertising
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<HDAdvDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, Permission>()
                .AddDefaultTokenProviders();

            services
                .AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new ViewLocationExpander());
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);

                options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(30);
                options.Cookies.ApplicationCookie.LoginPath = "/Account/Login";
                options.Cookies.ApplicationCookie.LogoutPath = "/Account/LogOff";
            });

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            services.AddTransient<IService<Group>, ServiceBase<Group, HDAdvDbContext>>();
            services.AddTransient<IService<User>, ServiceBase<User, HDAdvDbContext>>();
            services.AddTransient<IService<Group_User>, ServiceBase<Group_User, HDAdvDbContext>>();
            services.AddTransient<IService<Permission>, ServiceBase<Permission, HDAdvDbContext>>();
            services.AddTransient<IService<Group_Permission>, ServiceBase<Group_Permission, HDAdvDbContext>>();
            //services.AddTransient<IService<User_Permission>, ServiceBase<User_Permission, HDAdvDbContext>>();
            //services.AddTransient<IService<Permission_Request>, ServiceBase<Permission_Request, HDAdvDbContext>>();

            services.AddTransient<IService<Datas.UI.Menu>, ServiceBase<Datas.UI.Menu, HDAdvDbContext>>();
            services.AddTransient<IService<Datas.UI.Menu_Permission>, ServiceBase<Datas.UI.Menu_Permission, HDAdvDbContext>>();

            services.AddTransient<IUserStore<User>, Services.Account.UserStore<User>>();
            services.AddTransient<IPasswordHasher<User>, Services.Account.PasswordHasher<User>>();
            services.AddTransient<IUserPasswordStore<User>, Services.Account.UserStore<User>>();
            services.AddTransient<IUserRoleStore<User>, Services.Account.UserStore<User>>();
            services.AddTransient<IRoleStore<Permission>, Services.Account.RoleStore<Permission>>();
            
            services.AddDistributedMemoryCache();
            
            services.AddMemoryCache()
                .AddSession(s =>
                {
                    s.CookieName = "HDAdvertising";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, HDAdvDbContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            app.UseSession();

            // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller}/{action=Index}/{id?}"
                    );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            return;

            context.Database.EnsureCreated();

            #region Add permission
            Dictionary<string, string> permissions = new Dictionary<string, string>();

            foreach (ApplicationPermissions permission in Enum.GetValues(typeof(ApplicationPermissions)))
            {
                permissions.Add(permission.ToString(),  Extensions.GetDisplayTextAttributeOfType<DisplayTextAttribute>(permission).Text);
            }

            // Delete all permission not exists
            var permissionName = permissions.Select(p => p.Key).ToList();
            bool remove = false;
            var permissionOlds = context.Security_Permissions.Where(p => p.Type == PermissionType.Manager.ToString() && !permissionName.Contains(p.Value)).ToList();
            if(permissionOlds.Count > 0)
            {
                context.Security_Permissions.RemoveRange(permissionOlds);
                remove = true;
            }
            if (remove)
                context.SaveChanges();

            // Add or update all new permission
            bool changed = false;
            foreach (var permission in permissions.OrderBy(p => p.Key))
            {
                var parentName = "";
                var lastIndex = permission.Key.LastIndexOf('_');
                if (lastIndex >= 0)
                    parentName = permission.Key.Substring(0, lastIndex);

                var permissionOld = context.Security_Permissions
                    .Include(p => p.Parent)
                    .SingleOrDefault(p => p.Type == PermissionType.Manager.ToString() && p.Value == permission.Key);

                if (permissionOld == null)
                {
                    context.Security_Permissions.Add(new Permission()
                    {
                        Type = PermissionType.Manager.ToString(),
                        Value = permission.Key,
                        DisplayName = permission.Value,
                        Parent = parentName == "" ? null : context.Security_Permissions.Local.FirstOrDefault(p => p.Type == PermissionType.Manager.ToString() && p.Value == parentName)
                    });
                    changed = true;
                }
                else if (permissionOld.DisplayName != permission.Value
                    || (parentName == "" && permissionOld.Parent != null)
                    || (parentName != "" && (permissionOld.Parent == null || permissionOld.Parent.Value != parentName)))
                {
                    permissionOld.DisplayName = permission.Value;
                    permissionOld.Parent = parentName == "" ? null : context.Security_Permissions.Local.FirstOrDefault(g => g.Type == PermissionType.Manager.ToString() && g.Value == parentName);
                    changed = true;
                }
            }
            if (changed)
                context.SaveChanges();

            // Lấy nhóm root
            var rootGroup = context.Security_Groups.Where(g => g.ParentId == null).Include(g => g.Permissions).First();

            context.Security_Group_Permissions.AddRange(context.Security_Permissions
                .Where(p => p.Type == PermissionType.Manager.ToString() && !rootGroup.Permissions.Any(gp => gp.PermissionId == p.Id))
                .Select(p => new Group_Permission()
                {
                    GroupId = rootGroup.Id,
                    PermissionId = p.Id
                }));

            context.SaveChanges();
            #endregion

            #region Add menu
            AddMenu(context, Datas.Menu.MenuData.Menus, null);
            #endregion
        }

        void AddMenu(HDAdvDbContext context, List<Datas.Menu.MenuExample> menus, Datas.UI.Menu parentMenu)
        {
            // Lấy menu cha
            var parent = parentMenu == null ? null : context.UI_Menus.Where(m => m.Id == parentMenu.Id).Include(m => m.Childrens).First();

            foreach(var menu in menus)
            {
                menu.Index = menus.IndexOf(menu);

                var dbMenu = parent == null ? context.UI_Menus.Where(m => m.ParentId == null && m.Name == menu.Name).FirstOrDefault() : parent.Childrens.Where(mc => mc.Name == menu.Name).FirstOrDefault();
                if (dbMenu == null)
                {
                    dbMenu = new Datas.UI.Menu()
                    {
                        Name = menu.Name,
                        Icon = menu.Icon,
                        GroupIndex = menu.GroupIndex,
                        Index = menu.Index,
                        Url = menu.Url,
                        ParentId = parent == null ? null : (Guid?)parent.Id
                    };
                    context.UI_Menus.Add(dbMenu);
                    context.SaveChanges();
                }
                else
                {
                    if (dbMenu.Name != menu.Name
                        || dbMenu.Icon != menu.Icon
                        || dbMenu.GroupIndex != menu.GroupIndex
                        || dbMenu.Index != menu.Index
                        || dbMenu.Url != menu.Url)
                    {
                        dbMenu.Name = menu.Name;
                        dbMenu.Icon = menu.Icon;
                        dbMenu.GroupIndex = menu.GroupIndex;
                        dbMenu.Index = menu.Index;
                        dbMenu.Url = menu.Url;

                        context.SaveChanges();
                    }
                }

                var permissions = context.UI_Menu_Permissions.Where(mp => mp.MenuId == dbMenu.Id)
                    .Join(context.Security_Permissions.Where(p=>p.Type == PermissionType.Manager.ToString()),
                        mp => mp.PermissionId,
                        p => p.Id,
                        (mp, p) => new { Menu = mp, Permission = p })
                    .ToList();

                var permissionNames = string.IsNullOrWhiteSpace(menu.PermissionNames) ? new List<string>() : menu.PermissionNames.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                // Xóa các quyền cũ
                context.UI_Menu_Permissions.RemoveRange(permissions.Where(p => !permissionNames.Contains(p.Permission.Value)).Select(mp => mp.Menu));
                // Thêm quyền mới
                foreach(var permissionName in permissionNames.Where(pn=>!permissions.Any(mp=>mp.Permission.Value == pn)))
                {
                    var permission = context.Security_Permissions.FirstOrDefault(p => p.Type == PermissionType.Manager.ToString() && p.Value == permissionName);
                    if(permission!=null)
                    {
                        context.UI_Menu_Permissions.Add(new Datas.UI.Menu_Permission()
                        {
                            MenuId = dbMenu.Id,
                            PermissionId = permission.Id
                        });
                    }
                }

                context.SaveChanges();

                if (menu.Items != null && menu.Items.Count > 0)
                    AddMenu(context, menu.Items, dbMenu);
            }
        }
    }

    public class ViewLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            //{2} is area, {1} is controller,{0} is the action
            string[] locations = new string[] { "/Views/{2}/{1}/{0}.cshtml" };
            return locations.Union(viewLocations);          //Add mvc default locations after ours
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            context.Values["customviewlocation"] = nameof(ViewLocationExpander);
        }
    }
}
