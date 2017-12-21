using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HD.TVAD.Web.Services;
using HD.TVAD.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using HD.TVAD.ApplicationCore.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using HD.TVAD.Web.Features.Manager.SpotBlocks;
using HD.TVAD.Web.Infrastructure;
using HD.TVAD.Web.StartData;
using Microsoft.AspNetCore.Identity;
using HD.TVAD.Entities.Entities.Security;
//using HD.TVAD.ApplicationCore.Entities.Security;

namespace HD.TVAD.Web.Features.Manager
{
	[Area("Manager")]
	[Authorize]
//	[RequiresPermission(UserPermissions.Manager_SpotBlock)]
	[RequiresPermission(UserPermissions.ManagerSystem_SpotBlock)]
	public class SpotBlockController : TVADController
	{
		private ISpotBlockService _spotBlockService;
		private readonly INotificationService _notificationService;
		private readonly UserManager<User> _userManager;

		public SpotBlockController(ISpotBlockService spotBlockService,
			INotificationService notificationService,
			UserManager<User> userManager) {

			_spotBlockService = spotBlockService;
			_notificationService = notificationService;
			_userManager = userManager;
		}
		[HttpGet]
	//	[RequiresPermission(UserPermissions.Manager_SpotBlock)]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
	//	[RequiresPermission(UserPermissions.Manager_SpotBlock_Access)]
		public async Task<IActionResult> GetAllBlockAsync([DataSourceRequest]DataSourceRequest request)
		{
			var blocks = _spotBlockService.GetAll()
				.OrderBy(s => s.Duration);

			var dataSourceResult = await blocks.ToDataSourceResultAsync(request);				
			dataSourceResult.Data = dataSourceResult.Data.Cast<SpotBlock>().AsQueryable().ToViewModel();
			return Json(dataSourceResult);
		}
        [HttpGet]
	//	[RequiresPermission(UserPermissions.Manager_SpotBlock_Create)]
		public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
	//	[RequiresPermission(UserPermissions.Manager_SpotBlock_Create)]
		public async Task<IActionResult> CreateAsync(SpotBlockCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var block = viewModel.ToDataModel();
				try
				{					
					if (_spotBlockService.Exist(block))
					{
						throw new Exception($"Exist {block.Duration} s");
					}
					var result = await _spotBlockService.Create(block);
					var user = await _userManager.GetUserAsync(User);
					var notifi = new ApplicationCore.Entities.Notification() {
						Action = NotifiActtion.Create,
						CreateDate = DateTimeOffset.Now,
						Module = NotifiModule.SpotBlock,
						Type = NotifiType.Information,
						Content = $"{user.UserName} {ActionType.Create.GetDisplayName()} a spot block",
					};
					await _notificationService.MakeNotificationAsync(notifi);
					return JsonResponse(result, ActionType.Create, block);
				}
				catch (Exception ex)
				{
					return JsonResponse(StatusType.ERROR, ex.Message);
				}	
			}
			else
				return JsonResponse(StatusType.ERROR, "Input not valid, try again please!");
		}

		[HttpGet]
	//	[RequiresPermission(UserPermissions.Manager_SpotBlock_Delete)]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			try
			{
				var block = await _spotBlockService.Get(id).FirstOrDefaultAsync();

				var viewModel = new DeleteViewModel()
				{
					Id = block.Id,
					Name = block.Duration.ToString()
				};
				return View(viewModel);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
	//	[RequiresPermission(UserPermissions.Manager_SpotBlock_Delete)]
		public async Task<IActionResult> DeleteAsync(DeleteViewModel viewModel)
		{
			try
			{
				var block = await _spotBlockService.Get(viewModel.Id).FirstOrDefaultAsync();

				var result = await _spotBlockService.Delete(block);

				var user = await _userManager.GetUserAsync(User);
				var notifi = new ApplicationCore.Entities.Notification()
				{
					Action = NotifiActtion.Delete,
					CreateDate = DateTimeOffset.Now,
					Module = NotifiModule.SpotBlock,
					Type = NotifiType.Information,
					Content = $"{user.UserName} {ActionType.Delete.GetDisplayName()} a spot block",
				};
				await _notificationService.MakeNotificationAsync(notifi);

				return JsonResponse(result, ActionType.Delete);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpGet]
	//	[RequiresPermission(UserPermissions.Manager_SpotBlock_Edit)]
		public async Task<IActionResult> EditAsync(Guid id)
		{
			try
			{
				var block = await _spotBlockService.Get(id).FirstOrDefaultAsync();

				var viewModel = block.ToViewModel();
				return View(viewModel);
			}
			catch (Exception)
			{

				throw;
			}
		}
		[HttpGet]
	//	[RequiresPermission(UserPermissions.Manager_SpotBlock_Access)]
		public async Task<IActionResult> DetailAsync(Guid id)
		{
			try
			{
				var block = await _spotBlockService.Get(id).FirstOrDefaultAsync();

				var viewModel = block.ToViewModel();
				return View(viewModel);
			}
			catch (Exception)
			{

				throw;
			}
		}
		[HttpPost]
	//	[RequiresPermission(UserPermissions.Manager_SpotBlock_Edit)]
		public async Task<IActionResult> EditAsync(SpotBlockEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var block = await _spotBlockService.Get(viewModel.Id).FirstOrDefaultAsync();

				block.EditDataModel(viewModel);
				try
				{
					var result = await _spotBlockService.Update(block);

					var user = await _userManager.GetUserAsync(User);
					var notifi = new ApplicationCore.Entities.Notification($"{user.UserName} {ActionType.Edit.GetDisplayName()} a spot block");
					await _notificationService.MakeNotificationAsync(notifi);

					return JsonResponse(result, ActionType.Edit, block);
				}
				catch (Exception)
				{
					throw;
				}
			}
			else
			{
				return JsonResponse(StatusType.ERROR , "Input not valid, try again please!");
			}
		}
	}
}