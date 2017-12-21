using HD.Station.Models.Localization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.Station.Localization
{
    [Service(ServiceType =typeof(IStringLocalizerFactory), Lifetime = ServiceLifetime.Scoped)]
    public class SqlStringLocalizerFactory : IStringLocalizerFactory
    {
        protected LocalizationDbContext DbContext { get; }

        protected ILogger Looger { get; }

        IHostingEnvironment Environment { get; }

        public SqlStringLocalizerFactory(LocalizationDbContext dbContext, ILogger<SqlStringLocalizer> logger, IHostingEnvironment env)
        {
            this.DbContext = dbContext;
            this.Looger = logger;
            this.Environment = env;
        }
        public IStringLocalizer Create(Type resourceSource)
        {
            var baseName = TrimBaseName(resourceSource.FullName);

            return new SqlStringLocalizer(DbContext, baseName, this.Looger, this.Environment);
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            baseName = TrimBaseName(baseName.Substring(location.Length));
            
            return new SqlStringLocalizer(DbContext, baseName.TrimStart('.'), this.Looger, this.Environment);
        }

        private string TrimBaseName(string baseName)
        {
            var index = baseName.IndexOf(".Features.", StringComparison.OrdinalIgnoreCase);
            if (index >= 0)
            {
                baseName = baseName.Substring(index + 10);
            }

            return baseName;
        }
    }
}
