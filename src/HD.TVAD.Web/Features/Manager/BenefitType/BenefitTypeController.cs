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
using HD.TVAD.ApplicationCore.Entities.Price;

namespace HD.TVAD.Web.Features.Manager.BenefitTypes
{
	[Area("Manager")]
	[Authorize]
	public class BenefitTypeController : TVADController
	{
		private IBenefitTypeService _benefitTypeService;
		public BenefitTypeController(IBenefitTypeService benefitTypeService) {
			_benefitTypeService = benefitTypeService;
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
				var benefitTypes = _benefitTypeService.GetAll()
					.ToViewModel();
				var result = await benefitTypes.ToDataSourceResultAsync(request);

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
		public async Task<IActionResult> CreateAsync(BenefitTypeCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();
				try
				{
					var result = await _benefitTypeService.Create(dataModel);

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
				var result = await _benefitTypeService.Get(id).FirstOrDefaultAsync();

				var model = new DeleteViewModel()
				{
					Id = id,
					Name = result.TypeDetail.Name,
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
				var resultGet = await _benefitTypeService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _benefitTypeService.Delete(resultGet);

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
				var benefitType = await _benefitTypeService.Get(id).FirstOrDefaultAsync();

				var model = benefitType.ToViewModel();

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAsync(BenefitTypeEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var benefitType = await _benefitTypeService.Get(viewModel.Id).FirstOrDefaultAsync();
					benefitType.EditDataModel(viewModel);

					var result = await _benefitTypeService.Update(benefitType);

					return JsonResponse(result, ActionType.Edit, benefitType.Id);
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