using HD.TVAD.Entities.Entities.Security;
using HD.TVAD.Web.Controllers;
using HD.TVAD.Web.Features.Home.Auth.Models;
using HD.TVAD.Web.Features.Manager;
using HD.TVAD.Web.Models.AccountViewModels;
using HD.TVAD.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Home
{
    [Area("Home")]
    [Authorize]
    public class AuthController : TVADController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;       
        private readonly ILogger _logger;
        private readonly string _externalCookieScheme;
        private readonly IStringLocalizer<AuthController> _localizer;

        public AuthController(UserManager<User> userManager,
            SignInManager<User> signInManager, 
            IOptions<IdentityCookieOptions> identityCookieOptions,           
            ILoggerFactory loggerFactory,
            IStringLocalizer<AuthController> localizer)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _externalCookieScheme = identityCookieOptions.Value.ExternalCookieAuthenticationScheme;            
            _logger = loggerFactory.CreateLogger<AuthController>();
            _localizer = localizer;
        }

        //
        // GET: Home/Auth/Login
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null, string none = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.Authentication.SignOutAsync(_externalCookieScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation(1, "User logged in.");
                    HttpContext.Session.Clear();
                    return RedirectToLocal(returnUrl);
                }

                if (result.IsLockedOut)
                {
                    _logger.LogWarning(2, "User account locked out.");
                    return View("Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, _localizer["The user name or password provided is incorrect."]);
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: Home/Auth/Register
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.UserName, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation(3, "User created a new account with password.");
                    HttpContext.Session.Clear();
                    return RedirectToLocal("/");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
		// GET: /Account/ForgotPassword
		[HttpGet]
		[AllowAnonymous]
		public IActionResult ForgotPassword()
		{
			return View();
		}

		//
		// POST: /Account/Logout
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation(4, "User logged out.");
            HttpContext.Session.Clear();
            return Redirect("/");
        }

        public class SetCultureForm
        {
            public string culture { get; set; }
		}
		public class SetThemeForm
		{
			public string theme { get; set; }
		}
		[HttpPost]
        [AllowAnonymous]
        public IActionResult SetLanguage([FromBody] SetCultureForm config)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(config.culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            var changedLang = Encoding.UTF8.GetBytes("true");
            HttpContext.Session.Set("ChangedLanguage", changedLang);

            return Json(config);
        }

		[HttpPost]
		[AllowAnonymous]
		public IActionResult SetTheme([FromBody] SetThemeForm config)
		{
			Response.Cookies.Append(
				"theme",
				config.theme,
				new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
			);

			var changedTheme = Encoding.UTF8.GetBytes("true");
			HttpContext.Session.Set("ChangedTheme", changedTheme);

			return Json(config);
		}
		#region Helpers

		private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return Redirect("/");
            }
        }

		#endregion
		[HttpGet]
		public IActionResult AccessDenied()
		{
			return View();
		}

	}
}