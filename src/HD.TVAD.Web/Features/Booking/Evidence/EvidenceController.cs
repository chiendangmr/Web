using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HD.TVAD.Web.Features.Booking.Evidence
{
    [Area("Booking")]
    public class EvidenceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}