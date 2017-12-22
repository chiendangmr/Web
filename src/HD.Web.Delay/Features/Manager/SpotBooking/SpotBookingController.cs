using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HD.TVAD.Web.Services;
using HD.TVAD.Services.PriceCalculation;
using HD.TVAD.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using HD.TVAD.ApplicationCore.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using HD.TVAD.Entities.Entities.Security;
using System.IO;
using HD.TVAD.ApplicationCore.Entities.MediaAsset;
using HD.TVAD.ApplicationCore.Entities.Booking;

namespace HD.TVAD.Web.Features.Manager.SpotBookings
{
    [Area("Manager")]
    [Authorize]
    public class SpotBookingController : TVADController
    {
        private readonly ISpotBookingService _spotBookingService;
        private readonly ISpotService _spotService;
        private readonly IAnnexContractAssetService _annexContractAssetService;
        private readonly IAnnexContractService _annexContractService;
        private readonly IRetailContractService _retailContractService;
        private readonly IAnnexContractPartnerService _annexContractPartnerService;
        private readonly IPriceCalculationService _priceCalculationService;
        private readonly IAssetService _assetService;
		private readonly IContentService _contentService;
		private readonly ITimeBandService _timeBandService;
        private readonly ITimeBandSliceService _timeBandSliceService;
        private readonly IEvidenceService _evidenceService;
        private readonly IOptions<Settings> _settings;
		private readonly INotificationService _notificationService;
		private readonly UserManager<User> _userManager;
        private readonly IAssetTypeService _assetTypeService;
        private readonly IStorageLocationService _storageLocationService;
        public SpotBookingController(
            ISpotBookingService spotBookingService,
            ISpotService spotService,
            IAnnexContractAssetService annexContractAssetService,
            IAnnexContractService annexContractService,
            IPriceCalculationService priceCalculationService,
            IAnnexContractPartnerService annexContractPartnerService,
            IRetailContractService retailContractService,
            IAssetService assetService,
            ITimeBandService timeBandService,
            ITimeBandSliceService timeBandSliceService,
            IEvidenceService evidenceService,
            IOptions<Settings> settings,
            INotificationService notificationService,
            UserManager<User> userManager,
            IAssetTypeService assetTypeService,
            IStorageLocationService storageLocationService,
			IContentService contentService
			)
        {
            _spotBookingService = spotBookingService;
            _spotService = spotService;
            _annexContractAssetService = annexContractAssetService;
            _annexContractService = annexContractService;
            _priceCalculationService = priceCalculationService;
            _annexContractPartnerService = annexContractPartnerService;
            _retailContractService = retailContractService;
            _assetService = assetService;
            _timeBandService = timeBandService;
            _timeBandSliceService = timeBandSliceService;
            _evidenceService = evidenceService;
            _settings = settings;
			_notificationService = notificationService;
			_userManager = userManager;
            _assetTypeService = assetTypeService;
            _storageLocationService = storageLocationService;
			_contentService = contentService;
		}
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> IndexContractAsync(Guid id)
        {
            try
            {
                var bookingType = await _annexContractService.GetBookingTypeAsync(id);
                switch (bookingType)
                {
                    case ApplicationCore.Entities.Booking.BookingTypeEnum.Retail:

                        var retailContract = await _retailContractService.Get(id).FirstOrDefaultAsync();
                        var retailContractViewModel = retailContract.ToViewModel();

                        return View(retailContractViewModel);
                    default:
                        var annexContractPartner = await _annexContractPartnerService.Get(id).FirstOrDefaultAsync();
                        var annexContractPartnerViewModel = annexContractPartner.ToViewModel();

                        return View(annexContractPartnerViewModel);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
		public async Task<IActionResult> IndexBookingAsync(Guid id)
		{
			try
			{
				var annexContract = await _annexContractService.Get(id).FirstOrDefaultAsync();

				var viewModel = new SpotBookingIndexViewModel()
				{
					//	AnnexContractAssetId = id,
					AnnexContractId = id,
					SpotBookingCreateIndexViewModel = new SpotBookingCreateIndexViewModel()
					{
						AnnexContractAssetId = Guid.Empty,
						BroadcastDate = DateTime.Today,
						BookingType = (BookingTypeEnum)annexContract.BookingTypeId,
					}

				};
				return View(viewModel);

			}
			catch (Exception)
			{

				throw;
			}

		}

		[HttpGet]
        public IActionResult Create(Guid id)
        {
            var viewModel = new SpotBookingCreateIndexViewModel()
            {
                AnnexContractAssetId = id,
                BroadcastDate = DateTime.Today
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(SpotBookingCreateIndexViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var spot = new Spot()
                {
                    BroadcastDate = viewModel.BroadcastDate,
                    TimeBandSliceId = viewModel.TimeBandSliceId
                };
                if (!_spotService.Exist(spot)) // create new
                {
                    var spotBooking = viewModel.ToDataModel();
                    var result = await _spotBookingService.Create(spotBooking);

					var user = await _userManager.GetUserAsync(User);
					var notifi = new ApplicationCore.Entities.Notification($"{user.UserName} {ActionType.Create.GetDisplayName()} a spot booking");
					await _notificationService.MakeNotificationAsync(notifi);

					return JsonResponse(result, ActionType.Create, spotBooking.Id);
                }
                else // Exist spot, add booking
                {
                    var _spot = await _spotService.Get(spot);
                    if (_spot != null)
                    {
                        var spotBooking = viewModel.ToDataModel(_spot);
                        var result = await _spotBookingService.Create(spotBooking);

                        return JsonResponse(result, ActionType.Create, spotBooking.Id);
                    }
                    else
                        throw new NullReferenceException();
                }
            }
            else
                return JsonResponse(StatusType.ERROR, ModelState);
		}
		[HttpPost]
		public async Task<IActionResult> CreateAPIAsync(SpotBookingCreateIndexViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var spot = new Spot()
					{
						BroadcastDate = viewModel.BroadcastDate,
						TimeBandSliceId = viewModel.TimeBandSliceId
					};
					if (!_spotService.Exist(spot)) // create new
					{
						var spotBooking = viewModel.ToDataModel();
						await _contentService.CheckAllowBookingAsync(spotBooking);

						var result = await _spotBookingService.Create(spotBooking);
						#region notifi
						var user = await _userManager.GetUserAsync(User);
						var notifi = new ApplicationCore.Entities.Notification($"{user.UserName} {ActionType.Create.GetDisplayName()} a spot booking");
						await _notificationService.MakeNotificationAsync(notifi);
						#endregion

						return Json(new ResponseJsonResult()
						{
							Succeeded = true,
							Id = spotBooking.Id,
							Data = viewModel,
							Message = "Created",
						});
					}
					else // Exist spot, add booking
					{
						var _spot = await _spotService.Get(spot);
						if (_spot != null)
						{
							var spotBooking = viewModel.ToDataModel(_spot);
							await _contentService.CheckAllowBookingAsync(spotBooking);

							var result = await _spotBookingService.Create(spotBooking);

							return Json(new ResponseJsonResult()
							{
								Succeeded = true,
								Id = spotBooking.Id,
								Data = viewModel,
								Message = "Created",
							});
						}
						else
							throw new NullReferenceException();
					}

				}
				catch (Exception ex)
				{
					return Json(new ResponseJsonResult()
					{
						Succeeded = false,
						Data = viewModel,
						Message = ex.Message,
					});
				}
			}
			else
				return Json(new ResponseJsonResult()
				{
					Succeeded = false,
					Message = "Input not vail!",
				});
		}
		[HttpGet]
        public async Task<IActionResult> GetAllByAnnexContractIdAsync([DataSourceRequest]DataSourceRequest request, Guid annexContractId, SpotBookingSearchIndexViewModel searchParameter)
        {
            try
            {
				var spotBookings = await _spotBookingService.GetAll()
					.Where(a => a.AnnexContractAsset.AnnexContractId == annexContractId)
					.Where(a => searchParameter.FromDate == null || searchParameter.ToDate == null ||
						a.Spot.BroadcastDate >= searchParameter.FromDate && a.Spot.BroadcastDate <= searchParameter.ToDate)
					.Where(a => searchParameter.TimeBandId == null || a.Spot.TimeBandSlice.TimeBandId == searchParameter.TimeBandId)
					.Where(a => searchParameter.TimeBandSliceId == null || a.Spot.TimeBandSliceId == searchParameter.TimeBandSliceId)
					.ToListAsync();

                var spotBookingResults  = spotBookings.AsQueryable().ToViewModel(_priceCalculationService);

                var result = await spotBookingResults.ToDataSourceResultAsync(request);

                return Json(result);

            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> EditAsync(Guid id)
        {
            var spotBooking = await _spotBookingService.Get(id).FirstOrDefaultAsync();

            var viewModel = spotBooking.ToViewModel(_priceCalculationService);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(SpotBookingCreateIndexViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var spotBooking = await _spotBookingService.Get(viewModel.Id).FirstOrDefaultAsync();
				if (spotBooking.IsApproved)
				{
					throw new Exception("Booking is approved!");
				}
				spotBooking.EditDataModel(viewModel);

                var result = await _spotBookingService.Update(spotBooking);
                return JsonResponse(result, ActionType.Edit, spotBooking.Id);
            }
            else
                return JsonResponse(StatusType.ERROR, ModelState);
        }

		[HttpPost]
		public async Task<IActionResult> EditAPIAsync(SpotBookingForNormalBookingEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var spot = new Spot()
					{
						Id = Guid.NewGuid(),
						BroadcastDate = viewModel.BroadcastDate,
						TimeBandSliceId = viewModel.TimeBandSliceId
					};
					var spotBooking = await _spotBookingService.Get(viewModel.Id).FirstOrDefaultAsync();
					if (spotBooking.IsApproved)
					{
						throw new Exception("Booking is approved!");
					}
					var result = 0;
					if (_spotService.Exist(spot)) // exist spot
					{
						var _spot = await _spotService.Get(spot);
						spotBooking.EditDataModel(viewModel, _spot.Id);

						result = await _spotBookingService.Update(spotBooking);
					}
					else
					{ // create new spot

						var _spotCreateResult = await _spotService.Create(spot);
						if (_spotCreateResult < 0)
							throw new Exception("Can not creat spot!");

						var _spot = await _spotService.Get(spot);

						spotBooking.EditDataModel(viewModel, _spot.Id);

						result = await _spotBookingService.Update(spotBooking);

					}
					if (result < 0)
						throw new Exception("Can not update!");

					return Json(new ResponseJsonResult()
					{
						Succeeded = true,
						Id = viewModel.Id,
						Data = viewModel,
						Message = "Updated",
					});
				}
				catch (Exception ex)
				{

					return Json(new ResponseJsonResult()
					{
						Succeeded = false,
						Message = ex.Message,
					});
				}
			}
			else
				return Json(new ResponseJsonResult()
				{
					Succeeded = false,
					Data = ModelState,
					Message = "Input not vail!",
				});
		}
		[HttpGet]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _spotBookingService.Get(id).FirstOrDefaultAsync();
                var viewModel = new DeleteViewModel()
                {
                    Id = result.Id
                };
                return View(viewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAPIAsync(DeleteViewModel viewModel)
        {
            try
            {
                var resultGet = await _spotBookingService.Get(viewModel.Id).FirstOrDefaultAsync();
				if (resultGet.IsApproved)
					throw new Exception("Booking is approved!");

				var resultDelete = await _spotBookingService.Delete(resultGet);

				if (resultDelete < 0)
					throw new Exception("Can not delete!");
				return Json(new ResponseJsonResult()
				{
					Succeeded = true,
					Id = viewModel.Id,
					Data = viewModel,
					Message = "Deleted",
				});
			}
            catch (Exception ex)
			{
				return Json(new ResponseJsonResult()
				{
					Succeeded = false,
					Message = ex.Message,
				});
			}
		}
		[HttpPost]
		public async Task<IActionResult> DeleteManyAPIAsync(IEnumerable<Guid> spotBookingIds)
		{
			try
			{
				var spotBookings = await _spotBookingService.GetAll()
					.Where(s => spotBookingIds.Contains(s.Id))
					.ToListAsync();
				if(spotBookings.Any(s => s.IsApproved))
					throw new Exception("Some booking is approved!");

				var resultDelete = await _spotBookingService.DeleteRange(spotBookings);

				if (resultDelete <= 0)
					throw new Exception("Can not delete!");
				return Json(new ResponseJsonResult()
				{
					Succeeded = true,
					Data = spotBookingIds,
					Message = "Deleted",
				});
			}
			catch (Exception ex)
			{
				return Json(new ResponseJsonResult()
				{
					Succeeded = false,
					Message = ex.Message,
				});
			}
		}
		[HttpPost]
		public async Task<IActionResult> DeleteAsync(DeleteViewModel viewModel)
		{
			try
			{
				var resultGet = await _spotBookingService.Get(viewModel.Id).FirstOrDefaultAsync();
				if (resultGet.IsApproved)
				{
					throw new Exception("Booking is approved!");
				}

				var resultDelete = await _spotBookingService.Delete(resultGet);

				return JsonResponse(resultDelete, ActionType.Delete);
			}
			catch (Exception)
			{
				throw;
			}
		}
		        
        public async Task<List<StorageLocation>> GetStorageLocationFromAssetType(Guid assetTypeId)
        {
            var lstStorageLocation = (await _assetTypeService.Get(assetTypeId).FirstOrDefaultAsync()).StorageLocations.ToList();

            return lstStorageLocation;
        }
        public async Task<List<StorageLocationAccess>> GetStorageLocationAccessFromStorageLocation(Guid storageLocationId)
        {
            var lstStorageLocationAccess = (await _storageLocationService.Get(storageLocationId).FirstOrDefaultAsync()).StorageLocationAccesses.ToList();
            return lstStorageLocationAccess;
        }
        public async Task<string> GetEvidencePath(Guid assetTypeId)
        {
            var assetTypePath = (await _assetTypeService.Get(assetTypeId).FirstOrDefaultAsync()).DefaultPath;
            assetTypePath = assetTypePath == null ? "" : assetTypePath;
            var _storageLocationId = (await GetStorageLocationFromAssetType(assetTypeId)).FirstOrDefault().Id;
            var storageLocationAccessPath = (await GetStorageLocationAccessFromStorageLocation(_storageLocationId)).FirstOrDefault().Path;
            return Path.Combine(storageLocationAccessPath, assetTypePath);
		}
		[HttpPost]
		public async Task<IActionResult> ChangeAnnexContractAssetAsync(Guid annexContractAssetId, IEnumerable<Guid> spotBookingIds)
		{
			try
			{
				var spotBookings = await _spotBookingService.GetAll()
					.Where(s => spotBookingIds.Contains(s.Id))
					.ToListAsync();
				if (spotBookings.Any(s => s.IsApproved))
					throw new Exception("Some booking is approved!");

				foreach (var spotBooking in spotBookings)
				{
					spotBooking.ChangeAnnexContractAsset(annexContractAssetId);
				}
				var result = await _spotBookingService.UpdateRange(spotBookings);
				if (result > 0)
				{
					return Json(new ResponseJsonResult()
					{
						Succeeded = true,
						Data = spotBookingIds,
						Message = $"Changed {spotBookingIds.Count()} booking",
					});
				}
				else
					throw new Exception("Can't change!");
			}
			catch (Exception ex)
			{
				return Json(new ResponseJsonResult()
				{
					Succeeded = false,
					Data = spotBookingIds,
					Message = ex.Message,
				});
			}
		}
	}
}