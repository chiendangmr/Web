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
using HD.TVAD.Web.Features.Manager.AnnexContracts;
using HD.TVAD.ApplicationCore.Entities.Booking;
using HD.TVAD.Web.Features.Manager;
using HD.TVAD.Web.StartData;
using HD.TVAD.Web.Infrastructure;

namespace HD.TVAD.Web.Features.AnnexContracts
{
	[Area("AnnexContract")]
	[Authorize]
	public class NormalBookingController : TVADController
	{
		private readonly IAnnexContractPartnerService _annexContractPartnerService;
		private readonly IAnnexContractService _annexContractService;
		private readonly IGetTypeService _getTypeService;
		public NormalBookingController(
			IGetTypeService getTypeService,
			IAnnexContractPartnerService annexContractPartnerService,
			IAnnexContractService annexContractService) {
			_annexContractPartnerService = annexContractPartnerService;
			_getTypeService = getTypeService;
			_annexContractService = annexContractService;
		}
		[HttpGet]
		[RequiresPermission(UserPermissions.ImportData_NormalBooking)]
		public IActionResult Index(Guid id)
		{
			var model = new AnnexContractIndexViewModel()
			{
				CustomerId = id,
				BookingTypeId = BookingTypeEnum.Contract_Booking,
			};
			return View(model);
		}
		[HttpGet]
		public async Task<IActionResult> DetailAsync(Guid id)
		{
			try
			{
				var annexContract = await _annexContractPartnerService.Get(id).FirstOrDefaultAsync();

				var model = annexContract.ToViewModel();

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpGet]
		public async Task<IActionResult> ChangeToBookingOutAsync(Guid id)
		{
			try
			{
				var annexContract = await _annexContractPartnerService.Get(id).FirstOrDefaultAsync();

				var model = annexContract.ToViewModel();

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpGet]
		public async Task<IActionResult> ChangeCustomerAsync(Guid id)
		{
			try
			{
				var annexContract = await _annexContractPartnerService.Get(id).FirstOrDefaultAsync();

				var model = annexContract.ToViewModel();

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}