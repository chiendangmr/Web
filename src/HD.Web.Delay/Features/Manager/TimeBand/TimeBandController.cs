using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Newtonsoft.Json;
using HD.TVAD.Web.Services;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using HD.TVAD.Web.Infrastructure;
using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using HD.TVAD.ApplicationCore.Entities.Booking;
using HD.TVAD.Web.StartData;

namespace HD.TVAD.Web.Features.Manager.TimeBands
{
	[Area("Manager")]
	[Authorize]
	[RequiresPermission(UserPermissions.ManagerSystem_TimeBand)]
	public class TimeBandController : TVADController
	{
		private ITimeBandService _timeBandService;
		private IChannelService _channelService;
		private ITimeBandBaseService _timeBandBaseService;
		private ITimeBandSliceForTypeService _timeBandSliceForTypeService;

		public TimeBandController(ITimeBandService timeBandService
			, IChannelService channelService
			,ITimeBandBaseService timeBandBaseService,
			ITimeBandSliceForTypeService timeBandSliceForTypeService)
		{
			_timeBandService = timeBandService;
			_channelService = channelService;
			_timeBandBaseService = timeBandBaseService;
			_timeBandSliceForTypeService = timeBandSliceForTypeService;
		}
		public IActionResult Index() {

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> GetAllTimeBand([DataSourceRequest]DataSourceRequest request)
		{
			try
			{
				var timeBands = _timeBandService.GetAll()
					.OrderBy(t => t.TimeBandBase.Name)
					.ToViewModel()
					.ToList();
				var channels = _channelService.GetAll();
				foreach (var timeband in timeBands)
				{
					if (channels.Any(c => c.Id == timeband.ParentId))
					{
						timeband.ParentId = null;
					}
				}
				var dataSourceResult = await timeBands.ToDataSourceResultAsync(request);

				foreach (TimeBandViewModel timeband in dataSourceResult.Data)
				{
					if (!dataSourceResult.Data
						.Cast<TimeBandViewModel>()
						.Any(a => a.Id == timeband.ParentId))
					{
						timeband.ParentId = null;
					}
				}

				return Json(dataSourceResult);
			}
			catch (Exception ex)
			{
				return new JsonErrorResult(ex.Message, HttpStatusCode.InternalServerError);
			}
		}

		[HttpGet]
		public async Task<IActionResult> GetAllTimeBandbyChannelId(Guid channelId)
		{
			try
			{

				var timeBands = await _timeBandService.GetAllTimeBandByChannelIdAsync(channelId);

				var model = timeBands.AsQueryable().ToViewModel();

				return Json(model);

			}
			catch (Exception ex)
			{
				return new JsonErrorResult(ex.Message, HttpStatusCode.InternalServerError);
			}
		}
		[HttpGet]
		public async Task<IActionResult> Create()
		{
			var dayOffWeedInt = 127;
			var dayOfWeek = (VisibleDayOfWeek)dayOffWeedInt;


			var today = DateTime.Today;
			var model = new TimeBandCreateIndexViewModel()
			{
				Name = "A",
				TimeBandDescription = new TimeBandDescriptionViewModel()
				{
					StartDate = today,
				},
				TimeBandDay = new TimeBandDayViewModel()
				{
					StartDate = today,
					DayOfWeekView = TimeBandUtil.ConvertDayOfWeekEnumToDayOfWeekViewModel(dayOfWeek),
				},
				TimeBandTime = new TimeBandTimeViewModel()
				{
					StartDate = today,
				},
				
			};
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Detail(Guid id)
		{

			var timeband = await _timeBandService.Get(id).FirstOrDefaultAsync();

			var model = timeband.ToViewModel();

			var dayOfWeek = (VisibleDayOfWeek)model.DayOfWeeks;

			model.TimeBandDay = new TimeBandDayViewModel()
			{
				DayOfWeekView = TimeBandUtil.ConvertDayOfWeekEnumToDayOfWeekViewModel(dayOfWeek),
			};

			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> Create(TimeBandCreateIndexViewModel viewModel)
		{

			if (ModelState.IsValid)
			{
				if (!viewModel.ParentId.HasValue)
				{
					viewModel.ParentId = viewModel.ChannelId;
				}
				var timeBand = viewModel.ToDataModel();

				if (_timeBandService.Exist(timeBand))
				{
					return JsonResponse(StatusType.ERROR, $"Exist {timeBand.TimeBandBase.Name}");
				}
				try
				{
					var result = await _timeBandService.Create(timeBand);

					return JsonResponse(result, ActionType.Create, timeBand.Id);
				}
				catch (Exception)
				{
					throw;
				}
			}
			else
				return JsonResponse(StatusType.ERROR, ModelState);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			try
			{
				var timeband = await _timeBandService.Get(id).FirstOrDefaultAsync();

				var channels = await _channelService.GetAll().ToListAsync();
				var model = new TimeBandEditViewModel() {
					Description = timeband.TimeBandBase.Description,
					Name = timeband.TimeBandBase.Name,
					Id = timeband.Id,
				};
				if (channels.Any(s => s.Id == timeband.TimeBandBase.ParentId)) // only timeband level 1
				{
					model.ChannelId = timeband.TimeBandBase.ParentId.Value;
				}
				else // timeband of timeband
				{
					model.ParentId = timeband.TimeBandBase.ParentId.Value;

					var timebandParent = await _timeBandService.Get(timeband.TimeBandBase.ParentId.Value).FirstOrDefaultAsync();
					if (channels.Any(s => s.Id == timebandParent.TimeBandBase.ParentId)) // timeband level 2
					{
						model.ChannelId = timebandParent.TimeBandBase.ParentId.Value;
					}
					else // timeband of timeband of Timeband
					{
						var timebandlevel2 = await _timeBandService.Get(timebandParent.TimeBandBase.ParentId.Value).FirstOrDefaultAsync();

						if (channels.Any(s => s.Id == timebandlevel2.TimeBandBase.ParentId)) // timeband level 3
						{
							model.ChannelId = timebandlevel2.TimeBandBase.ParentId.Value;
						}
						else
						{
							throw new Exception("Not support many timeband level");
						}
					}
				}


				return View(model);
			}
			catch (Exception ex)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> Edit(TimeBandEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var timeBand = await _timeBandService.Get(viewModel.Id).FirstOrDefaultAsync();

					timeBand.EditDataModel(viewModel);

					var result = await _timeBandService.Update(timeBand);

					return JsonResponse(result, ActionType.Edit, timeBand.Id);
				}
				catch (Exception)
				{
					throw;
				}
			}
			else
				return JsonResponse(StatusType.ERROR, ModelState);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			var timeband = await _timeBandBaseService.Get(id).FirstOrDefaultAsync();

			var model = new DeleteViewModel
			{
				Id = id,
				Name = timeband.Name,
			};

			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> Delete(TimeBandDeleteIndexViewModel viewModel)
		{
			try
			{
				var timeband = await _timeBandBaseService.Get(viewModel.Id).FirstOrDefaultAsync();

				var result = await _timeBandBaseService.Delete(timeband);

				return JsonResponse(result, ActionType.Delete);

			}
			catch (Exception)
			{
				throw;
			}
		}
		
		[HttpGet]
		public async Task<IActionResult> GetAllTimeBandSliceByTimeBandId(DataSourceRequest request, Guid timeBandId, BookingTypeEnum bookingType)
		{
			if(timeBandId == null)
			{
				throw new Exception();
			}
			var viewModel = new List<TimeBandSliceViewModel>();
			switch (bookingType)
			{
				case BookingTypeEnum.Retail:
					var slices = await _timeBandSliceForTypeService.GetTimeBandSliceForType(timeBandId, bookingType);

					slices.OrderBy(s => s.Name)
						.Each(t => {
						viewModel.Add(new TimeBandSliceViewModel()
						{
							Id = t.Id,
							Name = t.Name
						});
					});
					break;
				default:
					var timeBand = await _timeBandService.Get(timeBandId).FirstOrDefaultAsync();
					if (timeBand.TimeBandSlices != null)
					{
						timeBand.TimeBandSlices.Each(t => {
							viewModel.Add(new TimeBandSliceViewModel()
							{
								Id = t.Id,
								Name = t.Name
							});
						});
					}
					break;
			}
			return Json(viewModel.ToDataSourceResult(request));
		}
	}
}