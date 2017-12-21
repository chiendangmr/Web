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

namespace HD.TVAD.Web.Features.Manager.CustomerPartners
{
	[Area("Manager")]
	[Authorize]
	public class CustomerController : TVADController
	{
		private ICustomerPartnerService _customerPartnerService;
		private ICustomerService _customerService;
		private readonly ISpotBookingService _spotBookingService;
		public CustomerController(
			ICustomerPartnerService customerPartnerService,
			ICustomerService customerService,
			ISpotBookingService spotBookingService)
		{
			_customerPartnerService = customerPartnerService;
			_customerService = customerService;
			_spotBookingService = spotBookingService;
		}
		[HttpGet]
		[RequiresPermission(UserPermissions.ImportData_Customer)]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> GetAllCustomerAsync([DataSourceRequest]DataSourceRequest request)
		{
			var customers = _customerPartnerService.GetAll()
				.OrderBy(a => a.Code)
				.ToViewModel()
				.ToList();

			var dataSource = await customers.ToDataSourceResultAsync(request);

			foreach (CustomerViewModel customer in dataSource.Data)
			{
				if (!dataSource.Data.Cast<CustomerViewModel>().Any(a => a.Id == customer.ParentId))
				{
					customer.ParentId = null;
				}
			}
			return Json(dataSource);
		}

		[HttpGet]
		[RequiresPermission(UserPermissions.ImportData_Customer_CRUD)]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[RequiresPermission(UserPermissions.ImportData_Customer_CRUD)]
		public async Task<IActionResult> CreateAsync(CustomerCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();
				try
				{
					if (await _customerPartnerService.ExistCodeAsync(viewModel.Code))
						throw new Exception($"Exist code {viewModel.Code}");

					var result = await _customerPartnerService.Create(dataModel);

					return JsonResponse(result, ActionType.Create, dataModel.Id);
				}
				catch (Exception ex)
				{
					return JsonResponse(StatusType.ERROR, ex.Message);
				}
			}
			else
			{
				return JsonResponse(StatusType.ERROR, "Input not valid!");
			}
		}

