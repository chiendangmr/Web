using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using HDAutomationWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebAPISample
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HDStationPS_V4Context>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("HDStationPS_V4")));
            // Add framework services.            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {            
            app.UseMvc();
        }
    }
}
