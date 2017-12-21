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

namespace HD.TVAD.Web.Features.Manager.Templates
{
	[Area("Manager")]
	[Authorize]
	public class TemplateController : TVADController
	{
		private ITemplateService _templateService;
		public TemplateController(ITemplateService templateService) {

			_templateService = templateService;
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
				var templates = _templateService.GetAll()
					.ToViewModel();
				var dataSourceResult = await templates.ToDataSourceResultAsync(request);

				return Json(dataSourceResult);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpGet]
		public async Task<IActionResult> GetTemplateAsync(Guid timeBandId)
		{
			var template = await _templateService.GetAll()
				.Where(s => s.TimeBandBaseScheduleTemplates
				.Any(t => (t.TimeBandBaseId == timeBandId) && (t.StartDate <= DateTime.Today)))
				.FirstOrDefaultAsync();			

			if (template != null)
			{
				var model = new TemplateForTimeBandViewModel()
				{
					Id = template.Id,
					Name = template.Name,
					TemplateItems = new List<TemplateItemViewModel>()
				};
				if (template.TemplateItems != null)
				{
					foreach (var item in template.TemplateItems.OrderBy(s => s.Index))
					{
						model.TemplateItems.Add(new TemplateItemViewModel() {
							Id = item.Id,
							Index = item.Index,
							Name = item.Name,
							TemplateId = item.TemplateId
						});
					}
				}
				return Json(model);
			}
			return Json(0);
		}
		[HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
		public async Task<IActionResult> CreateAsync(TemplateCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();
				try
				{
					var result = await _templateService.Create(dataModel);
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
				var result = await _templateService.Get(id).FirstOrDefaultAsync();

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
				var resultGet = await _templateService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _templateService.Delete(resultGet);

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
				var result = await _templateService.Get(id).FirstOrDefaultAsync();

				var model = result.ToViewModel();
				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAsync(TemplateEditViewModel viewModel)
		{
			try
			{
				var template = await _templateService.Get(viewModel.Id).FirstOrDefaultAsync();
				template.EditDataModel(viewModel);

				var result = await _templateService.Update(template);

				return JsonResponse(result, ActionType.Edit, template.Id);
			}
			catch (Exception)
			{
				throw;
			}
		}


	}
}