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
using HD.TVAD.Web.Features.Manager.SpotBlocks;
using HD.TVAD.Web.Infrastructure;
using HD.TVAD.Web.StartData;
using Microsoft.AspNetCore.Identity;
using HD.TVAD.Entities.Entities.Security;
using HD.TVAD.Web.Features.Manager.AnnexContracts;
using HD.TVAD.Web.Features.Manager.RetailContracts;
using HD.TVAD.ApplicationCore.Entities.Booking;
//using HD.TVAD.ApplicationCore.Entities.Security;

namespace HD.TVAD.Web.Features.Manager
{
	[Authorize]
	public class BookingController : TVADController
	{
		private readonly IAnnexContractPartnerService _annexContractPartnerService;
		private readonly IAnnexContractService _annexContractService;
		private readonly IRetailContractService _retailContractService;
		private readonly IAnnexContractAssetService _annexContractAssetService;
		private readonly ISpotBookingService _spotBookingService;
		private readonly IGetTypeService _getTypeService;
		public BookingController(
			IGetTypeService getTypeService,
			IAnnexContractPartnerService annexContractPartnerService,
			IAnnexContractService annexContractService,
			IAnnexContractAssetService annexContractAssetService,
			ISpotBookingService spotBookingService,
			IRetailContractService retailContractService)
		{
			_annexContractPartnerService = annexContractPartnerService;
			_getTypeService = getTypeService;
			_annexContractService = annexContractService;
			_annexContractAssetService = annexContractAssetService;
			_spotBookingService = spotBookingService;
			_retailContractService = retailContractService;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		[RequiresPermission(UserPermissions.ImportData_NormalBooking_CRUD)]
		public async Task<IActionResult> CreateSpotBookingAsync(Guid? id)
		{

			var model = new CreateSpotBookingIndexViewModel()
			{
				AnnexContractId = id,
				AnnexContract = new AnnexContractViewModel(),
			};
			if (id.HasValue)
			{
				var annexContract = await _annexContractPartnerService.Get(id.Value).FirstOrDefaultAsync();
				if (annexContract == null)
					return NotFound();
				if (annexContract.AnnexContract.BookingTypeId != (int)BookingTypeEnum.Contract_Booking)
					return NotFound();

				var annexContractViewMode = annexContract.ToViewModel();
				model.AnnexContract = annexContractViewMode;

			}

			return View(model);
		}

		[HttpGet]
		[RequiresPermission(UserPermissions.ImportData_SpotBookingIn_CRUD)]
		public async Task<IActionResult> BookingInAsync(Guid? id)
		{

			var model = new CreateSpotBookingIndexViewModel()
			{
				AnnexContractId = id,
				AnnexContract = new AnnexContractViewModel(),
			};
			if (id.HasValue)
			{
				var annexContract = await _annexContractPartnerService.Get(id.Value).FirstOrDefaultAsync();
				if (annexContract == null)
					return NotFound();
				if (annexContract.AnnexContract.BookingTypeId != (int)BookingTypeEnum.Contract_Sponsor_InProgram)
					return NotFound();

				var annexContractViewMode = annexContract.ToViewModel();
				model.AnnexContract = annexContractViewMode;

			}
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> TrailerBookingAsync(Guid? id)
		{

			var model = new CreateSpotBookingIndexViewModel()
			{
				AnnexContractId = id,
				AnnexContract = new AnnexContractViewModel(),
			};
			if (id.HasValue)
			{
				var annexContract = await _annexContractPartnerService.Get(id.Value).FirstOrDefaultAsync();
				if (annexContract == null)
					return NotFound();
				if (annexContract.AnnexContract.BookingTypeId != (int)BookingTypeEnum.Contract_Sponsor_Trailer)
					return NotFound();

				var annexContractViewMode = annexContract.ToViewModel();
				model.AnnexContract = annexContractViewMode;

			}

			return View(model);
		}
		[HttpGet]
		public async Task<IActionResult> BenefitBookingAsync(Guid? id)
		{

			var model = new CreateSpotBookingIndexViewModel()
			{
				AnnexContractId = id,
				AnnexContract = new AnnexContractViewModel(),
			};
			if (id.HasValue)
			{
				var annexContract = await _annexContractPartnerService.Get(id.Value).FirstOrDefaultAsync();
				if (annexContract == null)
					return NotFound();
				if (annexContract.AnnexContract.BookingTypeId != (int)BookingTypeEnum.Contract_Sponsor_Benefit)
					return NotFound();

				var annexContractViewMode = annexContract.ToViewModel();
				model.AnnexContract = annexContractViewMode;

			}

			return View(model);
		}
		[HttpGet]
		[RequiresPermission(UserPermissions.ImportData_SpotBookingOut)]
		public async Task<IActionResult> BookingOutAsync(Guid? id)
		{

			var model = new CreateSpotBookingIndexViewModel()
			{
				AnnexContractId = id,
				AnnexContract = new AnnexContractViewModel(),
			};
			if (id.HasValue)
			{
				var annexContract = await _annexContractPartnerService.Get(id.Value).FirstOrDefaultAsync();
				if (annexContract == null)
					return NotFound();
				if (annexContract.AnnexContract.BookingTypeId != (int)BookingTypeEnum.Contract_Sponsor_OutProgram)
					return NotFound();

				var annexContractViewMode = annexContract.ToViewModel();
				model.AnnexContract = annexContractViewMode;

			}

			return View(model);
		}
		[HttpGet]
		[RequiresPermission(UserPermissions.ImportData_SpotBookingRetail)]
		public async Task<IActionResult> RetailBookingAsync(Guid? id)
		{
			var model = new CreateRetailSpotBookingIndexViewModel()
			{
				AnnexContractId = id,
				RetailContract = new RetailContractViewModel(),
			};
			if (id.HasValue)
			{
				var retailContract = await _retailContractService.Get(id.Value).FirstOrDefaultAsync();
				if (retailContract == null)
					return NotFound();
				if (retailContract.AnnexContract.BookingTypeId != (int)BookingTypeEnum.Retail)
					return NotFound();

				if (retailContract != null)
				{
					var RetailContractViewModel = retailContract.ToViewModel();
					model.RetailContract = RetailContractViewModel;
				}
			}

			return View(model);
		}
		[HttpGet]
		public async Task<IActionResult> DetailAnnexContractAssetAsync(Guid id)
		{
			try
			{
				var annexContractAsset = await _annexContractAssetService.Get(id).FirstOrDefaultAsync();
				var bookingType = (BookingTypeEnum)annexContractAsset.AnnexContract.BookingTypeId;
				switch (bookingType)
				{
					case BookingTypeEnum.Retail:
						var viewModelRetail = new AnnexContractAssetForNormalBookingEditViewModel()
						{
							AnnexContractId = annexContractAsset.AnnexContractId,
							Id = annexContractAsset.Id,
							AssetBlockDuration = annexContractAsset.Content.BlockDuration,
							AssetCode = annexContractAsset.Content.Code,
							AssetId = annexContractAsset.ContentId,
							AssetProductName = annexContractAsset.Content.ProductName,
							PriceTypeDetailId = annexContractAsset.PriceTypeDetailId,
							Content = annexContractAsset.Contents,
							Price = annexContractAsset.Price,
							BookingType = (BookingTypeEnum)annexContractAsset.AnnexContract.BookingTypeId,
						};
						return PartialView("_AnnexContractAssetEditPartial", viewModelRetail);

					default:
						var viewModel = new AnnexContractAssetForNormalBookingEditViewModel()
						{
							AnnexContractId = annexContractAsset.AnnexContractId,
							Id = annexContractAsset.Id,
							AssetBlockDuration = annexContractAsset.Content.BlockDuration,
							AssetCode = annexContractAsset.Content.Code,
							AssetId = annexContractAsset.ContentId,
							AssetProductName = annexContractAsset.Content.ProductName,
							PriceTypeDetailId = annexContractAsset.PriceTypeDetailId,
							BookingType = (BookingTypeEnum)annexContractAsset.AnnexContract.BookingTypeId,
						//	Content = annexContractAsset.Contents,
						//	Price = annexContractAsset.Price
						};
						return PartialView("_AnnexContractAssetEditPartial", viewModel);
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
		[HttpGet]
		public async Task<IActionResult> SpotBookingDetailAsync(Guid id)
		{
			try
			{
				var spotBooking = await _spotBookingService.Get(id).FirstOrDefaultAsync();

				var viewModel = new SpotBookingForNormalBookingEditViewModel()
				{
					AnnexContractId = spotBooking.AnnexContractId,
					Id = spotBooking.Id,
					AnnexContractAssetId = spotBooking.AnnexContractAssetId,
					AssetCode = spotBooking.AssetCode,
					BookingDate = spotBooking.BookingDate,
					BookingType = spotBooking.BookingType,
					BroadcastDate = spotBooking.Spot.BroadcastDate,
					Position = spotBooking.Position,
					IsPositionCost = spotBooking.IsPositionCost.HasValue? spotBooking.IsPositionCost.Value: false,
					TimeBandId = spotBooking.TimeBandId,
					TimeBandSliceId = spotBooking.Spot.TimeBandSliceId,
				};
				return PartialView("_SpotBookingEditPartial", viewModel);
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}