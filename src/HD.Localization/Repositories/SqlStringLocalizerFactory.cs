using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;

namespace HD.Localization.Repositories
{
    public class SqlStringLocalizerFactory : IStringLocalizerFactory
    {
        protected LocalizationDbContext DbContext { get; private set; }

        protected ILogger Logger { get; private set; }

        IHostingEnvironment Environment { get; }

        IMemoryCache _memoryCache;
        public SqlStringLocalizerFactory(LocalizationDbContext dbContext, ILogger<SqlStringLocalizer> logger, IHostingEnvironment env, IMemoryCache memoryCache)
        {
            DbContext = dbContext;
            Logger = logger;
            Environment = env;
            _memoryCache = memoryCache;
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            var baseName = TrimBaseName(resourceSource.FullName);

            return new SqlStringLocalizer(DbContext, baseName, Logger, Environment, _memoryCache);
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            baseName = TrimBaseName(baseName.Substring(location.Length));

            return new SqlStringLocalizer(DbContext, baseName.TrimStart('.'), Logger, Environment, _memoryCache);
        }

        private string TrimBaseName(string baseName)
        {
            var index = baseName.IndexOf(".Features.", StringComparison.OrdinalIgnoreCase);
            if (index >= 0)
            {
                baseName = baseName.Substring(index + ".Features.".Length);
            }
            else
            {
                index = baseName.IndexOf(".Areas.", StringComparison.OrdinalIgnoreCase);
                if (index >= 0)
                {
                    baseName = baseName.Substring(index + ".Areas.".Length);
                }
                else if(baseName.StartsWith("HD.TVAD.Web."))
                {
                    baseName = baseName.Substring("HD.TVAD.Web.".Length);
                }
            }

            return baseName;
        }
    }
}
