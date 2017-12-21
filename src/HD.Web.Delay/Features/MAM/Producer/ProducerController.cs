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
using System.Data.SqlClient;

namespace HD.TVAD.Web.Features.Manager.Producers
{
	[Area("MAM")]
	[Authorize]
	public class ProducerController : TVADController
	{
		private IProducerService _producerService;
		public ProducerController(IProducerService producerService) {

			_producerService = producerService;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync([DataSourceRequest]DataSourceRequest request)
		{
			var producers = _producerService.GetAll()
				.ToViewModel();

			var dataSourceResult = await producers.ToDataSourceResultAsync(request);

			foreach (ProducerViewModel producer in dataSourceResult.Data)
			{
				if (!dataSourceResult.Data.Cast<ProducerViewModel>().Any(a => a.Id == producer.ParentId))
				{
					producer.ParentId = null;
				}
			}
			return Json(dataSourceResult);
		}

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
		public async Task<IActionResult> CreateAsync(ProducerCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();
				try
				{
					var result = await _producerService.Create(dataModel);

					return JsonResponse(result, ActionType.Create, dataModel.Id);
				}
				catch (Exception ex)
				{

					return Json(new JsonResponse("ERROR", ex.Message));
				}	
			}
			else
			{
				return Json(ModelState);
			}
		}

		[HttpGet]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			try
			{
				var producer = await _producerService.Get(id).FirstOrDefaultAsync();
				var viewModel = producer.ToDeleteViewModel();

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
				var producer = await _producerService.Get(viewModel.Id).FirstOrDefaultAsync();
				var result = await _producerService.Delete(producer);

				return JsonResponse(result, ActionType.Delete);
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
				var producer = await _producerService.Get(id).FirstOrDefaultAsync();
				var viewModel = producer.ToViewModel();

				return View(viewModel);
			}
			catch (Exception)
			{

				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAsync(ProducerEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var producer = await _producerService.Get(viewModel.Id).FirstOrDefaultAsync();
					producer.EditDataModel(viewModel);

					var result = await _producerService.Update(producer);

					return JsonResponse(result, ActionType.Edit, producer.Id);
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