using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HD.Localization.Repositories
{
    public class CultureProvider
    {
        private LocalizationDbContext DbContext { get; set; }

        private IMemoryCache MemoryCache { get; set; }

        private ILogger Logger { get; set; }

        public CultureProvider(LocalizationDbContext dbContext, ILogger<CultureProvider> logger, IMemoryCache cache)
        {
            DbContext = dbContext;

            MemoryCache = cache;
        }

        public Task<List<string>> GetSupportedCultureAsync()
        {
            return DbContext.Cultures
                .Where(c => !c.Disabled && c.Parent != null && !c.Parent.Disabled)
                .Select(c => c.Name)
                .ToListAsync();
        }

        public async Task<IList<CultureInfo>> GetSupportedCultureInfoAsync()
        {
            var cultures = await GetSupportedCultureAsync().ConfigureAwait(false);

            return cultures.Select(c => new CultureInfo(c)).ToList();
        }

        public Task<List<string>> GetSupportedOriginCultureAsync()
        {
            return DbContext.Cultures
                .Where(c => !c.Disabled && c.Parent == null)
                .Select(c => c.Name)
                .ToListAsync();
        }
    }
}
