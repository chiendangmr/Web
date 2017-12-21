using HD.TVAD.Entities.Entities.Security;
using HD.TVAD.Web.Features.Manager;
using HD.TVAD.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Controllers
{
	[Authorize]
	public class NotificationController : TVADController
	{
		private readonly INotificationService _notificationService;
		private readonly UserManager<User> _userManager;
		public NotificationController(INotificationService notificationService,
			UserManager<User> userManager)
		{
			_notificationService = notificationService;
			_userManager = userManager;
		}
		public IActionResult Index()
		{
			return View();
		}
		public async Task<IActionResult> CheckUpdateAsync()
		{
			var user = await _userManager.GetUserAsync(User);
			var result = await _notificationService.CheckUpdateAsync(user.Id);
			//   Thread.Sleep(2000);
			return Json(result);
		}
		public async Task<IActionResult> MarkAsReadAllAsync()
		{
			var user = await _userManager.GetUserAsync(User);
			await _notificationService.MarkAsReadAllAsync(user.Id);
			return Json("Mark read all");
		}
		public async Task<IActionResult> UpdateAsync()
		{
			var user = await _userManager.GetUserAsync(User);
			var result = await _notificationService.GetAllNewNotificationAsync(user.Id);
			return Json(result);
		}
		public async Task<IActionResult> MarkAsReadAsync(IEnumerable<Guid> notificationIds)
		{
			var user = await _userManager.GetUserAsync(User);
			var result = 0;
			foreach (var notificationId in notificationIds)
			{
				await _notificationService.MarkAsReadAsync(user.Id, notificationId);
			}
			return Json(result);
		}
		public async Task<IActionResult> MarkAsUnReadAsync(IEnumerable<Guid> notificationIds)
		{
			var result = 0;

			var user = await _userManager.GetUserAsync(User);
			foreach (var notificationId in notificationIds)
			{
				await _notificationService.MarkAsUnReadAsync(user.Id, notificationId);
			}
			return Json(result);
		}
	}
}