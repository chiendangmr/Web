using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Data.SqlClient;

namespace HD.Localization.Repositories
{
    public class SqlStringLocalizer : IStringLocalizer
    {
        protected LocalizationDbContext DbContext { get; private set; }

        protected CultureInfo Culture { get; private set; }

        protected string BaseName { get; private set; }

        protected IStringLocalizer Parent { get; private set; }

        protected ILogger Logger { get; private set; }

        IHostingEnvironment Environment { get; }

        IMemoryCache _memoryCache;

        public SqlStringLocalizer(LocalizationDbContext dbContext, string baseName, ILogger logger, IHostingEnvironment env, IMemoryCache memoryCache)
            : this(dbContext, baseName, null, logger, env, memoryCache)
        {

        }

        public SqlStringLocalizer(LocalizationDbContext dbContext, string baseName, CultureInfo cultureInfo, ILogger logger, IHostingEnvironment env, IMemoryCache memoryCache)
        {
            DbContext = dbContext;
            Culture = cultureInfo;
            BaseName = baseName ?? string.Empty;
            Logger = logger;
            Environment = env;
            _memoryCache = memoryCache;
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
                    value = Environment.IsDevelopment() ? "[" + name + "]" : name;
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
                    format = Environment.IsDevelopment() ? "[" + name + "]" : name;
                }

