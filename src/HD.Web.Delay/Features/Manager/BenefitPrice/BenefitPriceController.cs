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

namespace HD.TVAD.Web.Features.Manager.BenefitPrices
{
	[Area("Manager")]
	[Authorize]
	public class BenefitPriceController : TVADController
	{
		private IBenefitPriceService _BenefitPriceService;
		public BenefitPriceController(IBenefitPriceService BenefitPriceService) {
			_BenefitPriceService = BenefitPriceService;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync([DataSourceRequest]DataSourceRequest request)
		{
			try
			{
				var timebandPrices = _BenefitPriceService.GetAll()
					.ToViewModel();
				var result = await timebandPrices.ToDataSourceResultAsync(request);
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
			var model = new BenefitPriceCreateViewModel() {
				StartDate = DateTime.Today,
			};

			return View(model);
        }

        [HttpPost]
		public async Task<IActionResult> CreateAsync(BenefitPriceCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();				
				try
				{
					var result = await _BenefitPriceService.Create(dataModel);

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
				var result = await _BenefitPriceService.Get(id).FirstOrDefaultAsync();

				var model = new DeleteViewModel()
				{
					Id = id,
					Name = $"{result.BenefitType.Code} {result.Price.ToString()}",
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
				var resultGet = await _BenefitPriceService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _BenefitPriceService.Delete(resultGet);

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
				var benefitPrice = await _BenefitPriceService.Get(id).FirstOrDefaultAsync();

				var model = benefitPrice.ToViewModel();

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAsync(BenefitPriceEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var benefitPrice = await _BenefitPriceService.Get(viewModel.Id).FirstOrDefaultAsync();

					benefitPrice.EditDataModel(viewModel);

					var result = await _BenefitPriceService.Update(benefitPrice);

					return JsonResponse(result, ActionType.Edit, benefitPrice.Id);
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