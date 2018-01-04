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
using HD.TVAD.Web.StartData;
using HD.TVAD.Web.Models.ManageViewModels;
using Microsoft.Extensions.Logging;

namespace HD.TVAD.Web.Features.Home
{
	[Area("Home")]
	[Authorize]
	public class ManageController : TVADController
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;

		private readonly IUserService _userService;
		private readonly ILogger<TVADController> _logger;

		public ManageController(
			UserManager<User> userManager,
			SignInManager<User> signInManager,
			 IUserService userService,
			 ILogger<TVADController> logger)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_userService = userService;
			_logger = logger;
		}
		public async Task<IActionResult> IndexAsync()
		{
			var user = await _userManager.GetUserAsync(User);

			var model = new ManageAccountIndexViewModel() {
				Id = user.Id,
				Name = user.Name,
				FullName = user.FullName,
				Email = user.Email,
				Active = user.Active,
				PhoneNumber = user.PhoneNumber,
				UserName = user.UserName,
			};

			return View(model);
		}
		//
		// GET: /Manage/ChangePassword
		[HttpGet]
		public IActionResult ChangePassword()
		{
			return View();
		}

		//
		// GET: /Manage/ChangePassword
		[HttpGet]
		public IActionResult Setting()
		{
			return View();
		}
		//
		// POST: /Manage/ChangePassword
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var user = await _userManager.GetUserAsync(User);
			if (user != null)
			{
				var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
				if (result.Succeeded)
				{
					await _signInManager.SignInAsync(user, isPersistent: false);
					_logger.LogInformation(3, "User changed their password successfully.");
					ViewData["Message"] = ManageMessageId.ChangePasswordSuccess.ToString();
					return RedirectToAction("", new { Message = ManageMessageId.ChangePasswordSuccess });
				}
				AddErrors(result);
				return View(model);
			}
			return RedirectToAction("", new { Message = ManageMessageId.Error });
		}
		#region Helpers

		private void AddErrors(IdentityResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(string.Empty, error.Description);
			}
		}

		public enum ManageMessageId
		{
			AddPhoneSuccess,
			AddLoginSuccess,
			ChangePasswordSuccess,
			SetTwoFactorSuccess,
			SetPasswordSuccess,
			RemoveLoginSuccess,
			RemovePhoneSuccess,
			Error
		}

		private Task<User> GetCurrentUserAsync()
		{
			return _userManager.GetUserAsync(HttpContext.User);
		}

		#endregion
	}
}
