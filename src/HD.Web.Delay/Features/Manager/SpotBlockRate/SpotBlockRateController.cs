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

namespace HD.TVAD.Web.Features.Manager.SpotBlockRates
{
	[Area("Manager")]
	[Authorize]
	public class SpotBlockRateController : TVADController
	{
		private ISpotBlockRateService _spotBlockRateService;
		public SpotBlockRateController(ISpotBlockRateService spotBlockRateService) {
			_spotBlockRateService = spotBlockRateService;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync(DataSourceRequest request)
		{
			try
			{
				var spotBlockRates = _spotBlockRateService.GetAll()
					.ToViewModel();
				var result = await spotBlockRates.ToDataSourceResultAsync(request);
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
			var viewModel = new SpotBlockRateCreateViewModel()
			{
				StartDate = DateTime.Today,
			};

			return View(viewModel);
        }

        [HttpPost]
		public async Task<IActionResult> CreateAsync(SpotBlockRateCreateViewModel viewModel)
		{
			System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Globalization.CultureInfo.CurrentUICulture.Clone();
			customCulture.NumberFormat.NumberDecimalSeparator = ".";
			System.Globalization.CultureInfo.CurrentCulture = customCulture;
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();
				try
				{
					var result = await _spotBlockRateService.Create(dataModel); //BUG: not create SpotBlockRate.Rate

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
				var result = await _spotBlockRateService.Get(id).FirstOrDefaultAsync();

				var model = new DeleteViewModel()
				{
					Id = id,
					Name = $"{result.SpotBlock.Duration.ToString()} {result.Rate.ToString()}",
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
				var resultGet = await _spotBlockRateService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _spotBlockRateService.Delete(resultGet);

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
				var result = await _spotBlockRateService.Get(id).FirstOrDefaultAsync();

				var model = result.ToViewModel();

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAsync(SpotBlockRateEditViewModel viewModel)
		{
			//TODO: set befor model binding by attibute action
			System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Globalization.CultureInfo.CurrentUICulture.Clone();
			customCulture.NumberFormat.NumberDecimalSeparator = ".";
			System.Globalization.CultureInfo.CurrentCulture = customCulture;
			if (ModelState.IsValid)
			{
				try
				{
					var spotBlockRate = await _spotBlockRateService.Get(viewModel.Id).FirstOrDefaultAsync();
					spotBlockRate.EditDataModel(viewModel);

					var resultUpdate = await _spotBlockRateService.Update(spotBlockRate);

					return JsonResponse(resultUpdate, ActionType.Edit, spotBlockRate.Id);
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