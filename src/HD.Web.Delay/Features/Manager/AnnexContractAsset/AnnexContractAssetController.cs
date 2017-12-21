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

namespace HD.TVAD.Web.Features.Manager.AnnexContractAssets
{
	[Area("Manager")]
	[Authorize]
	public class AnnexContractAssetController : TVADController
	{
		private readonly IAnnexContractService _annexContractService;
		private readonly IContentService _contentService;
		private readonly IAnnexContractAssetService _annexContractAssetService;
		public AnnexContractAssetController(IAnnexContractService annexContractService,
			IAnnexContractAssetService annexContractAssetService,
			IContentService contentService) {
			_annexContractService = annexContractService;
			_annexContractAssetService = annexContractAssetService;
			_contentService = contentService;
		}
		[HttpGet]
		public IActionResult Index(Guid id)
		{
			var viewModel = new AnnexContractAssetIndexViewModel() {
				AnnexContractId = id,
			};
			return View(viewModel);
		}
		[HttpGet]
		public async Task<IActionResult> CreateAsync(Guid id)
		{
			var result = await _annexContractService.Get(id).FirstOrDefaultAsync();

			var viewModel = new AnnexContractAssetCreateViewModel()
			{
				AnnexContractId = id,
				BookingTypeId = result.BookingTypeId
			};
			return View(viewModel);
		}
		[HttpGet]
		public async Task<IActionResult> CreateAnnexContractAssetAsync(Guid id)
		{

			var result = await _annexContractService.Get(id).FirstOrDefaultAsync();

			var viewModel = new AnnexContractAssetCreateViewModel()
			{
				AnnexContractId = id,
				BookingTypeId = result.BookingTypeId,
				AnnexContractCode = result.Code
			};
			return View(viewModel);
		}
		[HttpPost]
		public async Task<IActionResult> CreateAsync(AnnexContractAssetCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var asset = await _contentService.FindByCodeAsync(viewModel.AssetCodeDisplay);
				if (asset == null)
					throw new Exception("Asset code not exist!");
				if (await _annexContractAssetService.ExistAsync(viewModel.AnnexContractId, asset.Id))
					throw new Exception("Already this TVC!");

					var dataModel = viewModel.ToDataModel();
						var annexContract = await _annexContractService.Get(viewModel.AnnexContractId).FirstOrDefaultAsync();
						annexContract.AnnexContractAssets.Add(dataModel);
						var result = await _annexContractService.Update(annexContract);

						return JsonResponse(result, ActionType.Create, dataModel.Id);
					}
				catch (Exception ex)
				{
					return JsonResponse(StatusType.ERROR, ex.Message);
				}
			}
			else
				return JsonResponse(StatusType.ERROR, ModelState);
		}
		[HttpPost]
		public async Task<IActionResult> CreateAPIAsync(AnnexContractAssetForNormalBookingCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var asset = await _contentService.FindByCodeAsync(viewModel.AssetCode);
					if (asset == null)
						throw new Exception("Asset code not exist!");
					if (!asset.IsApproved)
						throw new Exception("Asset not approved yet!");

					if (await _annexContractAssetService.ExistAsync(viewModel.AnnexContractId, asset.Id))
						throw new Exception("Already this TVC!");

					var dataModel = viewModel.ToDataModel();
					var annexContract = await _annexContractService.Get(viewModel.AnnexContractId).FirstOrDefaultAsync();
					annexContract.AnnexContractAssets.Add(dataModel);
					var result = await _annexContractService.Update(annexContract);

					return Json(new ResponseJsonResult()
					{
						Succeeded = true,
						Id = dataModel.Id,
						Data = viewModel,
						Message = "Created",
					});
				}
				catch (Exception ex)
				{
					return Json(new ResponseJsonResult()
					{
						Succeeded = false,
						Data = viewModel,
						Message = ex.Message
					});
				}
			}
			else
				return Json(new ResponseJsonResult()
				{
					Succeeded = false,
					Data = viewModel,
					Message = "Input not vail!",
				});
		}
		[HttpPost]
		public async Task<IActionResult> CreateAnnexContractAssetAsync(AnnexContractAssetCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var asset = await _contentService.FindByCodeAsync(viewModel.AssetCodeDisplay);
				if (asset != null)
				{
					viewModel.AssetId = asset.Id;
					var dateModel = viewModel.ToDataModel();
					try
					{
						var annexContract = await _annexContractService.Get(viewModel.AnnexContractId).FirstOrDefaultAsync();

						annexContract.AnnexContractAssets.Add(dateModel);
						var result = await _annexContractService.Update(annexContract);

						if (result > 0)
							return Redirect("/Manager/SpotBooking/IndexContract/" + viewModel.AnnexContractId.ToString());
						else
							return View(viewModel);
					}
					catch (Exception)
					{

						throw;
					}
				}
				else
				{
					ModelState.AddModelError("assetcode", "Asset code not exist");
					ViewBag.Message = "Asset code not exist";
					return View(viewModel);
				}


			}
			else
				return JsonResponse(StatusType.ERROR, ModelState);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllByAnnexContractIdAsync(DataSourceRequest request ,Guid annexContractId)
		{
			var annexContract = await _annexContractService.Get(annexContractId).FirstOrDefaultAsync();
			if (annexContract.AnnexContractAssets != null)
			{
				var annexContractAssets = annexContract.AnnexContractAssets
					.AsQueryable()
					.ToViewModel();
				var dataSource = await annexContractAssets.ToDataSourceResultAsync(request);
				return Json(dataSource);
			}
			else
			{
				throw new NullReferenceException();
			}
		}

		[HttpGet]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			try
			{
				var result = await _annexContractAssetService.Get(id).FirstOrDefaultAsync();

				var viewModel = new DeleteViewModel()
				{
					Id = result.Id,
					Name = result.Contents
				};
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
				if (await _annexContractAssetService.HasApprovedSpotAsync(viewModel.Id))
				{
					throw new Exception("This asset has approved spots!");
				}
				var resultGet = await _annexContractAssetService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _annexContractAssetService.Delete(resultGet);

				return JsonResponse(resultDelete, ActionType.Delete);
			}
			catch (Exception ex)
			{
				return JsonResponse(StatusType.ERROR, ex.Message);
			}
		}
		[HttpPost]
		public async Task<IActionResult> DeleteAPIAsync(DeleteViewModel viewModel)
		{
			try
			{
				if (await _annexContractAssetService.HasApprovedSpotAsync(viewModel.Id))
				{
					throw new Exception("This asset has approved spots!");
				}
				var resultGet = await _annexContractAssetService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _annexContractAssetService.Delete(resultGet);

				if (resultDelete > 0)
				{
					return Json(new ResponseJsonResult()
					{
						Succeeded = true,
						Id = viewModel.Id,
						Data = viewModel,
						Message = "Delete",
					});
				}
				else
				{
					throw new Exception("Can't delete");
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
		[HttpGet]
		public async Task<IActionResult> EditAsync(Guid id)
		{
			try
			{
				var result = await _annexContractAssetService.Get(id).FirstOrDefaultAsync();

				var viewModel = result.ToViewModel();

				return View(viewModel);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAsync(AnnexContractAssetEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var annexContractAsset = await _annexContractAssetService.Get(viewModel.Id).FirstOrDefaultAsync();

					annexContractAsset.EditDataModel(viewModel);

					var result = await _annexContractAssetService.Update(annexContractAsset);

					return JsonResponse(result, ActionType.Edit, annexContractAsset.Id);
				}
				catch (Exception)
				{
					throw;
				}
			}
			else
				return JsonResponse(StatusType.ERROR, ModelState);
		}
		[HttpPost]
		public async Task<IActionResult> EditAPIAsync(AnnexContractAssetEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var annexContractAsset = await _annexContractAssetService.Get(viewModel.Id).FirstOrDefaultAsync();

					annexContractAsset.EditDataModel(viewModel);

					var result = await _annexContractAssetService.Update(annexContractAsset);
					if (result > 0)
					{
						return Json(new ResponseJsonResult()
						{
							Succeeded = true,
							Id = viewModel.Id,
							Data = viewModel,
							Message = "Edited",
						});
					}
					else
					{
						throw new Exception("Can't edit");
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
					Data = ModelState,
					Message = "Input not vail!",
				});
		}
	}
}