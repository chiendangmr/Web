using HD.Localization.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Views.Shared.Components.CultureSelect
{
    public class CultureSelectViewComponent : ViewComponent
    {
        private CultureProvider Provider { get; set; }
        public CultureSelectViewComponent(CultureProvider provider)
        {
            this.Provider = provider;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cultures = await Provider.GetSupportedCultureAsync();

            var vm = new CultureSelectViewModel
            {
                Id = Guid.NewGuid().ToString(),
                CurentCulture = new CultureViewModel
                {
                    Culture = CultureInfo.CurrentCulture.Name,
                    DisplayName = CultureInfo.CurrentCulture.NativeName,
                    RegionCode = new RegionInfo(
                            CultureInfo.CurrentCulture.TextInfo.CultureName
                        )
                        .TwoLetterISORegionName
                        .ToLowerInvariant()
                },
                SupportedCulture = cultures.Select(c => new CultureInfo(c)).Where(c => !c.IsNeutralCulture)
                    .OrderBy(c => c.EnglishName)
                    .Select(c => new CultureViewModel
                    {
                        Culture = c.Name,
                        DisplayName = c.NativeName,
                        RegionCode = new RegionInfo(c.Name)
                            .TwoLetterISORegionName
                            .ToLowerInvariant()
                    })
            };

            return View(vm);
        }
    }
}
