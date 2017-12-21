using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Newtonsoft.Json;
using HD.TVAD.Web.Services;
using HD.TVAD.Web.Models;
using HD.TVAD.ApplicationCore.Models;
using HD.TVAD.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using HD.TVAD.Web.Features.Manager;
using HD.Station.MediaAssets;
using Microsoft.Extensions.Options;
using HD.TVAD.Web;
using HD.TVAD.Web.Features.Booking;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using HD.TVAD.Web.Infrastructure;
using HD.TVAD.Web.StartData;

namespace HD.TVAD.Features.Manager
{
	[Area("Booking")]
	[Authorize]
	public class SpotController : TVADController
	{
		private TimeSpan HALF_DAY;
		private readonly IOptions<Settings> _settings;
		private ISpotBookingService _spotBookingService;
		private ITimeBandSliceService _timeBandSliceService;
		private ITimeBandService _timeBandService;
		private IChannelService _channelService;

		private ISpotService _spotService;
		private ILogger<SpotController> _logger;
		private ISpotAssetService _spotAssetService;
		private ISpotAssetByAssetService _spotAssetByAssetService;
		private Station.MediaAssets.IMediaAssetService _mediaAssetService;
		public SpotController(
			IOptions<Settings> settings,
			ISpotBookingService spotBookingService,
			ISpotService spotService,
			ISpotAssetService spotAssetService,
			ITimeBandSliceService timeBandSliceService,
			ITimeBandService timeBandService,
			IChannelService channelService,
			ISpotAssetByAssetService spotAssetByAssetService,
			ILogger<SpotController> logger,
		Station.MediaAssets.IMediaAssetService mediaAssetService ) {

			_spotBookingService = spotBookingService;
			_spotService = spotService;
			_spotAssetService = spotAssetService;
			_timeBandSliceService = timeBandSliceService;
			_mediaAssetService = mediaAssetService;
			_timeBandSliceService = timeBandSliceService;
			_timeBandService = timeBandService;
			_channelService = channelService;
			_settings = settings;
			_spotAssetByAssetService = spotAssetByAssetService;
			_logger = logger;
			HALF_DAY = TimeSpan.FromMilliseconds(_settings.Value.AppSettings.DayPartTimeSpan);
		}

		[RequiresPermission(UserPermissions.Other_ApprovePlaylist)]
		public async Task<IActionResult> Index() {

			return View();
		}
		[RequiresPermission(UserPermissions.Other_ApprovePlaylist)]
		public async Task<IActionResult> Approval()
		{

			return View();
		}

