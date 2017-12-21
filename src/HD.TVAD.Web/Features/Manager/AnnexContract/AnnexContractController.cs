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

namespace HD.TVAD.Web.Features.Manager
{
	[Area("Manager")]
	[Authorize]
	public class AnnexContractController : TVADController
	{
		private readonly IAnnexContractPartnerService _annexContractPartnerService;
		private readonly IAnnexContractService _annexContractService;
		private readonly IGetTypeService _getTypeService;
		private readonly ISpotBookingService _spotBookingService;
		public AnnexContractController(
			IGetTypeService getTypeService,
			IAnnexContractPartnerService annexContractPartnerService,
			IAnnexContractService annexContractService,
			ISpotBookingService spotBookingService)
		{
			_annexContractPartnerService = annexContractPartnerService;
			_getTypeService = getTypeService;
			_annexContractService = annexContractService;
			_spotBookingService = spotBookingService;
		}
		[HttpGet]
		public IActionResult Index(Guid id)
		{
			var model = new AnnexContractIndexViewModel() {
				CustomerId = id,
			};
			return View(model);
		}
		[HttpGet]
		public IActionResult NormalBooking(Guid id)
		{
			var model = new AnnexContractIndexViewModel()
			{
				CustomerId = id,
				BookingTypeId = BookingTypeEnum.Contract_Booking,
			};
			return View(model);
		}
		[HttpGet]
		public IActionResult BookingIn(Guid id)
		{
			var model = new AnnexContractIndexViewModel()
			{
				CustomerId = id,
				BookingTypeId = BookingTypeEnum.Contract_Sponsor_InProgram,
			};
			return View(model);
		}
		[HttpGet]
		public IActionResult BookingOut(Guid id)
		{
			var model = new AnnexContractIndexViewModel()
			{
				CustomerId = id,
				BookingTypeId = BookingTypeEnum.Contract_Sponsor_OutProgram,
			};
			return View(model);
		}
		[HttpGet]
		public IActionResult TrailerBooking(Guid id)
		{
			var model = new AnnexContractIndexViewModel()
			{
				CustomerId = id,
				BookingTypeId = BookingTypeEnum.Contract_Sponsor_Trailer,
			};
			return View(model);
		}
		[HttpGet]
		public IActionResult BenefitBooking(Guid id)
		{
			var model = new AnnexContractIndexViewModel()
			{
				CustomerId = id,
				BookingTypeId = BookingTypeEnum.Contract_Sponsor_Benefit,
			};
			return View(model);
		}
		[HttpGet]
		public async Task<IActionResult> GetAllAnnexContractAsync([DataSourceRequest]DataSourceRequest request,Guid? customerId,int bookingTypeId)
		{
			var annexContracts = _annexContractPartnerService.GetAllAsync(customerId, bookingTypeId)
				.ToQueryableViewModel();

			var dataSourceResult = await annexContracts.ToDataSourceResultAsync(request);

			return Json(dataSourceResult);
		}
		[HttpGet]
		public async Task<IActionResult> GetAnnexContractInMonthAsync(int month, BookingTypeEnum bookingType)
		{
			try
			{
				var annexContracts = (await _annexContractPartnerService.GetAllInMonthAsync(month, DateTime.Now.Year))
					.ToViewModel()
					.Where( a => a.BookingTypeId == bookingType)
					.OrderByDescending(a => a.ReceiveDate);

				return Json(annexContracts);

			}
			catch (Exception ex)
			{
				return Json(ex.Message);
			}
		}
		[HttpGet]
		public async Task<IActionResult> CreateAsync()
		{
			var code = await GenAnnexContractCodeAsync();
			var model = new AnnexContractViewModel()
			{
				ReceiveDate = DateTime.Today,
				Code = code.ToString(),
				SignDate = DateTime.Today,
			};

			return View(model);
		}
		[HttpGet]
		public async Task<IActionResult> CreateNormalBookingAsync()
		{
			var code = await GenAnnexContractCodeAsync();
			var model = new AnnexContractViewModel()
			{
				ReceiveDate = DateTime.Today,
				Code = code.ToString(),
				SignDate = DateTime.Today,
				BookingTypeId = BookingTypeEnum.Contract_Booking
			};

			return View(model);
		}
		[HttpGet]
		public async Task<IActionResult> CreateBookingInAsync()
		{
			var code = await GenAnnexContractCodeAsync();
			var model = new AnnexContractViewModel()
			{
				ReceiveDate = DateTime.Today,
				Code = code.ToString(),
				SignDate = DateTime.Today,
				BookingTypeId = BookingTypeEnum.Contract_Sponsor_InProgram
			};

			return View(model);
		}
		[HttpGet]
		public async Task<IActionResult> CreateBookingOutAsync()
		{
			var code = await GenAnnexContractCodeAsync();
			var model = new AnnexContractViewModel()
			{
				ReceiveDate = DateTime.Today,
				Code = code.ToString(),
				SignDate = DateTime.Today,
				BookingTypeId = BookingTypeEnum.Contract_Sponsor_OutProgram
			};

			return View(model);
		}
		[HttpGet]
		public async Task<IActionResult> CreateTrailerBookingAsync()
		{
			var code = await GenAnnexContractCodeAsync();
			var model = new AnnexContractViewModel()
			{
				ReceiveDate = DateTime.Today,
				Code = code.ToString(),
				SignDate = DateTime.Today,
				BookingTypeId = BookingTypeEnum.Contract_Sponsor_Trailer
			};

			return View(model);
		}
		[HttpGet]
		public async Task<IActionResult> CreateBenefitBookingAsync()
		{
			var code = await GenAnnexContractCodeAsync();
			var model = new AnnexContractViewModel()
			{
				ReceiveDate = DateTime.Today,
				Code = code.ToString(),
				SignDate = DateTime.Today,
				BookingTypeId = BookingTypeEnum.Contract_Sponsor_Benefit
			};

			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> CreateAsync(AnnexContractCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();				
				try
				{
					var result = await _annexContractPartnerService.Create(dataModel);
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
		public async Task<IActionResult> CreateContractAsync(Guid id)
		{
			var code = await GenAnnexContractCodeAsync();
			var model = new AnnexContractViewModel()
			{
				ReceiveDate = DateTime.Today,
				Code = code.ToString(),
				SignDate = DateTime.Today,
				CustomerId = id
			};

			return View(model);
		}
		[HttpGet]
		public async Task<IActionResult> CreateNormalBookingContractAsync(Guid id)
		{
			var code = await GenAnnexContractCodeAsync();
			var model = new AnnexContractViewModel()
			{
				ReceiveDate = DateTime.Today,
				Code = code.ToString(),
				SignDate = DateTime.Today,
				CustomerId = id,
				BookingTypeId = BookingTypeEnum.Contract_Booking,
			};

			return View(model);
		}
		[HttpGet]
		public async Task<IActionResult> CreateBookingInContractAsync(Guid id)
		{
			var code = await GenAnnexContractCodeAsync();
			var model = new AnnexContractViewModel()
			{
				ReceiveDate = DateTime.Today,
				Code = code.ToString(),
				SignDate = DateTime.Today,
				CustomerId = id,
				BookingTypeId = BookingTypeEnum.Contract_Sponsor_InProgram,
			};

			return View(model);
		}
		[HttpGet]
		public async Task<IActionResult> CreateBookingOutContractAsync(Guid id)
		{
			var code = await GenAnnexContractCodeAsync();
			var model = new AnnexContractViewModel()
			{
				ReceiveDate = DateTime.Today,
				Code = code.ToString(),
				SignDate = DateTime.Today,
				CustomerId = id,
				BookingTypeId = BookingTypeEnum.Contract_Sponsor_OutProgram,
			};

			return View(model);
		}
		[HttpGet]
		public async Task<IActionResult> CreateTrailerBookingContractAsync(Guid id)
		{
			var code = await GenAnnexContractCodeAsync();
			var model = new AnnexContractViewModel()
			{
				ReceiveDate = DateTime.Today,
				Code = code.ToString(),
				SignDate = DateTime.Today,
				CustomerId = id,
				BookingTypeId = BookingTypeEnum.Contract_Sponsor_Trailer,
			};

			return View(model);
		}
		[HttpGet]
		public async Task<IActionResult> CreateBenefitBookingContractAsync(Guid id)
		{
			var code = await GenAnnexContractCodeAsync();
			var model = new AnnexContractViewModel()
			{
				ReceiveDate = DateTime.Today,
				Code = code.ToString(),
				SignDate = DateTime.Today,
				CustomerId = id,
				BookingTypeId = BookingTypeEnum.Contract_Sponsor_Benefit,
			};

			return View(model);
		}
		private async Task<int> GenAnnexContractCodeAsync()
		{
			while (true)
			{
				var random = new Random();
				var code = random.Next(10000, 99999);
				var exsitCode = await _annexContractService.ExistCodeAsync(code.ToString());
				if (!exsitCode)
				{
					return await Task.FromResult(code);
				}
			}
		}
		[HttpPost]
		public async Task<IActionResult> CreateContractAsync(AnnexContractCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();
				try
				{
					var result = await _annexContractPartnerService.Create(dataModel);

					if (result > 0)
						return Redirect("/Manager/AnnexContractAsset/CreateAnnexContractAsset/" + dataModel.Id.ToString());
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
				return View(viewModel);
			}
		}
		[HttpPost]
		public async Task<IActionResult> CreateAnnexContractAPIAsync(AnnexContractCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				viewModel.Code = (await GenAnnexContractCodeAsync()).ToString();
				var dataModel = viewModel.ToDataModel();
				try
				{
					var result = await _annexContractPartnerService.Create(dataModel);

					if (result > 0)
						return Json(new ResponseJsonResult() {
							Succeeded = true,
							Id = dataModel.Id,
							Message = "Successed",
						});
					else
						throw new Exception("Can not create!");
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
			{
				return Json(new ResponseJsonResult()
				{
					Succeeded = false,
					Message = "Input not vaild!",
				});
			}
		}
		[HttpPost]
		public async Task<IActionResult> CreateAPIFromEditFormAsync(AnnexContractCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				viewModel.Code = (await GenAnnexContractCodeAsync()).ToString();
				var dataModel = viewModel.ToDataModelFromCreateFromEditForm();
				try
				{
					var result = await _annexContractPartnerService.Create(dataModel);

					if (result > 0)
						return Json(new ResponseJsonResult()
						{
							Succeeded = true,
							Id = dataModel.Id,
							Message = "Successed",
						});
					else
						throw new Exception("Can not create!");
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
			{
				return Json(new ResponseJsonResult()
				{
					Succeeded = false,
					Message = "Input not vaild!",
				});
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAnnexContractAPIAsync(AnnexContractEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var annexContract = await _annexContractPartnerService.Get(viewModel.Id).FirstOrDefaultAsync();

					annexContract.EditDataModel(viewModel);

					var result = await _annexContractPartnerService.Update(annexContract);

					if (result > 0)
						return Json(new ResponseJsonResult()
						{
							Succeeded = true,
							Id = viewModel.Id,
							Message = "Successed",
						});
					else
						throw new Exception("Can not edit!");
				}
				catch (Exception ex)
				{
					throw;
					//return Json(new ResponseJsonResult()
					//{
					//	Succeeded = false,
					//	Message = ex.Message,
					//});
				}
			}
			else
			{
				return Json(new ResponseJsonResult()
				{
					Succeeded = false,
					Message = "Input not vaild!",
				});
			}
		}
		[HttpGet]
		public async Task<IActionResult> FindByCodeAPIAsync(string code, BookingTypeEnum bookingType)
		{
			try
			{
				var annexContract = await _annexContractService.GetByCodeAsync(code);
				if (annexContract == null)
					throw new Exception($"Can't find contract by code {code}");
				var model = annexContract.ToViewModel();
				if (model.BookingTypeId != bookingType)
					throw new Exception($"Contract {code} is {model.BookingTypeId.GetDisplayName()}");
				return Json(new ResponseJsonResult()
				{
					Succeeded = true,
					Id = model.Id,
					Data = model,
					Message = "Successed",
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
		[HttpGet]
		public async Task<IActionResult> EditAsync(Guid id)
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
		[HttpPost]
		public async Task<IActionResult> EditAsync(AnnexContractEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var annexContract = await _annexContractPartnerService.Get(viewModel.Id).FirstOrDefaultAsync();
					annexContract.EditDataModel(viewModel);
					var resultUpdate = await _annexContractPartnerService.Update(annexContract);
					return JsonResponse(resultUpdate, ActionType.Edit, annexContract.Id);
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
		public async Task<IActionResult> ChangeToBookingOutAsync(ChangeToBookingOutViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var annexContract = await _annexContractPartnerService.Get(viewModel.Id).FirstOrDefaultAsync();
					annexContract.EditDataModel(viewModel);
					var resultUpdate = await _annexContractPartnerService.Update(annexContract);
					return JsonResponse(resultUpdate, $"Changed {annexContract.AnnexContract.Code}");
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
		public async Task<IActionResult> ChangeToBookingOutFromBookingInAsync(ChangeToBookingOutFromBookingInViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var annexContract = await _annexContractPartnerService.Get(viewModel.Id).FirstOrDefaultAsync();
					annexContract.EditDataModel(viewModel);
					var resultUpdate = await _annexContractPartnerService.Update(annexContract);
					return JsonResponse(resultUpdate, $"Changed {annexContract.AnnexContract.Code}");
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
		public async Task<IActionResult> ChangeToBookingInFromBookingOutAsync(ChangeToBookingInFromBookingOutViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var annexContract = await _annexContractPartnerService.Get(viewModel.Id).FirstOrDefaultAsync();
					annexContract.EditDataModel(viewModel);
					var resultUpdate = await _annexContractPartnerService.Update(annexContract);
					return JsonResponse(resultUpdate, $"Changed {annexContract.AnnexContract.Code}");
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
		public async Task<IActionResult> ChangeToNormalBookingInAsync(ChangeToNormalBookingViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var annexContract = await _annexContractPartnerService.Get(viewModel.Id).FirstOrDefaultAsync();
					annexContract.EditDataModel(viewModel);
					var resultUpdate = await _annexContractPartnerService.Update(annexContract);
					return JsonResponse(resultUpdate, $"Changed {annexContract.AnnexContract.Code}");
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
		public async Task<IActionResult> ChangeCustomerAsync(ChangeCustomerViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var annexContract = await _annexContractPartnerService.Get(viewModel.Id).FirstOrDefaultAsync();
					annexContract.EditDataModel(viewModel);
					var resultUpdate = await _annexContractPartnerService.Update(annexContract);
					return JsonResponse(resultUpdate, $"Changed {annexContract.AnnexContract.Code}", annexContract.Id);
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
				var result = await _annexContractPartnerService.Get(id).FirstOrDefaultAsync();

				var viewModel = new DeleteViewModel()
				{
					Id = result.Id,
					Name = result.AnnexContract.Code,
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
				if (await _annexContractService.HasApprovedSpotAsync(viewModel.Id))
				{
					throw new Exception("This contract has approved spots!");
				}

				var resultGet = await _annexContractService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _annexContractService.Delete(resultGet);

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
				if (await _annexContractService.HasApprovedSpotAsync(viewModel.Id))
				{
					throw new Exception("This contract has approved spots!");
				}

				var resultGet = await _annexContractService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _annexContractService.Delete(resultGet);
				if (resultDelete > 0)
				{
					return Json(new ResponseJsonResult()
					{
						Succeeded = true,
						Id = viewModel.Id,
						Message = "Deleted",
					});
				}
				else
					throw new Exception("Can not delete");

			}
			catch (Exception ex)
			{
				return Json(new ResponseJsonResult()
				{
					Succeeded = false,
					Id = viewModel.Id,
					Message = ex.Message,
				});
			}
		}
		[HttpGet]
		public async Task<IActionResult> GetRightAnnexContractTypeByBookingTypeId(int bookingTypeId)
		{
			try
			{
				var annexContractTypes  = await _getTypeService.GetAnnexContractTypes()
					.Where(a => a.BookingTypeId == bookingTypeId)
					.ToListAsync();

				if (annexContractTypes.Count == 1) // just one
				{
					var returnResult = new ContentResult<AnnexContractTypeViewModel>()
					{
						Count = annexContractTypes.Count,
						Data = annexContractTypes.Select(a => new AnnexContractTypeViewModel()
						{
							BookingTypeId = a.BookingTypeId,
							Description = a.Description,
							Id = a.Id,
							Name = a.Name,
							ParentId = a.ParentId,
						}).ToList(),

					};
					return Json(returnResult);
				}
				else
				{
					if (annexContractTypes.Count == 0) // can't find, maybe booking type id of parent
					{
						var bookingType = await _getTypeService.GetBookingTypes()
							.Where(a => a.Id == bookingTypeId)
							.FirstOrDefaultAsync();

						if (bookingType != null)
						{
							var _annexContractTypes = await _getTypeService.GetAnnexContractTypes()
								.Where(a => a.BookingTypeId == bookingType.ParentId)
								.ToListAsync();
							if (_annexContractTypes.Count >= 1) 
							{
								var returnResult = new ContentResult<AnnexContractTypeViewModel>()
								{
									Count = _annexContractTypes.Count,
									Data = _annexContractTypes.Select(a => new AnnexContractTypeViewModel()
									{
										BookingTypeId = a.BookingTypeId,
										Description = a.Description,
										Id = a.Id,
										Name = a.Name,
										ParentId = a.ParentId,
									}).ToList(),

								};
								return Json(returnResult);
							}
						}
					}
				}
				return NotFound();
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpGet]
		public async Task<IActionResult> CheckSpotBookingCountAsync(Guid id)
		{
			try
			{
				var result = await _spotBookingService.CheckBookingCountByAnnexContractAsync(id);

				return Json(result);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}