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

namespace HD.TVAD.Web.Features.Manager.Registers
{
	[Area("MAM")]
	[Authorize]
	public class RegisterController : TVADController
	{
		private IRegisterService _registerService;
		public RegisterController(IRegisterService registerService) {

			_registerService = registerService;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync([DataSourceRequest]DataSourceRequest request)
		{
			var registers = _registerService.GetAll()
				.ToViewModel();
			var dataSourceResult = await registers.ToDataSourceResultAsync(request);

			return Json(dataSourceResult);
		}

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
		public async Task<IActionResult> CreateAsync(RegisterCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();
				try
				{
					var result = await _registerService.Create(dataModel);

					return JsonResponse(result, ActionType.Create, dataModel.Id);
				}
				catch (Exception ex)
				{

					return Json(new JsonResponse("ERROR", ex.Message));
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
				var result = await _registerService.Get(id).FirstOrDefaultAsync();
				var viewModel = result.ToDeleteViewModel();

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
				var register = await _registerService.Get(viewModel.Id).FirstOrDefaultAsync();
				var result = await _registerService.Delete(register);

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
				var register = await _registerService.Get(id).FirstOrDefaultAsync();
				var viewModel = register.ToViewModel();

				return View(viewModel);
			}
			catch (Exception)
			{

				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAsync(RegisterEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var register = await _registerService.Get(viewModel.Id).FirstOrDefaultAsync();
					register.EditDataModel(viewModel);

					var result = await _registerService.Update(register);

					return JsonResponse(result, ActionType.Edit, register.Id);
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