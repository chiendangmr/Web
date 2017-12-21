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
using Microsoft.Extensions.Localization;

namespace HD.TVAD.Web.Features.Manager.RateSpotBlocks
{
	[Area("Manager")]
	[Authorize]
	//
	public class RateSpotBlockController : TVADController
	{
		private IRateSpotBlockService _rateSpotBlockService;
		private IStringLocalizer<RateSpotBlockController> _localizer;
		public RateSpotBlockController(IRateSpotBlockService rateSpotBlockService,
			IStringLocalizer<RateSpotBlockController> localizer) {
			_rateSpotBlockService = rateSpotBlockService;
			_localizer = localizer;
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
				var spotBlockRates = _rateSpotBlockService.GetAll()
					.ToViewModel(_localizer);
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

            return View();
        }

        [HttpPost]
		public async Task<IActionResult> CreateAsync(RateSpotBlockCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();				
				try
				{
					var result = await _rateSpotBlockService.Create(dataModel);

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
				var result = await _rateSpotBlockService.Get(id).FirstOrDefaultAsync();

				var model = new DeleteViewModel()
				{
					Id = id,
					Name = $"{result.TypeDetail.Name} {result.Rate.ToString()}",
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
				var resultGet = await _rateSpotBlockService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _rateSpotBlockService.Delete(resultGet);

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
				var result = await _rateSpotBlockService.Get(id).FirstOrDefaultAsync();

				var model = result.ToViewModel(_localizer);

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAsync(RateSpotBlockEditViewModel viewModel)
		{
			//TODO: set befor model binding by attibute action
			System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Globalization.CultureInfo.CurrentUICulture.Clone();
			customCulture.NumberFormat.NumberDecimalSeparator = ".";
			System.Globalization.CultureInfo.CurrentCulture = customCulture;
			if (ModelState.IsValid)
			{
				try
				{
					var rateSpotBlock = await _rateSpotBlockService.Get(viewModel.Id).FirstOrDefaultAsync();
					rateSpotBlock.EditDataModel(viewModel);

					var resultUpdate = await _rateSpotBlockService.Update(rateSpotBlock);

					return JsonResponse(resultUpdate, ActionType.Edit, rateSpotBlock.Id);
				}
				catch (Exception)
				{
					throw;
				}
			}
			else
			{
				return JsonResponse(StatusType.ERROR, "Input not valid, try again please!");
			}
		}
	}
}