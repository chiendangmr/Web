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

namespace HD.TVAD.Web.Features.Manager.RetailPrices
{
	[Area("Manager")]
	[Authorize]
	[RequiresPermission(UserPermissions.ManagerSystem_TimeBandPrice)]
	public class RetailPriceController : TVADController
	{
		private IRetailPriceService _retailPriceService;
		public RetailPriceController(IRetailPriceService retailPriceService) {
			_retailPriceService = retailPriceService;
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
				var retailPrices = _retailPriceService.GetAll()
					.ToViewModel();
				var result = await retailPrices.ToDataSourceResultAsync(request);
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
			var model = new RetailPriceCreateViewModel() {
				StartDate = DateTime.Today,
			};

			return View(model);
        }

        [HttpPost]
		public async Task<IActionResult> CreateAsync(RetailPriceCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();
				try
				{
					var result = await _retailPriceService.Create(dataModel);

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
				var result = await _retailPriceService.Get(id).FirstOrDefaultAsync();

				var model = new DeleteViewModel()
				{
					Id = id,
					Name = $"{result.RetailType.TypeDetail.Name} {result.Price.ToString()}",
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
				var resultGet = await _retailPriceService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _retailPriceService.Delete(resultGet);

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
				var retailPrice = await _retailPriceService.Get(id).FirstOrDefaultAsync();
				var model = retailPrice.ToViewModel();

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAsync(RetailPriceEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var retailPrice = await _retailPriceService.Get(viewModel.Id).FirstOrDefaultAsync();

					retailPrice.EditDataModel(viewModel);

					var result = await _retailPriceService.Update(retailPrice);

					return JsonResponse(result, ActionType.Edit, retailPrice.Id);
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