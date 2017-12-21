using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HD.TVAD.Web.Features.Manager;

namespace HD.TVAD.Web.Features.Tools.Menu
{
    [Area("Tools")]
    public class MenuController : TVADController
	{
        public IActionResult Index()
        {
            return View();
        }
    }
}