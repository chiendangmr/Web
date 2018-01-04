using HD.TVAD.Web.Services;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HD.TVAD.Entities.Entities.Security;
using HD.TVAD.Entities.Entities;
using HD.TVAD.Entities.Repositories.Security;
using Microsoft.Extensions.Localization;
using HD.TVAD.Entities.Repositories;
using HD.TVAD.Web.Models;
using Newtonsoft.Json;
using HD.TVAD.Web.Features.Manager;
using HD.TVAD.Web.Features.Managers.User.Models;
using HD.TVAD.Web.Infrastructure;
using HD.TVAD.Web.StartData;

namespace HD.TVAD.Features.Manager
{
    [Area("Manager")]
	[Authorize]
	public class SubtitleController : TVADController
	{	

		public SubtitleController()
		{
			
		}
		
		public IActionResult Index()
		{

			return View();
		}		
        public IActionResult TimeSlider()
        {
            return View();
        }
	}
}