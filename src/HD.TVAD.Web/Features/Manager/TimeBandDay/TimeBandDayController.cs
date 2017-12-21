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
using HD.TVAD.Web.Features.Manager.TimeBands;
using Microsoft.AspNetCore.Authorization;

namespace HD.TVAD.Web.Features.Manager.TimeBandDays
{
	[Area("Manager")]
	[Authorize]
	public class TimeBandDayController : TVADController
	{
		public ITimeBandDayService _timeBandDayService;
		private ITimeBandService _timeBandService;

		public TimeBandDayController(ITimeBandDayService timeBandDayService
			, ITimeBandService timeBandService) {

			_timeBandDayService = timeBandDayService;
			_timeBandService = timeBandService;
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
		public async Task<IActionResult> GetAllTimeBandDayByTimeBandId(DataSourceRequest request, Guid TimeBandId)
		{
			try
			{
				var timeBand = await _timeBandService.Get(TimeBandId).FirstOrDefaultAsync();
				if (timeBand != null)
				{
					var result = timeBand.TimeBandDays
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
			var model = new TimeBandDayCreateViewModel()
			{
				StartDate = DateTime.Today,
				TimeBandId = id,
			};
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> Create(TimeBandDayCreateViewModel formModel)
		{
			if (ModelState.IsValid)
			{
				var entity = formModel.ToDataModel();
				try
				{
					var result = await _timeBandDayService.Create(entity);

					return JsonResponse(result, ActionType.Create, entity.Id);
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
				var result = await _timeBandDayService.Get(id).FirstOrDefaultAsync();

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
				var resultGet = await _timeBandDayService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _timeBandDayService.Delete(resultGet);

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
				var result = await _timeBandDayService.Get(id).FirstOrDefaultAsync();
				var model = result.ToViewModel();

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAsync(TimeBandDayEditViewModel viewModel)
		{
			try
			{
				var timeBandDay = await _timeBandDayService.Get(viewModel.Id).FirstOrDefaultAsync();
				timeBandDay.EditDataModel(viewModel);

				var result = await _timeBandDayService.Update(timeBandDay);

				return JsonResponse(result, ActionType.Edit, timeBandDay.Id);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}