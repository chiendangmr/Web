using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HD.Station;
using HD.Station.Configurations;
using HD.Station.Infrastructure.ApplicationParts;
using HD.Station.Infrastructure.Conventions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCacheServices(this IServiceCollection services, IConfigurationRoot configuration)
        {			
            // Add framework services.

            services.AddDistributedCache(configuration.GetSection("DistributedCache").Get<DistributedCacheOption>());
			
        }

        private static void AddDistributedCache(this IServiceCollection services, DistributedCacheOption options)
        {
            if (options.Provider == DistributedCacheProvider.SqlServer)
            {
                services.AddDistributedSqlServerCache(options.SqlServer);
            } else
            {
                throw new NotImplementedException();
            }
        }

        private static void AddDistributedSqlServerCache(this IServiceCollection services, DistributedCacheSqlServerOption options)
        {
            services.AddDistributedSqlServerCache(opt =>
            {
                opt.ConnectionString = options.ConnectionString;
                opt.SchemaName = options.SchemaName;
                opt.TableName = options.TableName;
            });
        }
    }
}