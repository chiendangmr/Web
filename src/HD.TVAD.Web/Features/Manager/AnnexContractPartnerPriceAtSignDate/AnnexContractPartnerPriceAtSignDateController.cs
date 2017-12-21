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

namespace HD.TVAD.Web.Features.Manager.AnnexContractPartnerPriceAtSignDates
{
	[Area("Manager")]
	[Authorize]
	[RequiresPermission(UserPermissions.ManagerSystem_SpecialPriceForContract_BySignDate)]
	public class AnnexContractPartnerPriceAtSignDateController : TVADController
	{
		private IAnnexContractPartnerPriceAtSignDateService _annexContractPartnerPriceAtSignDateService;
		public AnnexContractPartnerPriceAtSignDateController(IAnnexContractPartnerPriceAtSignDateService annexContractPartnerPriceAtSignDateService) {

			_annexContractPartnerPriceAtSignDateService = annexContractPartnerPriceAtSignDateService;
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
				var items = _annexContractPartnerPriceAtSignDateService.GetAll()
					.ToViewModel();

				var dataSourceResult = await items.ToDataSourceResultAsync(request);

				return Json(dataSourceResult);

			}
			catch (Exception)
			{
				throw;
			}
		}

        [HttpGet]
        public IActionResult Create()
        {
			var model = new AnnexContractPartnerPriceAtSignDateCreateViewModel() {
				StartDate = DateTime.Today,
			};

			return View(model);
        }

        [HttpPost]
		public async Task<IActionResult> CreateAsync(AnnexContractPartnerPriceAtSignDateCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();

				try
				{
					var result = await _annexContractPartnerPriceAtSignDateService.Create(dataModel);

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
				var result = await _annexContractPartnerPriceAtSignDateService.Get(id).FirstOrDefaultAsync();

				var model = new DeleteViewModel()
				{
					Id = id,
					Name = $"{result.AnnexContract.AnnexContract.Code} at {result.AnnexContract.SignDate.ToString()}",
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
				var resultGet = await _annexContractPartnerPriceAtSignDateService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _annexContractPartnerPriceAtSignDateService.Delete(resultGet);

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
				var result = await _annexContractPartnerPriceAtSignDateService.Get(id).FirstOrDefaultAsync();

				var model = result.ToViewModel();

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpPost]
		public async Task<IActionResult> EditAsync(AnnexContractPartnerPriceAtSignDateEditViewModel viewModel)
		{
			try
			{
				var annexContractPartnerPriceAtSignDate = await _annexContractPartnerPriceAtSignDateService.Get(viewModel.Id).FirstOrDefaultAsync();
				annexContractPartnerPriceAtSignDate.EditDataModel(viewModel);

				var result = await _annexContractPartnerPriceAtSignDateService.Update(annexContractPartnerPriceAtSignDate);

				return JsonResponse(result, ActionType.Edit, annexContractPartnerPriceAtSignDate.Id);
			}
			catch (Exception)
			{
				throw;
			}
		}

	}
}