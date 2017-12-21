using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Home.DevExtreme
{
    [Area("Home")]
    public class DevExtremeController : Controller
    {
        IMemoryCache _cache;
        readonly IStringLocalizer<DevExtremeController> _stringLocalizer;
        public DevExtremeController(IStringLocalizer<DevExtremeController> stringLocalizer, IMemoryCache cache)
        {
            _stringLocalizer = stringLocalizer;
            _cache = cache;
        }

        [HttpGet]
        public string Localizer(string text)
        {
            string key = $"DEVEXTREME{text}";
            string ret = _stringLocalizer[text].Value;
            return ret;
        }

        [HttpGet]
        public object GetAllLocalizer()
        {
            var locales = _stringLocalizer.GetAllStrings(true);
            IDictionary<string, object> results = new ExpandoObject() as IDictionary<string, object>;
            foreach(var locale in locales)
            {
                results.Add(locale.Name, locale.Value);
            }

            return Json(results);
        }
    }
}
