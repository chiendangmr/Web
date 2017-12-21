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

namespace HD.TVAD.Web.Features.Manager.TimeBandSliceForTypes
{
	[Area("Manager")]
	[Authorize]
	public class TimeBandSliceForTypeController : TVADController
	{
		private ITimeBandSliceForTypeService _timeBandSliceForTypeService;
		public TimeBandSliceForTypeController(ITimeBandSliceForTypeService timeBandSliceForTypeService) {
			_timeBandSliceForTypeService = timeBandSliceForTypeService;
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
				var timeBandSliceForTypes = _timeBandSliceForTypeService.GetAll()
					.ToViewModel();
				var result = await timeBandSliceForTypes.ToDataSourceResultAsync(request);
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
			var model = new TimeBandSliceForTypeCreateViewModel() {
				StartDate = DateTime.Today,
			};

			return View(model);
        }

        [HttpPost]
		public async Task<IActionResult> CreateAsync(TimeBandSliceForTypeCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();
				try
				{
					var result = await _timeBandSliceForTypeService.Create(dataModel);

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
				var result = await _timeBandSliceForTypeService.Get(id).FirstOrDefaultAsync();

				var model = new DeleteViewModel()
				{
					Id = id,
					Name = "",
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
				var resultGet = await _timeBandSliceForTypeService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _timeBandSliceForTypeService.Delete(resultGet);

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
				var timeBandSliceForType = await _timeBandSliceForTypeService.Get(id).FirstOrDefaultAsync();

				var model = timeBandSliceForType.ToViewModel();

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAsync(TimeBandSliceForTypeEditViewModel viewModel)
		{
			try
			{
				var timeBandSliceForType = await _timeBandSliceForTypeService.Get(viewModel.Id).FirstOrDefaultAsync();
				timeBandSliceForType.EditDataModel(viewModel);

				var result = await _timeBandSliceForTypeService.Update(timeBandSliceForType);

				return JsonResponse(result, ActionType.Edit, timeBandSliceForType.Id);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}