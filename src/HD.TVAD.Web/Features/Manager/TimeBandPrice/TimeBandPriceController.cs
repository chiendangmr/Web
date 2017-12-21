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

namespace HD.TVAD.Web.Features.Manager.TimeBandPrices
{
	[Area("Manager")]
	[Authorize]
	[RequiresPermission(UserPermissions.ManagerSystem_TimeBandPrice)]
	public class TimeBandPriceController : TVADController
	{
		private ITimeBandPriceService _timeBandPriceService;
		public TimeBandPriceController(ITimeBandPriceService timeBandPriceService) {
			_timeBandPriceService = timeBandPriceService;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync([DataSourceRequest]DataSourceRequest request,Guid timeBandId)
		{
			try
			{
				if (!timeBandId.Equals(Guid.Empty))
				{
					var timebandPrices = _timeBandPriceService.GetAll()
						.Where(t => t.TimeBandId == timeBandId)
						.ToViewModel();
					var result = await timebandPrices.ToDataSourceResultAsync(request);
					return Json(result);
				}
				else {
					var timebandPrices = _timeBandPriceService.GetAll()
						.ToViewModel();
					var result = await timebandPrices.ToDataSourceResultAsync(request);
					return Json(result);
				}

			}
			catch (Exception)
			{
				throw;
			}
		}

        [HttpGet]
        public IActionResult Create(Guid id)
        {
			var model = new TimeBandPriceCreateViewModel() {
				StartDate = DateTime.Today,
				TimeBandId = id,
			};
			return View(model);
        }

        [HttpPost]
		public async Task<IActionResult> CreateAsync(TimeBandPriceCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();
				try
				{
					var result = await _timeBandPriceService.Create(dataModel);

					return JsonResponse(result, ActionType.Create, dataModel.Id);
				}
				catch (Exception)
				{
					throw;
				}	
			}
			else
				return JsonResponse(StatusType.ERROR, "Input not valid, try again please!");
		}
		[HttpGet]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			try
			{
				var result = await _timeBandPriceService.Get(id).FirstOrDefaultAsync();

				var model = new TimeBandPriceDeleteViewModel()
				{
					Id = id,
					TimeBandId = result.TimeBandId,
					Name = $"{result.TimeBand.TimeBandBase.Name} {result.SpotBlock.Duration.ToString()} {result.Price.ToString()}",
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
				var resultGet = await _timeBandPriceService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _timeBandPriceService.Delete(resultGet);

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
				var result = await _timeBandPriceService.Get(id).FirstOrDefaultAsync();

				var model = result.ToViewModel();

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAsync(TimeBandPriceEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var timeBandPrice = await _timeBandPriceService.Get(viewModel.Id).FirstOrDefaultAsync();

					timeBandPrice.EditDataModel(viewModel);

					var resultUpdate = await _timeBandPriceService.Update(timeBandPrice);


					return JsonResponse(resultUpdate, ActionType.Edit, timeBandPrice.Id);
				}
				catch (Exception)
				{
					throw;
				}

			}
			else
				return JsonResponse(StatusType.ERROR, "Input not valid, try again please!");
		}
	}
}