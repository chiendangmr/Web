using HD.TVAD.Web.Features.Manager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Managers.UserGroup
{
    [Area("Managers")]
    [Authorize]
    public class UserGroupController : TVADController
	{
        public IActionResult Index()
        {
            return View();
        }
    }
}
