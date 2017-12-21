using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Infrastructure.DataProtections
{
    public static class DataProtectionExtensions
    {
        public static IDataProtectionBuilder AddDataProtection(this IServiceCollection services, DataProtectionOptions options)
        {
            var builder = services.AddDataProtection();

            options = options ?? new DataProtectionOptions();
            if (options.KeyStorageProvider == KeyStorageProviders.FileSystem)
            {
                builder.PersistKeysToFileSystem(new System.IO.DirectoryInfo(options.FileSystemStorageProvider.Location));
            } else if (options.KeyStorageProvider == KeyStorageProviders.SqlServer)
            {
                var connectionString = options.SqlServerStorageProvider.ConnectionString;
                services.Configure<SqlServerStorageProviderOptions>(opt =>
                {
                    opt.ConnectionString = options.SqlServerStorageProvider.ConnectionString;
                    opt.Schema = options.SqlServerStorageProvider.Schema;
                    opt.TableName = options.SqlServerStorageProvider.TableName;
                });

                services.AddDbContext<DataProtectionContext>(opt =>
                {
                    opt.UseSqlServer(connectionString);
                }, ServiceLifetime.Scoped);

                builder.Services.TryAddScoped<IXmlRepository, SqlServerDataProtectionKeyRepository>();
            }

            return builder;
        }
    }
}
