using HD.Station.Models.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HD.Station.Localization
{
    [Service]
    public class CultureProvider
    {
        private LocalizationDbContext DbContext { get; set; }
        private IMemoryCache MemoryCache { get; set; }

        private ILogger Logger { get; set; }

        public CultureProvider(LocalizationDbContext dbContext, ILogger<CultureProvider> logger, IMemoryCache cache)
        {
            this.DbContext = dbContext;
            this.MemoryCache = cache;
        }

        public Task<List<string>> GetSupportedCultureAsync()
        {
            var query = from c in DbContext.Cultures
                        where c.Disabled == false && c.Parent.Disabled == false
                        select c.Name;

            return query.ToListAsync();
        }

        public async Task<IList<CultureInfo>> GetSupportedCultureInfoAsync()
        {
            var cultures = await this.GetSupportedCultureAsync().ConfigureAwait(false);

            return cultures.Select(c => new CultureInfo(c)).ToList();
        }
    }
}
