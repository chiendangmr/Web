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

namespace HD.TVAD.Web.Features.Manager.TemplateItemAssetTypeRequests
{
	[Area("Manager")]
	[Authorize]
	public class TemplateItemAssetTypeRequestController : TVADController
	{
		private ITemplateItemService _templateItemService;
		private ITemplateItemAssetTypeRequestService _templateItemAssetTypeRequestService;
		public TemplateItemAssetTypeRequestController(
			ITemplateItemService templateItemService,
			ITemplateItemAssetTypeRequestService templateItemAssetTypeRequestService) {
			_templateItemService = templateItemService;
			_templateItemAssetTypeRequestService = templateItemAssetTypeRequestService;
		}
		[HttpGet]
		public async Task<IActionResult> IndexAsync(Guid id)
		{
			var templateItem = await _templateItemService.Get(id).FirstOrDefaultAsync();

			var model = new TemplateItemAssetTypeRequestIndexViewModel()
			{
				TemplateItemId = id,
				TemplateItemName = templateItem.Name,
				TemplateName = templateItem.Template.Name,
			};
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync(DataSourceRequest request,Guid templateItemId)
		{
			try
			{
				var templateItem = await _templateItemService.Get(templateItemId).FirstOrDefaultAsync();
				if (templateItem != null)
				{
					var dataSourceResult = await templateItem.TemplateItemAssetTypeRequests
						.AsQueryable()
						.ToViewModel()
						.ToDataSourceResultAsync(request);

					return Json(dataSourceResult);
				}
				else
				{
					throw new NullReferenceException();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}


		[HttpGet]
		public async Task<IActionResult> GetTemplateItemTypeAssetAsync(Guid templateItemId)
		{
			var types = await _templateItemAssetTypeRequestService
				.GetAll()
				.Where(a => a.TemplateItemId == templateItemId)
				.ToListAsync();

			var model = new List<TemplateItemAssetTypeRequestViewModel>();
			if (types.Count > 0)
			{
				foreach (var item in types)
				{
					model.Add(item.ToViewModel());
				}
				return Json(model);
			}
			return Json(0);
		}
		[HttpGet]
        public IActionResult Create(Guid id)
        {
			var model = new TemplateItemAssetTypeRequestCreateViewModel()
			{
				TemplateItemId = id,
			};
            return View(model);
        }

        [HttpPost]
		public async Task<IActionResult> CreateAsync(TemplateItemAssetTypeRequestCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();
				try
				{
					var result = await _templateItemAssetTypeRequestService.Create(dataModel);
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
				var result = await _templateItemAssetTypeRequestService.Get(id).FirstOrDefaultAsync();

				var model = new DeleteViewModel()
				{
					Id = id,
					Name = result.AssetType.Name,
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
				var resultGet = await _templateItemAssetTypeRequestService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _templateItemAssetTypeRequestService.Delete(resultGet);

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
				var result = await _templateItemAssetTypeRequestService.Get(id).FirstOrDefaultAsync();
				var model = result.ToViewModel();

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAsync(TemplateItemAssetTypeRequestEditViewModel viewModel)
		{
			try
			{
				var templateItemAssetTypeRequest = await _templateItemAssetTypeRequestService.Get(viewModel.Id).FirstOrDefaultAsync();
				templateItemAssetTypeRequest.EditDataModel(viewModel);

				var result = await _templateItemAssetTypeRequestService.Update(templateItemAssetTypeRequest);
				return JsonResponse(result, ActionType.Edit, templateItemAssetTypeRequest.Id);
			}
			catch (Exception)
			{
				throw;
			}
		}

	}
}