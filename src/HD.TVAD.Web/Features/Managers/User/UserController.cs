using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HD.TVAD.Web.Features.Managers.User.Models;
using HD.TVAD.Web.Features.Manager;

namespace HD.TVAD.Web.Features.Managers.User
{
    [Area("Managers")]
    [Authorize]
    public class UserController : TVADController
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult SetGroupPartial(Guid userId)
        {
            return PartialView(new UserSetViewModel()
            {
                userId = userId
            });
        }

        public IActionResult SetPermissionPartial(Guid userId)
        {
            return PartialView(new UserSetViewModel()
            {
                userId = userId
            });
        }
    }
}