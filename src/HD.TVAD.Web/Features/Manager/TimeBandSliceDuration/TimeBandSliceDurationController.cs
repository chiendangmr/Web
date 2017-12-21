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

namespace HD.TVAD.Web.Features.Manager.TimeBandSliceDurations
{
	[Area("Manager")]
	[Authorize]
	public class TimeBandSliceDurationController : TVADController
	{
		private ITimeBandSliceDurationService _timeBandSliceDurationService;
		private ITimeBandSliceService _timeBandSliceService;
		private ITimeBandService _timeBandService;
		public TimeBandSliceDurationController(
			ITimeBandSliceDurationService timeBandSliceDurationService,
			ITimeBandSliceService timeBandSliceService,
			ITimeBandService timeBandService
			)
		{
			_timeBandSliceDurationService = timeBandSliceDurationService;
			_timeBandSliceService = timeBandSliceService;
			_timeBandService = timeBandService;
		}
		[HttpGet]
		public async Task<IActionResult> Index(Guid id) {

			var timebandSlice = await _timeBandSliceService.Get(id).FirstOrDefaultAsync();

			var timeband = await _timeBandService.Get(timebandSlice.TimeBandId).FirstOrDefaultAsync();

			var model = new TimeBandSliceDurationIndexViewModel()
			{
				TimeBandSliceId = id,
				TimeBandName = timeband.TimeBandName,
				TimeBandSliceName = timebandSlice.Name,
			};
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllTimeBandSliceDurationByTimeBandSliceId(DataSourceRequest request, Guid timeBandSliceId)
		{
			try
			{
				var timeBandSlice = await _timeBandSliceService.Get(timeBandSliceId).FirstOrDefaultAsync();
				if (timeBandSlice != null)
				{
					var result = timeBandSlice.TimeBandSliceDurations
						.AsQueryable()
						.ToViewModel()
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
			var model = new TimeBandSliceDurationCreateViewModel()
			{
				TimeBandSliceId = id,
				StartDate = DateTime.Today
			};
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> CreateAsync(TimeBandSliceDurationCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();
				try
				{
					var result = await _timeBandSliceDurationService.Create(dataModel);

					return JsonResponse(result, ActionType.Create, dataModel.Id);
				}
				catch (Exception)
				{
					throw;
				}
			}
			else
			{
				return Json(ModelState);
			}
		}
		[HttpGet]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			try
			{
				var result = await _timeBandSliceDurationService.Get(id).FirstOrDefaultAsync();

				var model = new DeleteViewModel()
				{
					Id = id,
					Name = $"From {result.StartDate.ToString("dd/MM/yyyy")}",
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
				var resultGet = await _timeBandSliceDurationService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _timeBandSliceDurationService.Delete(resultGet);

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
				var result = await _timeBandSliceDurationService.Get(id).FirstOrDefaultAsync();
				var model = result.ToViewModel();

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAsync(TimeBandSliceDurationEditViewModel viewModel)
		{
			try
			{
				var timeBandSliceDuration = await _timeBandSliceDurationService.Get(viewModel.Id).FirstOrDefaultAsync();
				timeBandSliceDuration.EditDataModel(viewModel);

				var result = await _timeBandSliceDurationService.Update(timeBandSliceDuration);

				return JsonResponse(result, ActionType.Edit, timeBandSliceDuration.Id);
			}
			catch (Exception)
			{
				throw;
			}
		}

	}
}