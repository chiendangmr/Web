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
using HD.TVAD.Web;
using Microsoft.AspNetCore.Authorization;

namespace HD.TVAD.Web.Features.Manager.TimeBandTimes
{
	[Area("Manager")]
	[Authorize]
	public class TimeBandTimeController : TVADController
	{
		public ITimeBandTimeService _timeBandTimeService;
		private ITimeBandService _timeBandService;

		public TimeBandTimeController(ITimeBandTimeService timeBandTimeService
			, ITimeBandService timeBandService) {

			_timeBandTimeService = timeBandTimeService;
			_timeBandService = timeBandService;
		}
		[HttpGet]
		public async Task<IActionResult> Index(Guid id) {

			var timeband = await _timeBandService.Get(id).FirstOrDefaultAsync();
			var model = new TimeBandSliceIndexViewModel()
			{
				TimeBandId = id,
				TimeBandName = timeband.TimeBandName,
			};
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllTimeBandTimeByTimeBandId(DataSourceRequest request, Guid TimeBandId)
		{
			try
			{
				var timeBand = await _timeBandService.Get(TimeBandId).FirstOrDefaultAsync();
				if (timeBand != null)
				{
					var result = timeBand.TimeBandTimes
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
			var model = new TimeBandTimeCreateViewModel()
			{
				StartDate = DateTime.Today,
				TimeBandId = id,
				EndTime = DateTime.Today.TimeOfDay,
				StartTimeOfDay = DateTime.Today.TimeOfDay,
			};
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> Create(TimeBandTimeCreateViewModel formModel)
		{
			if (ModelState.IsValid)
			{
				var entity = formModel.ToDataModel();
				try
				{
					var result = await _timeBandTimeService.Create(entity);

					return JsonResponse(result, ActionType.Create, entity.Id);
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
				var result = await _timeBandTimeService.Get(id).FirstOrDefaultAsync();
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
				var resultGet = await _timeBandTimeService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _timeBandTimeService.Delete(resultGet);

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
				var result = await _timeBandTimeService.Get(id).FirstOrDefaultAsync();
				var model = result.ToEditViewModel();

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAsync(TimeBandTimeEditViewModel viewModel)
		{
			try
			{
				var timeBandTime = await _timeBandTimeService.Get(viewModel.Id).FirstOrDefaultAsync();
				timeBandTime.EditDataModel(viewModel);

				var result = await _timeBandTimeService.Update(timeBandTime);

				return JsonResponse(result, ActionType.Edit, timeBandTime.Id);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}