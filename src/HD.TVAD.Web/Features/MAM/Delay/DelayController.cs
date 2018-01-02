using Microsoft.AspNetCore.Mvc;
using HD.TVAD.Web.Services;
using System.Linq;
using System;
using HD.TVAD.Web.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using HD.TVAD.Web.Features.MAM.Content.Business;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Threading.Tasks;
using HD.TVAD.Web.Features.Manager;

namespace HD.TVAD.Web.Features.MAM.Evidence
{
    [Area("MAM")]
    [Authorize]
    public class DelayController : TVADController
    {        
        private DelayBusiness _evidenceBusiness;

        public DelayController(IHostingEnvironment hostingEnvironment, IOptions<Settings> settings)
        {            
            _evidenceBusiness = new DelayBusiness(hostingEnvironment, settings);
        }
        public IActionResult Index()
        {            
            return View();
        }         
    }
}