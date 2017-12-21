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
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;

namespace HD.TVAD.Web.Features.Manager.TimeBandSliceDurationByTypes
{
	[Area("Manager")]
	[Authorize]
	public class TimeBandSliceDurationByTypeController : TVADController
	{
		private ITimeBandSliceDurationService _timeBandSliceDurationService;
		private ITimeBandSliceDurationByTypeService _timeBandSliceDurationByTypeService;
		private ITimeBandSliceService _timeBandSliceService;
		private ITimeBandService _timeBandService;
		private IStringLocalizer<TimeBandSliceDurationByTypeController> _localizer;
		public TimeBandSliceDurationByTypeController(
			ITimeBandSliceDurationService timeBandSliceDurationService,
			ITimeBandSliceDurationByTypeService timeBandSliceDurationByTypeService,
			ITimeBandSliceService timeBandSliceService,
			ITimeBandService timeBandService,
			IStringLocalizer<TimeBandSliceDurationByTypeController> localizer)
		{
			_timeBandSliceDurationService = timeBandSliceDurationService;
			_timeBandSliceDurationByTypeService = timeBandSliceDurationByTypeService;
			_timeBandSliceService = timeBandSliceService;
			_timeBandService = timeBandService;
			_localizer = localizer;
		}
		[HttpGet]
		public async Task<IActionResult> Index(Guid id) {

			var timeBandSliceDuration = await _timeBandSliceDurationService.Get(id).FirstOrDefaultAsync();

			var timebandSlice = await _timeBandSliceService.Get(timeBandSliceDuration.TimeBandSliceId).FirstOrDefaultAsync();

			var timeband = await _timeBandService.Get(timebandSlice.TimeBandId).FirstOrDefaultAsync();

			var model = new TimeBandSliceDurationByTypeIndexViewModel()
			{
				TimeBandSliceDurationId = id,
				TimeBandName = timeband.TimeBandName,
				TimeBandSliceName = timebandSlice.Name,
				TimeBandSliceDurationDetail = $"{timeBandSliceDuration.Duration}s from {timeBandSliceDuration.StartDate.ToString("dd/MM/yyyy")}",
			};
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllTimeBandSliceDurationByTypeByTimeBandSliceDurationId(DataSourceRequest request, Guid timeBandSliceDurationId)
		{
			try
			{
				var timeBandSliceDuration = await _timeBandSliceDurationService.Get(timeBandSliceDurationId).FirstOrDefaultAsync();
				if (timeBandSliceDuration != null)
				{
					var result = timeBandSliceDuration.TimeBandSliceDurationByTypes
						.AsQueryable()
						.ToViewModel(_localizer)
						.ToDataSourceResult(request);

					return Json(result);
				}
				else
					throw new NullReferenceException();
			}
			catch (Exception)
			{
				throw;
			}
		}


		[HttpGet]
		public async Task<IActionResult> Create(Guid id)
		{
			var model = new TimeBandSliceDurationByTypeCreateViewModel()
			{
				TimeBandSliceDurationId = id,
			};
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> CreateAsync(TimeBandSliceDurationByTypeCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();
				try
				{
					var result = await _timeBandSliceDurationByTypeService.Create(dataModel);

					return JsonResponse(result, ActionType.Create, dataModel.Id);
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
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			try
			{
				var result = await _timeBandSliceDurationByTypeService.Get(id).FirstOrDefaultAsync();

				var model = new DeleteViewModel()
				{
					Id = id,
					Name = result.Type.Name,
				};
				return View(model);
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
				var resultGet = await _timeBandSliceDurationByTypeService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _timeBandSliceDurationByTypeService.Delete(resultGet);
				return JsonResponse(resultDelete, ActionType.Delete);

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
				var result = await _timeBandSliceDurationByTypeService.Get(id).FirstOrDefaultAsync();
				var model = result.ToViewModel(_localizer);

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAsync(TimeBandSliceDurationByTypeEditViewModel viewModel)
		{
			try
			{
				var timeBandSliceDurationByType = await _timeBandSliceDurationByTypeService.Get(viewModel.Id).FirstOrDefaultAsync();
				timeBandSliceDurationByType.EditDataModel(viewModel);

				var result = await _timeBandSliceDurationByTypeService.Update(timeBandSliceDurationByType);

				return JsonResponse(result, ActionType.Edit, timeBandSliceDurationByType.Id);
			}
			catch (Exception)
			{
				throw;
			}
		}


	}
}