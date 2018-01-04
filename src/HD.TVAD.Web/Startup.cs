using HD.Localization;
using HD.Station.Infrastructure.ApplicationParts;
using HD.Station.Infrastructure.Conventions;
using HD.TVAD.Infrastructure.Data;
using HD.TVAD.Web.Infrastructure;
using HD.TVAD.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using HD.TVAD.Infrastructure.DataProtections;
using HD.Web.Delay;

namespace HD.TVAD.Web
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
            // Register the IConfiguration instance which MyOptions binds against.
            services.Configure<Settings>(Configuration);

            // Add framework services.
            services.AddDbContext<HDAdDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<LocalizationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LocalizationConnection")));

            services.AddDbContext<Entities.Context.TVAdContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            Entities.Repositories.RepositoryExtensions.RegisterRepositories(services);

            services.AddScoped<IDataContext, HDAdDbContext>(service => service.GetRequiredService<HDAdDbContext>());

            services.AddScoped<IPasswordHasher<HD.TVAD.Entities.Entities.Security.User>, HD.TVAD.Processing.Identity.PasswordHasher<HD.TVAD.Entities.Entities.Security.User>>();
            services.AddScoped<IUserPasswordStore<HD.TVAD.Entities.Entities.Security.User>, HD.TVAD.Processing.Identity.UserStore<HD.TVAD.Entities.Entities.Security.User>>();
            services.AddScoped<IUserRoleStore<HD.TVAD.Entities.Entities.Security.User>, HD.TVAD.Processing.Identity.UserStore<HD.TVAD.Entities.Entities.Security.User>>();

            services.AddScoped<IAuthorizationServices, AuthorizationServices>();
            services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();

            services.AddDataProtection(Configuration.GetSection("DataProtection").Get<HD.TVAD.Infrastructure.DataProtections.DataProtectionOptions>())
                .SetApplicationName(Configuration["AppName"] ?? "HD.TVAd");

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);

                options.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(1);
                options.Cookies.ApplicationCookie.SlidingExpiration = true;
                options.Cookies.ApplicationCookie.CookieSecure = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                options.Cookies.ApplicationCookie.LoginPath = "/Home/Auth/LogIn";
                options.Cookies.ApplicationCookie.LogoutPath = "/Home/Auth/Logout";
                options.Cookies.ApplicationCookie.AccessDeniedPath = "/Home/Auth/AccessDenied";
                options.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents()
                {
                    OnValidatePrincipal = (CookieValidatePrincipalContext context) => Task.CompletedTask,
                };
            });

            services.AddIdentity<Entities.Entities.Security.User, HD.TVAD.Entities.Entities.Security.Permission>()
                .AddUserStore<Processing.Identity.UserStore<HD.TVAD.Entities.Entities.Security.User>>()
                .AddRoleStore<HD.TVAD.Processing.Identity.RoleStore<HD.TVAD.Entities.Entities.Security.Permission>>()
                .AddDefaultTokenProviders();

            services.AddCacheServices(Configuration);

            services.AddMemoryCache();

            services.AddSession(s =>
            {
                s.CookieName = Configuration["AppName"] ?? "HD.TVAd";
            });

            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue;
                x.MultipartHeadersLengthLimit = int.MaxValue;
            });

            services.AddMvc(options =>
            {
                options.Conventions.Add(new AsyncActionConvention());

            })
            .AddJsonOptions(
                options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                }
                )
            //	.AddServiceAnnotationsFeature()

            .AddFeatureViewLayout()
            //	.AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            .ConfigureApplicationPartManager(manager =>
            {
                manager.FeatureProviders.Add(new DiscoveryServiceFeatureProvider());
            })
            .AddDiscoveredServices()
            .AddDataAnnotationsLocalization()
            .AddViewLocalization();

            services.AddKendo();
            services.AddRepositories();
            services.AddServices();
            // Add application services.            

            services.AddSingleton<Localization.Repositories.CultureProvider>();
            services.AddSingleton<IStringLocalizerFactory, Localization.Repositories.SqlStringLocalizerFactory>();
            services.AddLocalization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, HDAdDbContext context, HD.TVAD.Entities.Context.TVAdContext tvadContext)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            var services = app.ApplicationServices;
            var cultures = services.GetRequiredService<Localization.Repositories.CultureProvider>().GetSupportedCultureInfoAsync().Result;
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US"),
                FallBackToParentCultures = true,
                FallBackToParentUICultures = true,
                SupportedCultures = cultures,
                SupportedUICultures = cultures
            });

            app.UseStaticFiles();

            app.UseIdentity();

            app.UseSession();

            // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.UseKendo(env);
        }
    }
}