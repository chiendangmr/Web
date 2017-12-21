using HD.Localization;
using HD.TVAD.Web.Features.Manager;
using Microsoft.AspNetCore.Mvc;

namespace HD.TVAD.Web.Features.Language.Translator
{
    [Area("Tools")]
    public class TranslatorController : TVADController
	{
        public IActionResult Index()
        {
            return View();
        }
    }
}