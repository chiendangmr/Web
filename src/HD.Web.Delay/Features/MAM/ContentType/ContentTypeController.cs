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

namespace HD.TVAD.Web.Features.Manager.ContentTypes
{
	[Area("MAM")]
	[Authorize]
	public class ContentTypeController : TVADController
	{
		private IContentTypeService _assetTypeService;
		public ContentTypeController(IContentTypeService assetTypeService) {

			_assetTypeService = assetTypeService;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync([DataSourceRequest]DataSourceRequest request)
		{
			var assetTypes = _assetTypeService.GetAll()
				.ToViewModel();
			var dataSourceResult = await assetTypes.ToDataSourceResultAsync(request);

			return Json(dataSourceResult);
		}

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
		public async Task<IActionResult> CreateAsync(AssetTypeCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();
				try
				{
					var result = await _assetTypeService.Create(dataModel);

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
				var assetType = await _assetTypeService.Get(id).FirstOrDefaultAsync();
				var viewModel = assetType.ToDeleteViewModel();

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
				var assetType = await _assetTypeService.Get(viewModel.Id).FirstOrDefaultAsync();
				var result = await _assetTypeService.Delete(assetType);

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
				var assetType = await _assetTypeService.Get(id).FirstOrDefaultAsync();
				var viewModel = assetType.ToViewModel();

				return View(viewModel);
			}
			catch (Exception)
			{

				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAsync(AssetTypeEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var assetType = await _assetTypeService.Get(viewModel.Id).FirstOrDefaultAsync();
					assetType.EditDataModel(viewModel);

					var result = await _assetTypeService.Update(assetType);
					return JsonResponse(result, ActionType.Edit, assetType.Id);
				}
				catch (Exception)
				{
					throw;
				}
			}
			else
			{
				return JsonResponse(StatusType.ERROR, ModelState);
			}
		}
	}
}