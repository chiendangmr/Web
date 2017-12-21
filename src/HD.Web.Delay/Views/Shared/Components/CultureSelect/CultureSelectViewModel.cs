using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Views.Shared.Components.CultureSelect
{
    public class CultureSelectViewModel
    {
        public string Id { get; set; }
        public CultureViewModel CurentCulture { get; set; }
        public IEnumerable<CultureViewModel> SupportedCulture { get; set; }
    }
}
