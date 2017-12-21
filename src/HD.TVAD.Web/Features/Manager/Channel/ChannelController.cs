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
using HD.TVAD.Web.StartData;
using HD.TVAD.Web.Infrastructure;

namespace HD.TVAD.Web.Features.Manager.Channels
{
	[Area("Manager")]
	[Authorize]
	[RequiresPermission(UserPermissions.ManagerSystem_Channel)]
	public class ChannelController : TVADController
	{
		private IChannelService _channelService;
		private ITimeBandBaseService _timeBandBaseService;
		public ChannelController(IChannelService channelService,
			ITimeBandBaseService timeBandBaseService)
		{
			_channelService = channelService;
			_timeBandBaseService = timeBandBaseService;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync([DataSourceRequest]DataSourceRequest request)
		{
			var channels = _channelService.GetAll();
			var dataSourceResult = await channels.ToDataSourceResultAsync(request);
			dataSourceResult.Data = dataSourceResult.Data
				.Cast<Channel>()
				.AsQueryable()
				.ToViewModel()
				.ToList();

			foreach (ChannelViewModel channel in dataSourceResult.Data)
			{
				if (!dataSourceResult.Data
					.Cast<ChannelViewModel>()
					.Any(a => a.Id == channel.ParentId))
				{
					channel.ParentId = null;
				}
			}
			return Json(dataSourceResult);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync(ChannelCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var dataModel = viewModel.ToDataModel();

					if (_channelService.Exist(dataModel))
						throw new Exception("Exist channel " + viewModel.Name);

					var result = await _channelService.Create(dataModel);

					return JsonResponse(result, ActionType.Create, dataModel.Id);
				}
				catch (Exception ex)
				{
					return JsonResponse(StatusType.ERROR, ex.Message);
				}
			}
			else
				return JsonResponse(StatusType.ERROR, ModelState);
		}

		[HttpGet]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			try
			{
				var channel = await _channelService.Get(id).FirstOrDefaultAsync();
				var viewModel = new DeleteViewModel()
				{
					Id = channel.Id,
					Name = channel.TimeBandBase.Name,
				};
				return View(viewModel);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> DeleteAsync(DeleteViewModel viewModel)
		{
			try
			{
				var channel = await _timeBandBaseService.Get(viewModel.Id).FirstOrDefaultAsync();

				var result = await _timeBandBaseService.Delete(channel);

				return JsonResponse(result, ActionType.Delete);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpGet]
		public async Task<IActionResult> EditAsync(Guid id)
		{
			try
			{
				var channel = await _channelService.Get(id).FirstOrDefaultAsync();

				var viewModel = channel.ToViewModel();

				return View(viewModel);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAsync(ChannelEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var channel = await _channelService.Get(viewModel.Id).FirstOrDefaultAsync();
					if (channel.Id == viewModel.ParentId)
						throw new Exception("Don't allow parent itself!");
					if (channel.TimeBandBase.Name != viewModel.Name)
					{
						if (_channelService.ExistName(viewModel.Name))
							throw new Exception($"Exist {viewModel.Name}");
					}
					channel.EditDataModel(viewModel);
					var result = await _channelService.Update(channel);

					return JsonResponse(result, ActionType.Edit, viewModel);
				}
				catch (Exception ex)
				{
					return JsonResponse(StatusType.ERROR, ex.Message);
				}
			}
			else
			{
				return JsonResponse(StatusType.ERROR, ModelState);
			}
		}
	}
}