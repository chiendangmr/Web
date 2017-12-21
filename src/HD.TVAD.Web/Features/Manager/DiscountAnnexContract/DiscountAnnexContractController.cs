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

namespace HD.TVAD.Web.Features.Manager.DiscountAnnexContracts
{
	//[Area("Manager")]
	[Authorize]
	[RequiresPermission(UserPermissions.Accounting_AnnexContractDiscount)]
	public class DiscountAnnexContractController : TVADController
	{
		private readonly IDiscountAnnexContractService _discountAnnexContractService;
		private readonly IAnnexContractService _annexContractService;
		private readonly IAnnexContractPartnerService _annexContractPartnerService;
		public DiscountAnnexContractController(IDiscountAnnexContractService discountAnnexContractService,
			 IAnnexContractService annexContractService,
			 IAnnexContractPartnerService annexContractPartnerService) {
			_discountAnnexContractService = discountAnnexContractService;
			_annexContractService = annexContractService;
			_annexContractPartnerService = annexContractPartnerService;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync([DataSourceRequest]DataSourceRequest request, string annexContractCode)
		{
			try
			{
				if (_annexContractPartnerService.Exist(annexContractCode))
				{
					var annexContract = await _annexContractPartnerService.GetByCodeAsync(annexContractCode);
					var positionRates = _discountAnnexContractService.GetAll()
						.Where(d => d.AnnexContractId == annexContract.Id)
						.ToViewModel();
					var result = await positionRates.ToDataSourceResultAsync(request);
					return Json(result);
				}
				else
					//	return JsonResponse(StatusType.ERROR, $"Not exist code: {annexContractCode}");
					return Ok();

			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpGet("[area]/[controller]/[action]/{annexContractCode?}")] // Matches '/Products/Create/{annexContractCode}'
		public IActionResult Create(string annexContractCode)
        {
			var model = new DiscountAnnexContractCreateViewModel() {
				AnnexContractCode = annexContractCode,
				StartDate = DateTime.Today,
			};
            return View(model);
        }

        [HttpPost]
		public async Task<IActionResult> CreateAsync(DiscountAnnexContractCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var annexContract = await _annexContractService.GetByCodeAsync(viewModel.AnnexContractCode);

					if (annexContract != null)
					{
						var dataModel = viewModel.ToDataModel(annexContract.Id);

						var result = await _discountAnnexContractService.Create(dataModel);

						return JsonResponse(result, ActionType.Create, dataModel.Id);

					}
					else
					{
						return JsonResponse(StatusType.ERROR, $"Not exist code: {viewModel.AnnexContractCode}");
					}
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
				var result = await _discountAnnexContractService.Get(id).FirstOrDefaultAsync();

				var model = new DiscountAnnexContractDeleteViewModel()
				{
					Id = id,
					AnnexContractCode = result.AnnexContract.AnnexContract.Code,
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
				var resultGet = await _discountAnnexContractService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _discountAnnexContractService.Delete(resultGet);

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
				var result = await _discountAnnexContractService.Get(id).FirstOrDefaultAsync();
				var model = result.ToViewModel();

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpPost]
		public async Task<IActionResult> EditAsync(DiscountAnnexContractEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				//TODO: set befor model binding by attibute action
				System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Globalization.CultureInfo.CurrentUICulture.Clone();
				customCulture.NumberFormat.NumberDecimalSeparator = ".";
				System.Globalization.CultureInfo.CurrentCulture = customCulture;
				try
				{
					var rate = Decimal.Parse(viewModel.Rate);

					var discountCustomer = await _discountAnnexContractService.Get(viewModel.Id).FirstOrDefaultAsync();
					discountCustomer.EditDataModel(viewModel);

					var result = await _discountAnnexContractService.Update(discountCustomer);

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