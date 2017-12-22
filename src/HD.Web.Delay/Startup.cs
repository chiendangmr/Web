using HD.Localization;
using HD.Station.Infrastructure.ApplicationParts;
using HD.Station.Infrastructure.Conventions;
using HD.Station.WebComponents;
using HD.Station.MediaAssets.Services;
using HD.TVAD.Infrastructure.Data;
using HD.TVAD.Web.Infrastructure;
using HD.TVAD.Web.Services;
using HD.Workflow;
using HD.Workflow.Middlewares;
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

            services.AddWorkflow(Configuration);
            services.AddWorkflowMvc(Configuration);
            services.AddWorkflowContentExtension(Configuration);
            services.AddDynamicFieldset(Configuration);
            services.AddWorkflowManagement(Configuration);
            services.AddUploadHandler(Configuration);
            services.AddWorkflowUploadExtension(Configuration);
            services.AddAssetUploadExtension(Configuration);
            services.AddRepositories();
            services.AddServices();
            services.AddMediaAssetService(Configuration);
            services.AddUploadFileNameGeneratorByAsset(Configuration);
            // Add application services.

            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

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
                //  app.UseBrowserLink();
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

            //app.UseFileServer(new FileServerOptions
            //{
            //	FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Video")),
            //	RequestPath = new PathString("/Video"),
            //	EnableDirectoryBrowsing = true
            //});
            //app.UseFileServer(new FileServerOptions
            //{
            //	FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Upload")),
            //	RequestPath = new PathString("/Upload"),
            //	EnableDirectoryBrowsing = true
            //});
            app.UseIdentity();

            app.UseSession();

            // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715
            app.UseWorkflowMvcStaticFiles();
            app.UseWorkflowManagementStaticFiles();

            app.UseMediainfojsStaticFiles();
            app.UseUploadStaticFiles();
            app.UseUploadMiddleware();
            app.UseAssetUploadStaticFiles();
            app.UseWorkflowApiMiddleware();
            app.UseMvc(routes =>
            {
               routes.MapRoute(
                    name: "areaDefault",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );

                routes.MapRoute(
                    name: "toolsApiRoute",
                    template: "api/tools/{controller}/{action}/{id?}"
                );

                routes.MapRoute(
                    name: "homeApiRoute",
                    template: "api/home/{controller}/{action}/{id?}"
                );

                routes.MapRoute(
                    name: "managersApiRoute",
                    template: "api/managers/{controller}/{action}/{id?}"
                );
            });

            app.UseKendo(env);

            if (env.IsDevelopment())
            {
                //context.Database.EnsureCreated();

                //#region Auto add booking type
                //Dictionary<int, string> bookingTypes = new Dictionary<int, string>();
                //foreach (BookingTypeEnum bookingType in Enum.GetValues(typeof(BookingTypeEnum)))
                //{
                //    bookingTypes.Add((int)bookingType, bookingType.ToString());
                //}

                //// Get all booking type in db
                //var dbBookingTypes = context.BookingTypes.ToList();
                //context.BookingTypes.RemoveRange(dbBookingTypes.Where(b => !bookingTypes.ContainsKey(b.Id)));
                //context.SaveChanges();

                //// Add or update booking type
                //foreach (var bookingType in bookingTypes.OrderBy(p => p.Value))
                //{
                //    var parentName = "";
                //    var lastIndex = bookingType.Value.LastIndexOf('_');
                //    if (lastIndex >= 0)
                //        parentName = bookingType.Value.Substring(0, lastIndex);

                //    var bookingTypeOld = context.BookingTypes
                //        .Where(b => b.Id == bookingType.Key)
                //        .FirstOrDefault();

                //    int? parentId = parentName == "" ? null : (int?)bookingTypes.Where(t => t.Value == parentName).First().Key;

                //    if (bookingTypeOld == null)
                //    {
                //        context.BookingTypes.Add(new ApplicationCore.Entities.BookingType()
                //        {
                //            Id = bookingType.Key,
                //            Name = ((BookingTypeEnum)bookingType.Key).GetDisplayName(),
                //            Description = ((BookingTypeEnum)bookingType.Key).GetDisplayName(),
                //            ParentId = parentId
                //        });
                //    }
                //    else if (bookingTypeOld.Name != ((BookingTypeEnum)bookingType.Key).GetDisplayName()
                //        || bookingTypeOld.ParentId != parentId)
                //    {
                //        bookingTypeOld.Name = ((BookingTypeEnum)bookingType.Key).GetDisplayName();
                //        bookingTypeOld.ParentId = parentId;
                //    }
                //}
                //context.SaveChanges();
                //#endregion

                //#region Auto add CustomerType
                //Dictionary<int, string> customerTypes = new Dictionary<int, string>();
                //foreach (CustomerTypeEnum customerType in Enum.GetValues(typeof(CustomerTypeEnum)))
                //{
                //    customerTypes.Add((int)customerType, customerType.GetDisplayName());
                //}

                //// Get all customer type in db
                //var dbCustomerTypes = context.CustomerTypes.ToList();
                //context.CustomerTypes.RemoveRange(dbCustomerTypes.Where(t => !customerTypes.ContainsKey(t.Id)));
                //context.SaveChanges();

                //// Add or update customer type
                //foreach (var customerType in customerTypes)
                //{
                //    var typeOld = context.CustomerTypes
                //        .Where(t => t.Id == customerType.Key)
                //        .FirstOrDefault();

                //    if (typeOld == null)
                //    {
                //        context.CustomerTypes.Add(new ApplicationCore.Entities.CustomerType
                //        {
                //            Id = customerType.Key,
                //            Name = customerType.Value,
                //            Description = customerType.Value
                //        });
                //    }
                //    else if (typeOld.Name != customerType.Value)
                //    {
                //        typeOld.Name = customerType.Value;
                //    }
                //}
                //context.SaveChanges();
                //#endregion

                //#region Auto add SponsorType
                //Dictionary<int, string> sponsorTypes = new Dictionary<int, string>();
                //foreach (SponsorTypeEnum sponsorType in Enum.GetValues(typeof(SponsorTypeEnum)))
                //{
                //    sponsorTypes.Add((int)sponsorType, sponsorType.GetDisplayName());
                //}

                //// Get all sponsor type in db
                //var dbSponsorTypes = context.SponsorTypes.ToList();
                //context.SponsorTypes.RemoveRange(dbSponsorTypes.Where(t => !sponsorTypes.ContainsKey(t.Id)));
                //context.SaveChanges();

                //// Add or update sponsor type
                //foreach (var sponsorType in sponsorTypes)
                //{
                //    var typeOld = context.SponsorTypes
                //        .Where(t => t.Id == sponsorType.Key)
                //        .FirstOrDefault();

                //    if (typeOld == null)
                //    {
                //        context.SponsorTypes.Add(new ApplicationCore.Entities.SponsorType
                //        {
                //            Id = sponsorType.Key,
                //            Name = sponsorType.Value
                //        });
                //    }
                //    else if (typeOld.Name != sponsorType.Value)
                //    {
                //        typeOld.Name = sponsorType.Value;
                //    }
                //}
                //context.SaveChanges();
                //#endregion

                //#region Auto add PriceType
                //Dictionary<int, string> priceTypes = new Dictionary<int, string>();
                //foreach (PriceTypeEnum priceType in Enum.GetValues(typeof(PriceTypeEnum)))
                //{
                //    priceTypes.Add((int)priceType, priceType.GetDisplayName());
                //}

                //// Get all price type in db
                //var dbPriceTypes = context.PriceTypes.ToList();
                //context.PriceTypes.RemoveRange(dbPriceTypes.Where(t => !priceTypes.ContainsKey(t.Id)));
                //context.SaveChanges();

                //// Add or update price type
                //foreach (var priceType in priceTypes)
                //{
                //    var typeOld = context.PriceTypes
                //        .Where(t => t.Id == priceType.Key)
                //        .FirstOrDefault();

                //    if (typeOld == null)
                //    {
                //        context.PriceTypes.Add(new ApplicationCore.Entities.PriceType
                //        {
                //            Id = priceType.Key,
                //            Name = priceType.Value,
                //            Description = priceType.Value
                //        });
                //    }
                //    else if (typeOld.Name != priceType.Value)
                //    {
                //        typeOld.Name = priceType.Value;
                //    }
                //}
                //context.SaveChanges();

                //#region Add default price type for free, ceiling and retail
                //foreach(PriceTypeEnum priceType in Enum.GetValues(typeof(PriceTypeEnum)))
                //{
                //    if(priceType == PriceTypeEnum.Free
                //        || priceType == PriceTypeEnum.Ceiling
                //        || priceType == PriceTypeEnum.Retail)
                //    {
                //        var exists = context.TypeDetails.Any(t => t.TypeId == (int)priceType);
                //        if (!exists)
                //            context.TypeDetails.Add(new ApplicationCore.Entities.TypeDetail()
                //            {
                //                TypeId = (int)priceType,
                //                Name = priceType.GetDisplayName()
                //            });
                //    }
                //}
                //context.SaveChanges();
                //#endregion
                //#endregion

                //StartData.UserPermissionExtensions.RegisterAll(tvadContext);

                //StartData.AccessZoneEnumExtentions.RegisterAll(tvadContext);

                //StartData.UriTypeEnumExtentions.RegisterAll(tvadContext);

                //StartData.FileTypeEnumExtentions.RegisterAll(tvadContext);

                StartData.StorageExtentions.Register(tvadContext);
            }
        }
    }
}