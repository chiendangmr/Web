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

namespace HD.TVAD.Web.Features.Manager.DiscountSponsorPrograms
{
	[Area("Manager")]
	[Authorize]
	[RequiresPermission(UserPermissions.Accounting_SponsorProgramDiscount)]
	public class DiscountSponsorProgramController : TVADController
	{
		private IDiscountSponsorProgramService _discountSponsorProgramService;
		public DiscountSponsorProgramController(IDiscountSponsorProgramService discountSponsorProgramService) {
			_discountSponsorProgramService = discountSponsorProgramService;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult IndexPositionRateTimeBand()
		{
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> GetAllDiscountSponsorProgramAsync([DataSourceRequest]DataSourceRequest request,Guid sponsorProgramId)
		{
			try
			{
				if (!sponsorProgramId.Equals(Guid.Empty))
				{
					var discountSponsorPrograms = _discountSponsorProgramService.GetAll()
						.Where(s => s.ProgramId == sponsorProgramId)
						.ToViewModel();
					var result = await discountSponsorPrograms.ToDataSourceResultAsync(request);

					return Json(result);

				}
				else
					return Ok();
			}
			catch (Exception)
			{
				throw;
			}
		}
		
		[HttpGet]
        public IActionResult Create(Guid id)
        {
			var model = new DiscountSponsorProgramCreateViewModel() {
				StartDate = DateTime.Today,
				ProgramId = id,
			};
            return View(model);
        }

        [HttpPost]
		public async Task<IActionResult> CreateAsync(DiscountSponsorProgramCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();				
				try
				{
					var result = await _discountSponsorProgramService.Create(dataModel);

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
				var result = await _discountSponsorProgramService.Get(id).FirstOrDefaultAsync();

				var model = new DiscountSponsorProgramDeleteViewModel()
				{
					Id = id,
					ProgramId = result.ProgramId,
					Name = result.Description
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
				var resultGet = await _discountSponsorProgramService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _discountSponsorProgramService.Delete(resultGet);

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
				var result = await _discountSponsorProgramService.Get(id).FirstOrDefaultAsync();

				var model = Mapper.Map<DiscountSponsorProgramViewModel>(result);
				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpPost]
		public async Task<IActionResult> EditAsync(DiscountSponsorProgramEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				//TODO: set befor model binding by attibute action
				System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Globalization.CultureInfo.CurrentUICulture.Clone();
				customCulture.NumberFormat.NumberDecimalSeparator = ".";
				System.Globalization.CultureInfo.CurrentCulture = customCulture;
				try
				{
					var discountSponsorProgram = await _discountSponsorProgramService.Get(viewModel.Id).FirstOrDefaultAsync();
					discountSponsorProgram.EditDataModel(viewModel);

					var result = await _discountSponsorProgramService.Update(discountSponsorProgram);

					return JsonResponse(result, ActionType.Edit, discountSponsorProgram.Id);
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