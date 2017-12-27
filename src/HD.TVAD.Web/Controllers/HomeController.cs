using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HD.TVAD.Web.Features.Manager;
using Microsoft.Extensions.Logging;
using HD.TVAD.Web.Models;

namespace HD.TVAD.Web.Controllers
{
    [Authorize]
    public class HomeController : TVADController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        public IActionResult Subscribe()
        {
            return View();
        }
    }
}
