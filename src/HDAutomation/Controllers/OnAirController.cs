using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HDAutomation.Controllers
{
    public class OnAirController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}