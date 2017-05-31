using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WebAPISample.Data;
using Microsoft.EntityFrameworkCore;

namespace WebAPISample
{
    public class Startup
    {        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase());
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {            
            app.UseMvc();
        }
    }
}