		[HttpPost]
		[RequiresPermission(UserPermissions.ImportData_Customer_CRUD)]
		public async Task<IActionResult> CreateAPIAsync(CustomerCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();
				try
				{
					if (await _customerPartnerService.ExistCodeAsync(viewModel.Code))
						throw new Exception($"Exist code {viewModel.Code}");

					var result = await _customerPartnerService.Create(dataModel);

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
		[HttpGet]
		public async Task<IActionResult> DetailAsync(Guid id)
		{
			try
			{
				var result = await _customerPartnerService.Get(id).FirstOrDefaultAsync();

				var model = result.ToViewModel();

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpGet]
		[RequiresPermission(UserPermissions.ImportData_Customer_CRUD)]
		public async Task<IActionResult> EditAsync(Guid id)
		{
			try
			{
				var result = await _customerPartnerService.Get(id).FirstOrDefaultAsync();

				var model = result.ToViewModel();

				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		[RequiresPermission(UserPermissions.ImportData_Customer_CRUD)]
		public async Task<IActionResult> EditAsync(CustomerEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var customer = await _customerPartnerService.Get(viewModel.Id).FirstOrDefaultAsync();
					if (customer.Id == viewModel.ParentId)
						throw new Exception("Don't allow parent itself!");
					customer.EditDataModel(viewModel);

					var result = await _customerPartnerService.Update(customer);

					return JsonResponse(result, ActionType.Edit, customer.Id);
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
		[RequiresPermission(UserPermissions.ImportData_Customer_CRUD)]
		public async Task<IActionResult> EditAPIAsync(CustomerEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var customer = await _customerPartnerService.Get(viewModel.Id).FirstOrDefaultAsync();
					if (customer.Id == viewModel.ParentId)
						throw new Exception("Don't allow parent itself!");
					customer.EditDataModel(viewModel);

					var result = await _customerPartnerService.Update(customer);

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
		[HttpGet]
		[RequiresPermission(UserPermissions.ImportData_Customer_CRUD)]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			try
			{
				var result = await _customerPartnerService.Get(id).FirstOrDefaultAsync();

				var model = new DeleteViewModel()
				{
					Id = id,
					Name = result.Customer.Name
				};
				return View(model);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		[RequiresPermission(UserPermissions.ImportData_Customer_CRUD)]
		public async Task<IActionResult> DeleteAPIAsync(DeleteViewModel viewModel)
		{
			try
			{
				if (await _customerService.HasApprovedSpotAsync(viewModel.Id))
				{
					throw new Exception("This customer has approved spots!");
				}
				var resultGet = await _customerService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _customerService.Delete(resultGet);

				if (resultDelete > 0)
					return Json(new ResponseJsonResult()
					{
						Succeeded = true,
						Id = viewModel.Id,
						Message = "Successed",
					});
				else
					throw new Exception("Can not delete!");
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
		[RequiresPermission(UserPermissions.ImportData_Customer_CRUD)]
		public async Task<IActionResult> DeleteAsync(DeleteViewModel viewModel)
		{
			try
			{
				if (await _customerService.HasApprovedSpotAsync(viewModel.Id))
				{
					throw new Exception("This customer has approved spots!");
				}
				var resultGet = await _customerService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _customerService.Delete(resultGet);

				return JsonResponse(resultDelete, ActionType.Delete);
			}
			catch (Exception ex)
			{
				return JsonResponse(StatusType.ERROR, ex.Message);
			}
		}
		[HttpGet]
		public async Task<IActionResult> GetCustomerCodeAsync(Guid? parentId)
		{
			if (parentId.HasValue) // has parent
			{
				try
				{
					var parentCustomer = _customerPartnerService.Get(parentId.Value).FirstOrDefault();
					if (parentCustomer.InverseParent.Count > 0) // had children
					{
						var LastCustomers = parentCustomer.InverseParent
							.Select(a =>
							{
								var codeElement = a.Code.Split('.');
								var stringCode = "";
								var endElement = codeElement[codeElement.Length - 1];
								var intEndElement = int.Parse(endElement);
								var nextIntEndElement = intEndElement + 1;
								for (int i = 0; i < codeElement.Length; i++)
								{
									if (i == codeElement.Length - 1)
									{
										stringCode = stringCode + '.' + nextIntEndElement.ToString();
									}
									else
									{
										if (i == 0)
										{
											stringCode = stringCode + codeElement[i];
										}
										else
										{
											stringCode = stringCode + '.' + codeElement[i];
										}
									}
								}

								return new CodeViewModel
								{
									Id = a.Id,
									StringCode = stringCode,
									Code = intEndElement
								};
							}).OrderByDescending(a => a.Code).FirstOrDefault();

						return Json(LastCustomers.StringCode);
					}
					else // no children
					{
						return Json(parentCustomer.Code + ".1"); // start by 1
					}


				}
				catch (Exception ex)
				{

					return Json(1);
				}
			}
			else // no parent
			{
				try
				{
					var rootLastCustomers = await _customerPartnerService.GetAll()
						.Where(a => !a.Code.Contains('.')).Select(a => new CodeViewModel
						{
							Id = a.Id,
							Code = int.Parse(a.Code),
							StringCode = (int.Parse(a.Code) + 1).ToString(),
						}).OrderByDescending(a => a.Code).FirstOrDefaultAsync();

					return Json(rootLastCustomers.StringCode);

				}
				catch (Exception ex)
				{

					return Json(1);
				}

			}
		}

		[HttpGet]
		public async Task<IActionResult> CheckSpotBookingCountAsync(Guid id)
		{
			try
			{
				var result = await _spotBookingService.CheckBookingCountByCustomerAsync(id);	

				return Json(result);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}