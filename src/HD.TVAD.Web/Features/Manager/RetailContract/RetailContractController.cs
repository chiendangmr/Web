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

namespace HD.TVAD.Web.Features.Manager.RetailContracts
{
	[Area("Manager")]
	[Authorize]
	[RequiresPermission(UserPermissions.ManagerSystem_RetaiBooking)]
	public class RetailContractController : TVADController
	{
		private readonly IAnnexContractService _annexContractService;
		private IRetailContractService _retailContractService;
		private IRetailCustomerService _retailCustomerService;
		public RetailContractController(
			IRetailContractService retailContractService,
			IAnnexContractService annexContractService,
			IRetailCustomerService retailCustomerService)
		{
			_retailContractService = retailContractService;
			_annexContractService = annexContractService;
			_retailCustomerService = retailCustomerService;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync([DataSourceRequest]DataSourceRequest request)
		{
			var contracts = _retailContractService.GetAll()
				.ToViewModel()
				.OrderByDescending(a => a.ReceiveDate);

			var result = await contracts.ToDataSourceResultAsync(request);
			return Json(result);
		}

		[HttpGet]
		public async Task<IActionResult> CreateAsync()
		{
			var code = await GenAnnexContractCodeAsync();

			var viewModel = new RetailContractCreateModalViewModel()
			{
				ReceiveDate = DateTime.Today,
				Code = code.ToString(),
			};
			return View(viewModel);
		}

		[HttpGet]
		public async Task<IActionResult> CreateContractAsync(Guid id)
		{
			var code = await GenAnnexContractCodeAsync();

			var viewModel = new RetailContractCreateViewModel()
			{
				CustomerId = id,
				ReceiveDate = DateTime.Today,
				Code = code.ToString(),
			};
			return View(viewModel);
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
		public async Task<IActionResult> CreateAsync(RetailContractCreateModalViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var customerDataModel = new RetailCustomer()
					{
						Id = Guid.NewGuid(),
						Customer = new Customer()
						{
							Name = viewModel.CustomerName,
							Address = viewModel.CustomerAddress,
						},

					};
					var createCustomerResult = await _retailCustomerService.Create(customerDataModel);
					if (createCustomerResult > 0)
					{
						var dataModel = viewModel.ToDataModel(customerDataModel.Id);

			//			dataModel.AnnexContract.Code = (await GenAnnexContractCodeAsync()).ToString();

						var result = await _retailContractService.Create(dataModel);

						return JsonResponse(result, ActionType.Create, dataModel.Id);
					}
					throw new Exception("Can't create customer!");
				}
				catch (Exception ex)
				{
					return JsonResponse(StatusType.ERROR, ex.Message);
				}	
			}
			else
			{
				return Json(ModelState);
			}
		}
		[HttpPost]
		public async Task<IActionResult> CreateAPIAsync(RetailContractForAPICreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{

				try
				{
					var customerDataModel = new RetailCustomer()
					{
						Id = Guid.NewGuid(),
						Customer = new Customer() {
							Name = viewModel.CustomerName,
							Address = viewModel.CustomerAddress,
						},
					
					};
					var createCustomerResult = await _retailCustomerService.Create(customerDataModel);
					if (createCustomerResult > 0)
					{
						var dataModel = viewModel.ToDataModel(customerDataModel.Id);

						dataModel.AnnexContract.Code = (await GenAnnexContractCodeAsync()).ToString();

						var result = await _retailContractService.Create(dataModel);

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
					throw new Exception("Can't create customer!");
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
					Data = ModelState,
					Message = "Input not vaild!",
				});
			}
		}
		[HttpPost]
		public async Task<IActionResult> CreateFromEditFormAPIAsync(RetailContractForAPIEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{

				try
				{
					var customerDataModel = new RetailCustomer()
					{
						Id = Guid.NewGuid(),
						Customer = new Customer()
						{
							Name = "",
						//	Address = viewModel.CustomerAddress,
						},

					};
					var createCustomerResult = await _retailCustomerService.Create(customerDataModel);
					if (createCustomerResult > 0)
					{
						var dataModel = viewModel.ToDataModel(customerDataModel.Id);

						dataModel.AnnexContract.Code = (await GenAnnexContractCodeAsync()).ToString();

						var result = await _retailContractService.Create(dataModel);

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
					throw new Exception("Can't create customer!");
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
					Data = ModelState,
					Message = "Input not vaild!",
				});
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAPIAsync(RetailContractForAPIEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{

				try
				{

					var retailCustomer = await _retailCustomerService.Get(viewModel.CustomerId).FirstOrDefaultAsync();
					retailCustomer.Customer.Name = viewModel.CustomerName;
					retailCustomer.Customer.Address = viewModel.CustomerAddress;
					var updateRetailCustomerResult = await _retailCustomerService.Update(retailCustomer);
					if (updateRetailCustomerResult >= 0)
					{
						var retailContract = await _retailContractService.Get(viewModel.Id).FirstOrDefaultAsync();
						retailContract.AnnexContract.Code = viewModel.Code;
						retailContract.AnnexContract.ReceiveDate = viewModel.ReceiveDate;

						var result = await _retailContractService.Update(retailContract);
						if (result >= 0)
							return Json(new ResponseJsonResult()
							{
								Succeeded = true,
								Id = retailContract.Id,
								Message = "Successed",
							});
						else
							throw new Exception("Can not update!");
					}
					throw new Exception("Can't update customer!");
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
					Data = ModelState,
					Message = "Input not vaild!",
				});
			}
		}
		[HttpPost]
		public async Task<IActionResult> CreateContractAsync(RetailContractCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();
				try
				{
					var result = await _retailContractService.Create(dataModel);

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

		[HttpGet]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			try
			{
				var result = await _retailContractService.Get(id).FirstOrDefaultAsync();

				var viewModel = new DeleteViewModel()
				{
					Id = result.Id,
					Name = result.AnnexContract.Code
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

		[HttpGet]
		public async Task<IActionResult> EditAsync(Guid id)
		{
			try
			{
				var result = await _retailContractService.Get(id).FirstOrDefaultAsync();

				var model = result.ToViewModel();

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAsync(RetailContractViewModel viewModel)
		{
			try
			{
				var contract = await _retailContractService.Get(viewModel.Id).FirstOrDefaultAsync();
				contract.EditDataModel(viewModel);

				var resultUpdate = await _retailContractService.Update(contract);

				return JsonResponse(resultUpdate, ActionType.Edit, contract.Id);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}