		public async Task<IActionResult> IndexClearTemplate()
		{

			return View();
		}
		[RequiresPermission(UserPermissions.Other_ApproveRetailPlaylist)]
		public async Task<IActionResult> ApprovalSimplySpot()
		{

			return View();
		}
		public async Task<IActionResult> GetAllSpot(SpotSearchIndexViewModel searchParameter)
		{
			try
			{
				var model = new List<SpotViewModel>();
				var timeBands = new List<TimeBand>();
				if (searchParameter.ChannelId.HasValue)
					timeBands = await _timeBandService.GetAllTimeBandByChannelIdAsync(searchParameter.ChannelId.Value);

				var thisDay = searchParameter.InDate;
				var nextDay = searchParameter.InDate.AddDays(1);

				var timeBandsOfDayPart2OfThisDate = await _timeBandService.GetAllTimeBandOfDayPart2Async(thisDay);
				var timeBandsOfDayPart1OfNextDate = await _timeBandService.GetAllTimeBandOfDayPart1Async(nextDay);
				

				var spots = await _spotService.GetAllInclude()
					.Where(a => searchParameter.TimePeriodType == SpotSearchTimePeriod.OneDay ? a.BroadcastDate == searchParameter.InDate || a.BroadcastDate == searchParameter.InDate.AddDays(1)
					: a.BroadcastDate >= searchParameter.FromDate && a.BroadcastDate <= searchParameter.ToDate)
					.Where(s => searchParameter.ChannelId == null || timeBands.Any(t => t.Id == s.TimeBandSlice.TimeBandId))
					.Where(a => searchParameter.TimeBandId == null || a.TimeBandSlice.TimeBandId == searchParameter.TimeBandId)
					.Where(a => searchParameter.TimeBandSliceId == null || a.TimeBandSliceId == searchParameter.TimeBandSliceId)
					.Where(a => (timeBandsOfDayPart2OfThisDate.Any(t => t.Id == a.TimeBandSlice.TimeBandId)) && thisDay == a.BroadcastDate
					|| (timeBandsOfDayPart1OfNextDate.Any(t => t.Id == a.TimeBandSlice.TimeBandId) && nextDay == a.BroadcastDate))
					.ToListAsync();
			
			//	var spots = _spots.Where(s => s.)


				foreach (var spot in spots)
				{
					//var maxDuration = await GetMaxDurationAsync(spot.TimeBandSliceId, spot.BroadcastDate);
					//var timeBandDescription = _timeBandService.GetTimeBandDescriptionByDate(spot.TimeBandId, spot.BroadcastDate);
					//var timeBandSliceDescription = _timeBandSliceService.GetTimeBandSliceDescriptionByDate(spot.TimeBandSliceId, spot.BroadcastDate);	

					var maxDuration = spot.TimeBandSlice.TimeBandSliceDurations
						.Where(s => s.StartDate <= spot.BroadcastDate && (s.EndDate >= spot.BroadcastDate || s.EndDate == null))
						.OrderByDescending(s => s.StartDate)
						.FirstOrDefault()?
						.Duration;

					var timeBandDescription = spot.TimeBandSlice.TimeBand.TimeBandDescriptions
						.Where(s => s.StartDate <= spot.BroadcastDate && (s.EndDate >= spot.BroadcastDate || s.EndDate == null))
						.OrderByDescending(s => s.StartDate)
						.FirstOrDefault()?
						.Description;

					var timeBandSliceDescription = spot.TimeBandSlice.TimeBandSliceDescriptions
						.Where(s => s.StartDate <= spot.BroadcastDate && (s.EndDate >= spot.BroadcastDate || s.EndDate == null))
						.OrderByDescending(s => s.StartDate)
						.FirstOrDefault()?
						.Description;

					var channel = await _channelService.GetChannelOfTimeBandAsync(spot.TimeBandId);

					foreach (var spotBooking in spot.SpotBookings)
					{
						model.Add(new SpotViewModel()
						{
							Id = spotBooking.Id,
							SpotBookingId = spotBooking.Id,
							SpotId = spotBooking.Spot.Id,
							BroadcastDate = spotBooking.Spot.BroadcastDate,
							TimeBandName = spotBooking.Spot.TimeBandName,
							TimeBandSliceName = spotBooking.Spot.TimeBandSliceName,
							AssetCode = spotBooking.AssetCode,
							AssetBlockDuration = spotBooking.AssetDuration,
							ProductName = spotBooking.AnnexContractAsset.Content.ProductName,
							AssetId = spotBooking.ContentId,
							ApproveOnAir = spotBooking.IsApproved,
							Position = spotBooking.Position.GetValueOrDefault(99),
							BookingAssetType = 0,
							TimeBandSliceId = spotBooking.Spot.TimeBandSliceId,
							TimeBandId = spotBooking.TimeBandId,
							PositionCost = spotBooking.IsPositionCost,
							MaxDuration = maxDuration.GetValueOrDefault(),
							ContractCode = spotBooking.AnnexContractAsset.AnnexContract.Code,
							Index = spotBooking.IsApproved ? spotBooking.SpotAssetByBookings.SpotAsset.Index : 999,
							BookingTypeId = spotBooking.BookingTypeId,
							BookingTypeName = spotBooking.BookingTypeName,
							CustomerName = spotBooking.CustomerName,
							CustomerCode = spotBooking.CustomerCode,
							SponsorProgramId = spotBooking.SponsorProgramId,
							SponsorProgramName = spotBooking.SponsorProgramName,

							TimeBandDescription = $"{spotBooking.Spot.TimeBandName} - {timeBandDescription}",
							TimeBandSliceDescription = $"{spotBooking.Spot.TimeBandSliceName} - {timeBandSliceDescription}",
							ChannelId = channel.Id,
							ChannelName = channel.TimeBandBase.Name,

							TmpOrder = spotBooking.TmpOrder.GetValueOrDefault(999),
						});

					}

					foreach (var spotAsset in spot.SpotAssets) // add spotassset by asset
					{
						if (spotAsset.HasAssetBooking)
						{
							model.Add(new SpotViewModel()
							{
								Id = spotAsset.SpotAssetByAssets.Id,
								SpotId = spotAsset.Spot.Id,
								BroadcastDate = spotAsset.Spot.BroadcastDate,
								TimeBandName = spotAsset.Spot.TimeBandName,
								TimeBandSliceName = spotAsset.Spot.TimeBandSlice.Name,
								ContractCode = "00000",
								Position = 99,
								AssetCode = spotAsset.SpotAssetByAssets.Asset.Code,
								ProductName = spotAsset.SpotAssetByAssets.Asset.ProductName,
								AssetBlockDuration = spotAsset.SpotAssetByAssets.Asset.BlockDuration,
								AssetId = spotAsset.SpotAssetByAssets.Asset.Id,
								ApproveOnAir = true,
								Index = spotAsset.Index,
								BookingAssetType = 1,
								TimeBandSliceId = spotAsset.Spot.TimeBandSliceId,
								TimeBandId = spotAsset.Spot.TimeBandId,
								MaxDuration = maxDuration.GetValueOrDefault(),

								TimeBandDescription = $"{spotAsset.Spot.TimeBandName} - {timeBandDescription}",
								TimeBandSliceDescription = $"{spotAsset.Spot.TimeBandSliceName} - {timeBandSliceDescription}",
								ChannelId = channel.Id,
								ChannelName = channel.TimeBandBase.Name,

								TmpOrder = spotAsset.SpotAssetByAssets.TmpOrder.GetValueOrDefault(999),
							});

						}
					}

				}

				return Json(model);

			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public async Task<IActionResult> GetAllApprovalSpot(SpotSearchIndexViewModel searchParameter)
		{
			try
			{
				if (searchParameter.TimePeriodType == SpotSearchTimePeriod.OneDay)
					searchParameter.ToDate = null;

				var spots = _spotService.GetApprovalSpot(searchParameter.InDate.Add(HALF_DAY),
					searchParameter.ToDate, searchParameter.ChannelId,
					searchParameter.TimeBandId, searchParameter.TimeBandSliceId)
					.ToList();


				var model = spots.Select(spotBooking => new SpotViewModel()
				{
					Id = spotBooking.Id,
					SpotBookingId = spotBooking.Id,
					SpotId = spotBooking.SpotId,
					BroadcastDate = spotBooking.BroadcastDate,
					TimeBandName = spotBooking.TimebandName,
					TimeBandSliceName = spotBooking.SliceName,
					AssetCode = spotBooking.Code,
					AssetBlockDuration = spotBooking.BlockDuration,
					ProductName = spotBooking.ProductName,
					AssetId = spotBooking.ContentId,
					ApproveOnAir = spotBooking.BroadcastId.HasValue,
					Position = spotBooking.Position.GetValueOrDefault(99),
					BookingAssetType = spotBooking.Type,
					TimeBandSliceId = spotBooking.SliceId,
					TimeBandId = spotBooking.TimebandId,
					PositionCost = spotBooking.PositionCost,
					MaxDuration = spotBooking.SliceDuration,
					ContractCode = spotBooking.AnnexContractCode,
					Index = spotBooking.BroadcastId.HasValue ? spotBooking.BroadcastIndex : 999,
					BookingTypeId = spotBooking.BookingTypeId,
					//	BookingTypeName = spotBooking.BookingTypeId,
					//	CustomerName = spotBooking.CustomerName,
					//	CustomerCode = spotBooking.CustomerCode,
					//	SponsorProgramId = spotBooking.SponsorProgramId,
					//	SponsorProgramName = spotBooking.SponsorProgramName,

					TimeBandDescription = $"{spotBooking.TimebandName} - {spotBooking.TimebandDescription}",
					TimeBandSliceDescription = $"{spotBooking.SliceName} - {spotBooking.SliceDescription}",
					ChannelId = spotBooking.ChannelId,
					ChannelName = spotBooking.ChannelName,

					TimebandNameToSort = $"{spotBooking.TimebandNameToSort};{spotBooking.TimebandName} - {spotBooking.TimebandDescription}",

					TmpOrder = spotBooking.TmpOrder.GetValueOrDefault(999),
				}).ToList();

				return Json(model);

			}
			catch (Exception ex)
			{

				throw;
			}
		}

		private async Task<int> GetMaxDurationAsync(Guid timeBandSliceId, DateTime broadcastDate)
		{
			var timebandslice = await _timeBandSliceService.Get(timeBandSliceId).FirstOrDefaultAsync();
			var maxDuration = timebandslice.TimeBandSliceDurations
				.Where(t => t.StartDate <= broadcastDate)
				.OrderByDescending(t => t.StartDate)
				.FirstOrDefault()?
				.Duration;
			return maxDuration.GetValueOrDefault();
		}

		[HttpPost]
		public async Task<IActionResult> Approve(SpotApproveViewModel viewModel)
		{
			try
			{
				var spot = await _spotService.Get(viewModel.Id).FirstOrDefaultAsync();

			//	spot.Approve(viewModel.ApproveOnAir);

				var result = await  _spotService.Update(spot);
				if (result > 0)
				{
					return Json(new JsonResponse("ok", "updated!"));
				}
				else
				{
					return Json("Error");
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpPost]
		public async Task<IActionResult> SaveSpot(SpotSaveFormModel viewModel)
		{
			try
			{
				if (viewModel.SpotBookings == null)
				{
					var spotAssets = await _spotAssetService.GetAll()
						.Where(s => s.SpotId == viewModel.SpotId)
						.ToListAsync();
					if (spotAssets.Count == 0)
						throw new Exception("No approved booking!");
					var resultDelete = await _spotAssetService.DeleteRange(spotAssets);

					return JsonResponse(resultDelete, "Cancel all approved booking!");
				}
					
				var spot = await _spotService.Get(viewModel.SpotId).FirstOrDefaultAsync();

				foreach (var newSpotBooking in viewModel.SpotBookings)
				{
					for (int i = spot.SpotBookings.Count - 1; i >= 0; i--)
					{
						var spotBooking = spot.SpotBookings.ElementAt(i);
						if (newSpotBooking.Id == spotBooking.Id)
						{
							spot.SpotBookings.ElementAt(i).IsPositionCost = newSpotBooking.PositionCost;
							spot.SpotBookings.ElementAt(i).TmpOrder = newSpotBooking.TmpOrder;
						}

					}
				}

				var approvedBooking = viewModel.SpotBookings
					.Where(s => s.IsApproved);

				var newSpotBookings = approvedBooking.Select(s =>
				{
					if (s.BookingAssetType == 0)
						return new SpotAsset()
						{
							Id = s.Id,
							SpotId = s.SpotId,
							Index = s.Index,
							SpotAssetByBookings = new SpotAssetByBooking()
							{
								Id = s.Id
							}
						};
					else
						return new SpotAsset()
						{
							SpotId = s.SpotId,
							Index = s.Index,
							SpotAssetByAssets = new SpotAssetByAsset()
							{
								AssetId = s.AssetId,
								TmpOrder = s.TmpOrder,
							}
						};
				}).ToList();				

				for (int i = spot.SpotAssets.Count - 1; i >= 0; i--)
				{
					var oldSpotBooking = spot.SpotAssets.ElementAt(i);
					if (!newSpotBookings.Any( newBooking => newBooking.Id == oldSpotBooking.Id && newBooking.SpotId == oldSpotBooking.SpotId)) // remove if no approve
					{
						spot.SpotAssets.Remove(oldSpotBooking);
					}
					foreach (var newBooking in newSpotBookings)
					{
						if (newBooking.Id == oldSpotBooking.Id && newBooking.SpotId == oldSpotBooking.SpotId)
						{
							oldSpotBooking.Index = newBooking.Index; // set new index
							if (oldSpotBooking.HasAssetBooking)
							{
								oldSpotBooking.SpotAssetByAssets.TmpOrder = newBooking.SpotAssetByAssets.TmpOrder;
							}
						}
					}
				}
				var newSpotBookingsToAdd = newSpotBookings.Where(newBooking => !spot.SpotAssets.Any(oldSpotBooking => newBooking.Id == oldSpotBooking.Id && newBooking.SpotId == oldSpotBooking.SpotId));

				spot.SpotAssets.AddRange(newSpotBookingsToAdd);

				var result = await _spotService.Update(spot);

				return JsonResponse(result, "Saved");
			}
			catch (Exception ex)
			{
				return JsonResponse(StatusType.ERROR, ex.Message); // no spotasset add
			}
		}
		[HttpPost]
		public async Task<IActionResult> AddSpotAsset(SpotAssetViewModel viewModel)
		{
			try
			{

				var spot = await _spotService.Get(viewModel.SpotId).FirstOrDefaultAsync();
				var spotAsset = new SpotAsset();
					if (viewModel.BookingAssetType == 0)
					{
					spotAsset= new SpotAsset()
					{
							Id = viewModel.Id,
							SpotId = viewModel.SpotId,
							Index = viewModel.Index,
							SpotAssetByBookings = new SpotAssetByBooking()
							{
								Id = viewModel.Id
							}
						};
					}
					else
					{
					var id = Guid.NewGuid();
						spotAsset = new SpotAsset()
						{
							Id = id,
							SpotId = viewModel.SpotId,
							Index = viewModel.Index,
							SpotAssetByAssets = new SpotAssetByAsset()
							{
								Id = id,
								AssetId = viewModel.AssetId,
								TmpOrder = viewModel.Index == 0 ? 999 : viewModel.Index,
							}
						};					

				}

				spot.SpotAssets.Add(spotAsset);
				// add new				

				var result = await _spotService.Update(spot);
				if (result > 0)
				{
					return Json(new JsonResponse("ok", "added!"));
				}
				else
				{
					return Json("Error");
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
		[HttpGet]
		public async Task<IActionResult> Approve(Guid id)
		{
			var viewModel = new SpotApproveViewModel()
			{
				Id = id,
			};
			return View(viewModel);
		}

		[HttpGet]
		public async Task<IActionResult> AddSpotAsset(Guid id)
		{
			var viewModel = new SpotAssetViewModel()
			{
				BookingAssetType = 1, // bookingByasset
				SpotId = id,
			};
			return View(viewModel);
		}
		[HttpGet]
		public async Task<IActionResult> ViewTemplate(Guid id)
		{
			var viewModel = new ViewTemplateIndexViewModel()
			{
				TimeBandId = id,
			};
			return View(viewModel);
		}

		[HttpGet]
		public async Task<IActionResult> Preview(Guid id)
		{

			var spot = await _spotService.Get(id).FirstOrDefaultAsync();
			var lowresFiles = new List<LowresFileViewModel>();
			if (spot != null)
			{
				var spotAssetIds = spot.SpotAssets
					.OrderBy(s => s.Index)
					.Select(s => s.Id);
				foreach (var spotAssetId in spotAssetIds)
				{
					var spotAsset = await _spotAssetService.Get(spotAssetId).FirstOrDefaultAsync();
					if (spotAsset.HasBooking)
					{
						var spotBooking = await _spotBookingService.Get(spotAssetId).FirstOrDefaultAsync();
						var contentId = spotBooking.ContentId;
						lowresFiles.Add(new LowresFileViewModel() {
							contentId = contentId,
							title = spotBooking.AnnexContractAsset.Content.ProductName,
						});
					}
					if (spotAsset.HasAssetBooking)
					{
						var contentId = spotAsset.SpotAssetByAssets.AssetId;
						lowresFiles.Add(new LowresFileViewModel()
						{
							contentId = contentId,
							title = spotAsset.SpotAssetByAssets.Asset.ProductName,							
						});
					}
				}
			}

			var viewModel = new PreviewIndexViewModel()
			{
				SpotId = id,
				LowresFiles = new List<LowresFileViewModel>(),
			};

			foreach (var lowresFile in lowresFiles)
			{
				var assets = await _mediaAssetService.LstAssetByTypeIdAsync(lowresFile.contentId, _settings.Value.AppSettings.AssetTypeTVCId);
				var asset = assets.LastOrDefault();
				if (asset != null)
				{
					var	previewUrls = await _mediaAssetService.LstPreviewUrlAsync(asset.Id);
					var previewUrl = previewUrls.FirstOrDefault();
					if (previewUrl != null)
					{
						viewModel.LowresFiles.Add(new LowresFileViewModel()
						{
							contentId = lowresFile.contentId,
							title = lowresFile.title,
							src = previewUrl
						});
					}
					else
					{
						viewModel.LowresFiles = new List<LowresFileViewModel>();
						break;
					}
				}
				else
				{
					viewModel.LowresFiles = new List<LowresFileViewModel>();
					break;
				}
			}

			return View(viewModel);
		}
		[HttpGet]
		public async Task<IActionResult> GetUsedDuration(DateTime broadcastDate, Guid timeBandSliceId)
		{
			var spot = new Spot()
			{
				BroadcastDate = broadcastDate,
				TimeBandSliceId = timeBandSliceId,
			};
			var _spot = await _spotService.CheckExistSpot(spot);
			var usedDuration = 0;
			if (_spot != null)
			{
				var __spot = await _spotService.Get(_spot.Id).FirstOrDefaultAsync();
				var spotbookings = __spot.SpotBookings;
				foreach (var item in spotbookings)
				{
					usedDuration += item.AnnexContractAsset.Content.BlockDuration;
				}
			}
			return Json(usedDuration);
		}
		[HttpGet]
		public async Task<IActionResult> GetUsedDurationByType(DateTime broadcastDate, Guid timeBandSliceId, int bookingTypeId)
		{
			var spot = new Spot()
			{
				BroadcastDate = broadcastDate,
				TimeBandSliceId = timeBandSliceId,
			};
			var _spot = await _spotService.CheckExistSpot(spot);
			var usedDuration = 0;
			if (_spot != null)
			{
				var __spot = await _spotService.Get(_spot.Id).FirstOrDefaultAsync();
				var spotbookings = __spot.SpotBookings.Where(t => t.AnnexContractAsset.AnnexContract.BookingTypeId == bookingTypeId);
				foreach (var item in spotbookings)
				{
					usedDuration += item.AnnexContractAsset.Content.BlockDuration;
				}
			}
			return Json(usedDuration);
		}
	}
}