                var value = string.Format(format, arguments);
                return new LocalizedString(name, value, resourceNotFound);
            }
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return new SqlStringLocalizer(DbContext, BaseName, culture, Logger, Environment, _memoryCache);
        }

        private string GetString(string name)
        {
            IEnumerable<LocalizedText> trans = null;
            string cacheName = $"Localizator_{BaseName}";
            if (!_memoryCache.TryGetValue<IEnumerable<LocalizedText>>(cacheName, out trans) || trans == null || trans.Count() == 0)
            {
                trans = GetAllTranslators(true);
            }
            if (trans != null && trans.Count() > 0)
                _memoryCache.Set<IEnumerable<LocalizedText>>(cacheName, trans, TimeSpan.FromSeconds(60));

            #region Find old
            //var culture = Culture ?? CultureInfo.CurrentUICulture;

            //LocalizedText value = null;

            //try
            //{
            //    do
            //    {
            //        value = DbContext.LocalizedTexts
            //            .Where(l => !l.Disabled && l.Key == name && l.Culture == culture.Name)
            //            .Where(l => !string.IsNullOrWhiteSpace(l.Value))
            //            .OrderBy(l => l.Scope == BaseName ? 0 : 1)
            //            .ThenBy(l => BaseName.StartsWith(l.Scope) ? 0 : 1)
            //            .ThenBy(l => l.Scope == null || l.Scope == "" ? 0 : 1)
            //            .FirstOrDefault();

            //        culture = culture.Parent;
            //    } while (value == null && culture != null && !string.IsNullOrEmpty(culture.Name));
            //}
            //catch { }
            #endregion

            var value = trans.Where(t => t.Key.ToLower() == name.ToLower() && !string.IsNullOrWhiteSpace(t.Value))
                .OrderBy(t => t.Key == name ? 0 : 1)
                .ThenBy(t => t.Scope == BaseName ? 0 : 1)
                .FirstOrDefault();

            if (Environment.IsDevelopment() && !trans.Any(t => t.Key == name && t.Scope == BaseName))
            {
                try
                {
                    if (!DbContext.LocalizableTexts.Any(l => l.Key == name && l.Scope == BaseName))
                    {
                        DbContext.LocalizableTexts.Add(new LocalizableText
                        {
                            Scope = BaseName,
                            Key = name,
                            Description = name
                        });
                        DbContext.SaveChanges();
                    }

                    if (!DbContext.LocalizableTexts.Any(l => l.Key == name && l.Scope == ""))
                    {
                        DbContext.LocalizableTexts.Add(new LocalizableText
                        {
                            Scope = "",
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

            string text = value == null || string.IsNullOrWhiteSpace(value.Value) ? name : value.Value;

            if (Environment.IsDevelopment())
            {
                return "[" + text + "]";
            }
            else
            {
                return text;
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            //var culture = this.Culture ?? CultureInfo.CurrentUICulture;

            //do
            //{
            //    var query = DbContext.LocalizedTexts
            //        .Where(l => l.Culture == culture.Name)
            //        .OrderBy(l => l.Key)
            //        .ThenBy(l => l.Scope);

            //    foreach (var s in query.Select(l => new LocalizedString(l.Key, l.Value, true)))
            //    {
            //        yield return s;
            //    }

            //    culture = culture.Parent;
            //} while (includeParentCultures && !string.IsNullOrEmpty(culture.Name));

            return GetAllTranslators(includeParentCultures)
                .GroupBy(t => t.Key)
                .Select(t => t.OrderBy(tt => !string.IsNullOrWhiteSpace(tt.Value) ? 0 : 1).First())
                .Select(l => new LocalizedString(l.Key, l.Value ?? l.Key, true));
        }

        IEnumerable<LocalizedText> GetAllTranslators(bool includeParentCultures)
        {
            using (var con = new SqlConnection(DbContext.Database.GetDbConnection().ConnectionString))
            {
                var culture = this.Culture ?? CultureInfo.CurrentUICulture;
                var allStrings = con.Query<LocalizableText>(@"Select Id, [Key], Scope
                    From Language.LocalizableTexts
                    Where Scope = @Scope", new { Scope = BaseName })
                .Where(l => !string.IsNullOrWhiteSpace(l.Key))
                .Select(l => new LocalizedText
                {
                    Scope = l.Scope,
                    Key = l.Key
                }).ToList();

                if (allStrings.Count > 0)
                {
                    List<string> cultures = new List<string>();
                    var currentCulture = culture;
                    while (!string.IsNullOrWhiteSpace(currentCulture.Name))
                    {
                        cultures.Add(currentCulture.Name);
                        if (!includeParentCultures)
                            break;
                        currentCulture = currentCulture.Parent;
                    }

                    if (cultures.Count > 0)
                    {
                        // Get all localizer texts with key
                        var allKeys = string.Join(",", allStrings.Select(l => "N'" + l.Key.Replace("'", "''") + "'"));
                        if (!string.IsNullOrWhiteSpace(allKeys))
                        {
                            var trans = con.Query<LocalizedText>(@"Select Scope, [Key], Culture, Value
                            From Language.LocalizedTexts
                            Where Disabled = 0
	                            And Culture in (" + string.Join(",", cultures.Select(c => "N'" + c + "'")) + @")
	                            And [Key] in (" + allKeys + ")")
                                    .Where(t => !string.IsNullOrWhiteSpace(t.Value))
                                    .GroupBy(t => t.Key.ToLower());
                            foreach (var curTrans in trans)
                            {
                                var strs = allStrings.Where(s => s.Key.ToLower() == curTrans.Key).ToList();
                                foreach (var str in strs)
                                {
                                    var tran = curTrans.OrderBy(t => t.Key == str.Key ? 0 : 1)
                                                .ThenBy(t => t.Scope == BaseName ? 0 : 1)
                                                .ThenBy(t => BaseName.Contains(t.Scope) ? 0 : 1)
                                                .ThenBy(t => t.Scope == "" ? 0 : 1)
                                                .First();
                                    if (tran.Key == str.Key && tran.Scope == str.Scope)
                                        str.Value = tran.Value;
                                    else
                                        allStrings.Add(new LocalizedText
                                        {
                                            Scope = str.Scope,
                                            Key = str.Key,
                                            Value = tran.Value
                                        });
                                }
                            }
                        }
                    }
                }

                return allStrings;
            }
        }
    }
}
