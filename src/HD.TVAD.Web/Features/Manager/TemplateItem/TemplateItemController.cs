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

namespace HD.TVAD.Web.Features.Manager.TemplateItems
{
	[Area("Manager")]
	[Authorize]
	public class TemplateItemController : TVADController
	{
		private ITemplateItemService _templateItemService;
		private ITemplateService _templateService;
		public TemplateItemController(
			ITemplateItemService templateItemService,
			ITemplateService templateService) {
			_templateItemService = templateItemService;
			_templateService = templateService;
		}
		[HttpGet]
		public async Task<IActionResult> IndexAsync(Guid id)
		{
			var template = await _templateService.Get(id).FirstOrDefaultAsync();

			var model = new TemplateItemIndexViewModel()
			{
				TemplateId = id,
				TemplateName = template.Name,
			};
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync(DataSourceRequest request,Guid templateId)
		{

			try
			{
				var template = await _templateService.Get(templateId).FirstOrDefaultAsync();
				if (template != null)
				{
					var dataSourceResult = await template.TemplateItems
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
        public IActionResult Create(Guid id)
        {
			var model = new TemplateItemCreateViewModel()
			{
				TemplateId = id,
			};
            return View(model);
        }

        [HttpPost]
		public async Task<IActionResult> CreateAsync(TemplateItemCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();
				try
				{
					var result = await _templateItemService.Create(dataModel);
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
				var result = await _templateItemService.Get(id).FirstOrDefaultAsync();

				var model = new DeleteViewModel()
				{
					Id = id,
					Name = result.Name,
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
				var resultGet = await _templateItemService.Get(viewModel.Id).FirstOrDefaultAsync();
				var resultDelete = await _templateItemService.Delete(resultGet);

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
				var templateItem = await _templateItemService.Get(id).FirstOrDefaultAsync();
				var model = templateItem.ToViewModel();

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAsync(TemplateItemEditViewModel viewModel)
		{
			try
			{
				var templateItem = await _templateItemService.Get(viewModel.Id).FirstOrDefaultAsync();

				templateItem.Name = viewModel.Name;
				templateItem.Index = viewModel.Index;
				

				var result = await _templateItemService.Update(templateItem);

				return JsonResponse(result, ActionType.Edit, templateItem.Id);
			}
			catch (Exception)
			{
				throw;
			}
		}

	}
}