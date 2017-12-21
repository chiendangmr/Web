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
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace HD.TVAD.Web.Features.Manager.TimeBandSlices
{
	[Area("Manager")]
	[Authorize]
	public class TimeBandSliceController : TVADController
	{
		private ITimeBandSliceService _timeBandSliceService;
		private ITimeBandService _timeBandService;
		private ITimeBandSliceDurationByTypeService _timeBandSliceDurationByTypeService;

		public TimeBandSliceController(ITimeBandSliceService timeBandSliceService,
			ITimeBandService timeBandService,
			ITimeBandSliceDurationByTypeService timeBandSliceDurationByTypeService) {

			_timeBandSliceService = timeBandSliceService;
			_timeBandService = timeBandService;
			_timeBandSliceDurationByTypeService = timeBandSliceDurationByTypeService;
		}
		[HttpGet]
		public async Task<IActionResult> Index(Guid id)
		{
			var timeband = await _timeBandService.Get(id).FirstOrDefaultAsync();
			var model = new TimeBandSliceIndexViewModel()
			{
				TimeBandId = id,
				TimeBandName = timeband.TimeBandName,
			};
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllTimeBandSliceByTimeBandId(DataSourceRequest request, Guid TimeBandId)
		{
			try
			{
				var timeBandslices = _timeBandSliceService.GetAll()
					.Where(t => t.TimeBandId == TimeBandId)
					.OrderBy(s => s.Name)
					.ToViewModel();

				var result = await timeBandslices.ToDataSourceResultAsync(request);

				return Json(result);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpGet]
		public async Task<IActionResult> Create(Guid id)
		{
			var today = DateTime.Today;
			var model = new TimeBandSliceCreateViewModel()
			{
				TimeBandId = id,
				Description = new TimeBandSliceDescriptionCreateViewModel() {
					StartDate = today,
				},
				Duration = new TimeBandSliceDurationCreateViewModel() {
					StartDate = today,
				},
			};
			return View(model);
		}
		[HttpGet]
		public async Task<IActionResult> Detail(Guid id)
		{
			var result = await _timeBandSliceService.Get(id).FirstOrDefaultAsync();
			var model = Mapper.Map<TimeBandSliceViewModel>(result);
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> Create(TimeBandSliceCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var timeBandSlice = viewModel.ToDataModel();
				try
				{
					var result = await _timeBandSliceService.Create(timeBandSlice);

					return JsonResponse(result, ActionType.Create, timeBandSlice.Id);
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

			var result = await _timeBandSliceService.Get(id).FirstOrDefaultAsync();

			var model = new TimeBandSliceEditViewModel()
			{
				Id = result.Id,
				Name = result.Name,
			};
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(TimeBandSliceEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var timeBandSlice = await _timeBandSliceService.Get(viewModel.Id).FirstOrDefaultAsync();
					timeBandSlice.EditDataModel(viewModel);

					var result = await _timeBandSliceService.Update(timeBandSlice);

					return JsonResponse(result, ActionType.Edit, timeBandSlice.Id);
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
			var timebandSlice = await _timeBandSliceService.Get(id).FirstOrDefaultAsync();

			var model = new TimeBandSliceDeleteViewModel
			{
				Id = id,
				Name = timebandSlice.Name,
			};

			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> Delete(TimeBandSliceDeleteViewModel viewModel)
		{
			try
			{
				var timebandSlice = await _timeBandSliceService.Get(viewModel.Id).FirstOrDefaultAsync();

				var result = await _timeBandSliceService.Delete(timebandSlice);

				return JsonResponse(result, ActionType.Delete);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpGet]
		public async Task<IActionResult> GetMaxDuration(Guid timeBandSliceId, DateTime broadcastDate)
		{
			var timebandslice = await _timeBandSliceService.Get(timeBandSliceId).FirstOrDefaultAsync();

			var viewModel = new TimeBandSliceMaxDurationViewModel()
			{
				MaxDuration = timebandslice.TimeBandSliceDurations
					.Where(t => t.StartDate <= broadcastDate)
					.OrderByDescending(t => t.StartDate)
					.FirstOrDefault()?
					.Duration,
				MaxDurationId = timebandslice.TimeBandSliceDurations
					.Where(t => t.StartDate <= broadcastDate)
					.OrderByDescending(t => t.StartDate)
					.FirstOrDefault()?
					.Id,
				TimeBandSliceDurationByTypes = new List<TimeBandSliceDurationByTypeViewModel>(),
			};
			var timedurationbyTypes = await _timeBandSliceDurationByTypeService.GetAll()
				.Where(t => t.TimeBandSliceDurationId == viewModel.MaxDurationId)
				.ToListAsync();

			timedurationbyTypes.Each(t => {
				viewModel.TimeBandSliceDurationByTypes.Add(new TimeBandSliceDurationByTypeViewModel() {
					TimeBandSliceDurationId = t.TimeBandSliceDurationId,
					BookingTypeId = t.TypeId,
					BookingTypeName = t.Type.Name,
					Duration = t.Duration,
					Id = t.Id
				});
			});
			return Json(viewModel);
		}
	}
}