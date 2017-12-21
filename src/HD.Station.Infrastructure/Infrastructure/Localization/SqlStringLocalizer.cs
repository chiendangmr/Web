using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using HD.Station.Models.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;

namespace HD.Station.Localization
{
    public class SqlStringLocalizer : IStringLocalizer
    {
        protected LocalizationDbContext DbContext { get; }
        protected CultureInfo Culture { get; }

        protected string BaseName { get; }

        protected IStringLocalizer Parent { get; }

        protected ILogger Logger { get; }

        IHostingEnvironment Environment { get; }

        public SqlStringLocalizer(LocalizationDbContext dbContext, string baseName, ILogger logger, IHostingEnvironment env)
            : this(dbContext, baseName, null, logger, env)
        {
        }

        public SqlStringLocalizer(LocalizationDbContext dbContext, string baseName, CultureInfo cultureInfo, ILogger logger, IHostingEnvironment env)
        {
            this.DbContext = dbContext;
            this.Culture = cultureInfo;
            this.BaseName = baseName ?? string.Empty;
            this.Logger = logger;
            this.Environment = env;
        }

        public LocalizedString this[string name]
        {
            get
            {
                name = name.Trim();
                var value = GetString(name);
                var resourceNotFound = value == null;

                if (value == null)
                {
                    value = this.Environment.IsDevelopment() ? "[" + name + "]" : name;
                }

                return new LocalizedString(name, value, resourceNotFound);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                name = name.Trim();
                var format = GetString(name);
                var resourceNotFound = format == null;
                if (format == null)
                {
                    format = this.Environment.IsDevelopment() ? "[" + name + "]" : name;
                }

                var value = string.Format(format, arguments);
                return new LocalizedString(name, value, resourceNotFound);
            }
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return new SqlStringLocalizer(DbContext, BaseName, culture, this.Logger, this.Environment);
        }

        private string GetString(string name)
        {
            var culture = this.Culture ?? CultureInfo.CurrentUICulture;

            StringLocalization value = null;
            try
            {
                do
                {
                    var query = DbContext.StringLocalizations
                        .Where(l => l.Culture == culture.Name)
                        .Where(l => BaseName.Contains(l.Location))
                        .OrderByDescending(l => l.Location.Length);

                    value = query.FirstOrDefault(l => l.Key == name);

                    culture = culture.Parent;
                } while (value == null && !string.IsNullOrEmpty(culture.Name));

            }
            catch { }

            if (this.Environment.IsDevelopment())
            {
                try
                {
                    if (!DbContext.StringLocalizables.Any(l => l.Key == name && l.Location == BaseName))
                    {

                        DbContext.StringLocalizables.Add(new StringLocalizable
                        {
                            Location = BaseName,
                            Key = name,
                            Description = name
                        });
                        DbContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogWarning(ex.ToString());
                }

            }

            if (value == null)
            {
                return null;
            }
            else if (this.Environment.IsDevelopment())
            {
                return "[" + value.Value + "]";
            }
            else
            {
                return value.Value;
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            var culture = this.Culture ?? CultureInfo.CurrentUICulture;

            do
            {
                var query = DbContext.StringLocalizations
                    .Where(l => l.Culture == culture.Name)
                    .OrderBy(l => l.Key)
                    .ThenBy(l => l.Location);

                foreach (var s in query.Select(l => new LocalizedString(l.Key, l.Value, true)))
                {
                    yield return s;
                }

                culture = culture.Parent;
            } while (includeParentCultures && !string.IsNullOrEmpty(culture.Name));
        }
    }
}
