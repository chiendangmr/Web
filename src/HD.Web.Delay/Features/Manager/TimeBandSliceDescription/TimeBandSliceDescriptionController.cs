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

namespace HD.TVAD.Web.Features.Manager.TimeBandSliceDescriptions
{
	[Area("Manager")]
	[Authorize]
	public class TimeBandSliceDescriptionController : TVADController
	{
		private ITimeBandSliceDescriptionService _timeBandSliceDescriptionService;
		private ITimeBandSliceService _timeBandSliceService;
		private ITimeBandService _timeBandService;
		public TimeBandSliceDescriptionController(
			ITimeBandSliceDescriptionService timeBandSliceDescriptionService,
			ITimeBandSliceService timeBandSliceService,
			ITimeBandService timeBandService)
		{
			_timeBandSliceDescriptionService = timeBandSliceDescriptionService;
			_timeBandSliceService = timeBandSliceService;
			_timeBandService = timeBandService;
		}
		[HttpGet]
		public async Task<IActionResult> Index(Guid id)
		{
			var timebandSlice = await _timeBandSliceService.Get(id).FirstOrDefaultAsync();

			var timeband = await _timeBandService.Get(timebandSlice.TimeBandId).FirstOrDefaultAsync();

			var model = new TimeBandSliceDescriptionIndexViewModel()
			{
				TimeBandSliceId = id,
				TimeBandName = timeband.TimeBandName,
				TimeBandSliceName = timebandSlice.Name,
			};
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllByTimeBandSliceId(DataSourceRequest request, Guid timeBandSliceId)
		{
			try
			{
				var timeBandSlice = await _timeBandSliceService.Get(timeBandSliceId).FirstOrDefaultAsync();
				if (timeBandSlice != null)
				{
					var result = timeBandSlice.TimeBandSliceDescriptions
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
			var model = new TimeBandSliceDescriptionCreateViewModel()
			{
				TimeBandSliceId = id,
				StartDate = DateTime.Today
			};
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> CreateAsync(TimeBandSliceDescriptionCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();
				try
				{
					var result = await _timeBandSliceDescriptionService.Create(dataModel);

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
				var result = await _timeBandSliceDescriptionService.Get(id).FirstOrDefaultAsync();

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
				var resultGet = await _timeBandSliceDescriptionService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _timeBandSliceDescriptionService.Delete(resultGet);

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
				var result = await _timeBandSliceDescriptionService.Get(id).FirstOrDefaultAsync();
				var model = result.ToViewModel();

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAsync(TimeBandSliceDescriptionEditViewModel viewModel)
		{
			try
			{
				var timeBandSliceDescription = await _timeBandSliceDescriptionService.Get(viewModel.Id).FirstOrDefaultAsync();
				timeBandSliceDescription.EditDataModel(viewModel);

				var result = await _timeBandSliceDescriptionService.Update(timeBandSliceDescription);

				return JsonResponse(result, ActionType.Edit, timeBandSliceDescription.Id);
			}
			catch (Exception)
			{
				throw;
			}
		}


	}
}