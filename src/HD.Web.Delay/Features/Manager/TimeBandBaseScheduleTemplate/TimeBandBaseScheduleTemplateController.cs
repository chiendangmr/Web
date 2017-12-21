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

namespace HD.TVAD.Web.Features.Manager.TimeBandBaseScheduleTemplates
{
	[Area("Manager")]
	[Authorize]
	public class TimeBandBaseScheduleTemplateController : TVADController
	{
		private ITimeBandBaseScheduleTemplateService _timeBandBaseScheduleTemplateService;
		private ITemplateService _templateService;
		public TimeBandBaseScheduleTemplateController(
			ITimeBandBaseScheduleTemplateService timeBandBaseScheduleTemplateService,
			ITemplateService templateService) {
			_timeBandBaseScheduleTemplateService = timeBandBaseScheduleTemplateService;
			_templateService = templateService;
		}
		[HttpGet]
		public async Task<IActionResult> IndexAsync(Guid id)
		{
			var template = await _templateService.Get(id).FirstOrDefaultAsync();

			var model = new TimeBandBaseScheduleTemplateIndexViewModel()
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
					var dataSourceResult = await template.TimeBandBaseScheduleTemplates
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
			var model = new TimeBandBaseScheduleTemplateCreateViewModel()
			{
				TemplateId = id,
				StartDate = DateTime.Today,
			};
            return View(model);
        }

        [HttpPost]
		public async Task<IActionResult> CreateAsync(TimeBandBaseScheduleTemplateCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();
				try
				{
					var result = await _timeBandBaseScheduleTemplateService.Create(dataModel);

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
				var result = await _timeBandBaseScheduleTemplateService.Get(id).FirstOrDefaultAsync();

				var model = new DeleteViewModel()
				{
					Id = id,
					Name = result.TimeBandBase.Name,
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
				var resultGet = await _timeBandBaseScheduleTemplateService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _timeBandBaseScheduleTemplateService.Delete(resultGet);

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
				var result = await _timeBandBaseScheduleTemplateService.Get(id).FirstOrDefaultAsync();
				var model = result.ToViewModel();

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAsync(TimeBandBaseScheduleTemplateEditViewModel viewModel)
		{
			try
			{
				var timeBandBaseScheduleTemplate = await _timeBandBaseScheduleTemplateService.Get(viewModel.Id).FirstOrDefaultAsync();
				timeBandBaseScheduleTemplate.EditDataModel(viewModel);

				var result = await _timeBandBaseScheduleTemplateService.Update(timeBandBaseScheduleTemplate);

				return JsonResponse(result, ActionType.Edit, timeBandBaseScheduleTemplate.Id);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}