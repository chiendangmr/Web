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
using HD.TVAD.Web.Infrastructure;
using HD.TVAD.Web.StartData;

namespace HD.TVAD.Web.Features.Manager.PositionRates
{
	[Area("Manager")]
	[Authorize]
	[RequiresPermission(UserPermissions.Accounting_SetPositionRate)]
	public class PositionRateController : TVADController
	{
		private IPositionRateService _positionRateService;
		public PositionRateController(IPositionRateService positionRateService) {
			_positionRateService = positionRateService;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult IndexPositionRateTimeBand()
		{
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> GetAllPositionRateAsync([DataSourceRequest]DataSourceRequest request)
		{
			try
			{
				var positionRates = _positionRateService.GetAll()
					.ToViewModel();
				var result = await positionRates.ToDataSourceResultAsync(request);
				return Json(result);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpGet]
		public async Task<IActionResult> GetAllPositionRateTimeBandAsync([DataSourceRequest]DataSourceRequest request)
		{
			try
			{
				var positionRates = _positionRateService.GetAllIncludeTimeBand()
					.ToViewModel();
				var result = await positionRates.ToDataSourceResultAsync(request);
				return Json(result);
			}
			catch (Exception)
			{

				throw;
			}
		}
		[HttpGet]
        public IActionResult Create()
        {
			var model = new PositionRateCreateViewModel()
			{
				StartDate = DateTime.Today,
			};

			return View(model);
        }

		[HttpGet]
		public IActionResult CreatePositionRateTimeBand()
		{
			var model = new PositionRateCreateViewModel()
			{
				StartDate = DateTime.Today,
			};

			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> CreateAsync(PositionRateCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();
				try
				{
					if (await _positionRateService.CheckExistAsync(dataModel))
					{
						throw new Exception($"Exist start date {dataModel.StartDate.ToString("dd/MM/yyyy")}");
					}

					var result = await _positionRateService.Create(dataModel);

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
				var result = await _positionRateService.Get(id).FirstOrDefaultAsync();

				var model = new DeleteViewModel()
				{
					Id = id,
					Name = result.Rate.ToString()
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
				var resultGet = await _positionRateService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _positionRateService.Delete(resultGet);


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
				var result = await _positionRateService.Get(id).FirstOrDefaultAsync();

				var model = result.ToViewModel();

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAsync(PositionRateEditViewModel viewModel)
		{
			//TODO: set befor model binding by attibute action
			System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Globalization.CultureInfo.CurrentUICulture.Clone();
			customCulture.NumberFormat.NumberDecimalSeparator = ".";
			System.Globalization.CultureInfo.CurrentCulture = customCulture;
			if (ModelState.IsValid)
			{
				try
				{
					var positionRate = await _positionRateService.Get(viewModel.Id).FirstOrDefaultAsync();

					positionRate.EditDataModel(viewModel);

					var resultUpdate = await _positionRateService.Update(positionRate);

					return JsonResponse(resultUpdate, ActionType.Edit, positionRate.Id);
				}
				catch (Exception)
				{
					throw;
				}
			}
			else
				return JsonResponse(StatusType.ERROR, ModelState);
		}
	}
}