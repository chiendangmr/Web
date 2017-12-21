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

namespace HD.TVAD.Web.Features.Manager.RetailCustomers
{
	[Area("Manager")]
	[Authorize]
	public class RetailCustomerController : TVADController
	{
		private readonly IRetailCustomerService _retailCustomerService;
		private readonly ICustomerService _customerService;
		public RetailCustomerController(
			 IRetailCustomerService retailCustomerService,
			ICustomerService customerService)
		{
			_retailCustomerService = retailCustomerService;
			_customerService = customerService;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync([DataSourceRequest]DataSourceRequest request)
		{
			var customers = _retailCustomerService.GetAll()
				.ToViewModel();
			var dataSource = await customers.ToDataSourceResultAsync(request);
			return Json(dataSource);
		}

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

		[HttpGet]
		public IActionResult CreateCustomer()
		{

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync(RetailCustomerCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();

				try
				{
					var result = await _retailCustomerService.Create(dataModel); ;

					return JsonResponse(result, ActionType.Create, dataModel.Id);
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
		[HttpPost]
		public async Task<IActionResult> CreateCustomerAsync(RetailCustomerCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();

				try
				{
					var result = await _retailCustomerService.Create(dataModel);

					if (result > 0)
						return Redirect("/Manager/RetailContract/CreateContract/" + dataModel.Id.ToString());
					else
						return View(viewModel);
				}
				catch (Exception)
				{
					throw;
				}
			}
			else
			{
				return View(viewModel);
			}
		}

		[HttpGet]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			try
			{
				var result = await _retailCustomerService.Get(id).FirstOrDefaultAsync();

				var viewModel = new DeleteViewModel()
				{
					Id = result.Id,
					Name = result.Customer.Name
				};
				return View(viewModel);
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
				if (await _customerService.HasApprovedSpotAsync(viewModel.Id))
				{
					throw new Exception("This customer has approved spots!");
				}
				var resultGet = await _customerService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _customerService.Delete(resultGet);

				return JsonResponse(resultDelete, ActionType.Delete);
			}
			catch (Exception ex)
			{
				return JsonResponse(StatusType.ERROR, ex.Message);
			}
		}
		[HttpGet]
		public async Task<IActionResult> EditAsync(Guid id)
		{
			try
			{
				var result = await _retailCustomerService.Get(id).FirstOrDefaultAsync();

				var model = result.ToViewModel();

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAsync(RetailCustomerEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var customer = await _retailCustomerService.Get(viewModel.Id).FirstOrDefaultAsync();
					customer.EditDataModel(viewModel);

					var result = await _retailCustomerService.Update(customer);

					return JsonResponse(result, ActionType.Edit, customer.Id);
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
	}
}