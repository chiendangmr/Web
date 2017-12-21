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

namespace HD.TVAD.Web.Features.Manager.DiscountCustomers
{
	[Area("Manager")]
	[Authorize]
	[RequiresPermission(UserPermissions.Accounting_CustomerDiscount)]
	public class DiscountCustomerController : TVADController
	{
		private IDiscountCustomerService _discountCustomerService;
		public DiscountCustomerController(IDiscountCustomerService discountCustomerService) {
			_discountCustomerService = discountCustomerService;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> GetAllDiscountCustomerAsync([DataSourceRequest]DataSourceRequest request, Guid customerId)
		{
			try
			{
				if (!customerId.Equals(Guid.Empty))
				{
					var discountCustomers = _discountCustomerService.GetAll()
						.Where(d => d.CustomerId == customerId)
						.OrderBy(d => d.StartDate)
						.ToViewModel();
					var result = await discountCustomers.ToDataSourceResultAsync(request);
					return Json(result);
				}
				else
					return Ok();

			}
			catch (Exception)
			{
				throw;
			}
		}
		
		[HttpGet]
		public async Task<IActionResult> Create(Guid id)
		{
			var model = new DiscountCustomerCreateViewModel(){
				CustomerId = id,
				StartDate = DateTime.Today,
			};

            return View(model);
        }

        [HttpPost]
		public async Task<IActionResult> CreateAsync(DiscountCustomerCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();				
				try
				{
					var result = await _discountCustomerService.Create(dataModel);
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
				var result = await _discountCustomerService.Get(id).FirstOrDefaultAsync();

				var model = new DiscountCustomerDeleteViewModel()
				{
					Id = id,
					CustomerId = result.CustomerId,
					Name = result.Description
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
				var resultGet = await _discountCustomerService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _discountCustomerService.Delete(resultGet);

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
				var result = await _discountCustomerService.Get(id).FirstOrDefaultAsync();

				var model = result.ToViewModel();

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpPost]
		public async Task<IActionResult> EditAsync(DiscountCustomerEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				//TODO: set befor model binding by attibute action
				System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Globalization.CultureInfo.CurrentUICulture.Clone();
				customCulture.NumberFormat.NumberDecimalSeparator = ".";
				System.Globalization.CultureInfo.CurrentCulture = customCulture;
				try
				{
					var discountCustomer = await _discountCustomerService.Get(viewModel.Id).FirstOrDefaultAsync();

					discountCustomer.EditDataModel(viewModel);

					var result = await _discountCustomerService.Update(discountCustomer);

					return JsonResponse(result, ActionType.Edit, discountCustomer.Id);
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