using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using HD.TVAD.Web.Services;
using HD.TVAD.Web.Models;
using HD.TVAD.ApplicationCore.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using HD.TVAD.Web.Features.Manager;
using HD.TVAD.Web.Infrastructure;
using HD.TVAD.Web.StartData;

namespace HD.TVAD.Web.Features.Manager.SponsorPrograms
{
	[Area("Manager")]
	[Authorize]
	public class SponsorProgramController : TVADController
	{
		public ISponsorProgramService _sponsorProgramService;

		public SponsorProgramController(ISponsorProgramService sponsorProgramService) {

			_sponsorProgramService = sponsorProgramService;
		}
		[RequiresPermission(UserPermissions.ImportData_SponsorProgram)]
		public async Task<IActionResult> Index() {
			return View();
		}
		[HttpGet]
		[RequiresPermission(UserPermissions.ImportData_SponsorProgram)]
		public async Task<IActionResult> GetAllSponsorProgram([DataSourceRequest]DataSourceRequest request)
		{
			try
			{
				var sponsorPrograms = _sponsorProgramService.GetAll()
					.OrderBy(s => s.Code)
					.ToViewModel();

				var dataSource = await sponsorPrograms.ToDataSourceResultAsync(request);

				foreach (SponsorProgramViewModel sponsorProgram in dataSource.Data)
				{
					if (!dataSource.Data.Cast<SponsorProgramViewModel>().Any(a => a.Id == sponsorProgram.ParentId))
					{
						sponsorProgram.ParentId = null;
					}
				}

				return Json(dataSource);

			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpGet]
		[RequiresPermission(UserPermissions.ImportData_SponsorProgram_CRUD)]
		public IActionResult Create()
		{

			return View();
		}
		[HttpPost]
		[RequiresPermission(UserPermissions.ImportData_SponsorProgram_CRUD)]
		public async Task<IActionResult> CreateAsync(SponsorProgramCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();
				try
				{
					if (await _sponsorProgramService.ExistCode(viewModel.Code))
					{
						throw new Exception($"Exist code {viewModel.Code}");
					}
					var result = await _sponsorProgramService.Create(dataModel);

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
		[RequiresPermission(UserPermissions.ImportData_SponsorProgram_CRUD)]
		public async Task<IActionResult> CreateAPIAsync(SponsorProgramCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();
				try
				{
					if (await _sponsorProgramService.ExistCode(viewModel.Code))
					{
						throw new Exception($"Exist code {viewModel.Code}");
					}
					var result = await _sponsorProgramService.Create(dataModel);

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
		[RequiresPermission(UserPermissions.ImportData_SponsorProgram_CRUD)]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			try
			{
				var result = await _sponsorProgramService.Get(id).FirstOrDefaultAsync();

				var viewModel = new DeleteViewModel()
				{
					Id = result.Id,
					Name = result.Name
				};
				return View(viewModel);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpPost]
		[RequiresPermission(UserPermissions.ImportData_SponsorProgram_CRUD)]
		public async Task<IActionResult> DeleteAsync(DeleteViewModel viewModel)
		{
			try
			{
				var resultGet = await _sponsorProgramService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _sponsorProgramService.Delete(resultGet);

				return JsonResponse(resultDelete, ActionType.Delete);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpPost]
		[RequiresPermission(UserPermissions.ImportData_SponsorProgram_CRUD)]
		public async Task<IActionResult> DeleteAPIAsync(DeleteViewModel viewModel)
		{
			try
			{
				var resultGet = await _sponsorProgramService.Get(viewModel.Id).FirstOrDefaultAsync();

				var resultDelete = await _sponsorProgramService.Delete(resultGet);

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
		[HttpGet]
		public async Task<IActionResult> DetailAsync(Guid id)
		{
			try
			{
				var result = await _sponsorProgramService.Get(id).FirstOrDefaultAsync();

				var viewModel = result.ToViewModel();

				return View(viewModel);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpGet]
		[RequiresPermission(UserPermissions.ImportData_SponsorProgram_CRUD)]
		public async Task<IActionResult> EditAsync(Guid id)
		{
			try
			{
				var result = await _sponsorProgramService.Get(id).FirstOrDefaultAsync();

				var viewModel = result.ToViewModel();

				return View(viewModel);
			}
			catch (Exception)
			{
				throw;
			}
		}
		[HttpPost]
		[RequiresPermission(UserPermissions.ImportData_SponsorProgram_CRUD)]
		public async Task<IActionResult> EditAsync(SponsorProgramEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var sponsorProgram = await _sponsorProgramService.Get(viewModel.Id).FirstOrDefaultAsync();
					if (sponsorProgram.Id == viewModel.ParentId)
						throw new Exception("Don't allow parent itself!");
					if (sponsorProgram.Code != viewModel.Code)
					{
						if (await _sponsorProgramService.ExistCode(viewModel.Code))
							throw new Exception($"Exist code {viewModel.Code}");
					}

					sponsorProgram.EditDataModel(viewModel);

					var resultUpdate  = await _sponsorProgramService.Update(sponsorProgram);

					return JsonResponse(resultUpdate, ActionType.Edit, sponsorProgram.Id);
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
		[RequiresPermission(UserPermissions.ImportData_SponsorProgram_CRUD)]
		public async Task<IActionResult> EditAPIAsync(SponsorProgramEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var sponsorProgram = await _sponsorProgramService.Get(viewModel.Id).FirstOrDefaultAsync();
					if (sponsorProgram.Id == viewModel.ParentId)
						throw new Exception("Don't allow parent itself!");
					if (sponsorProgram.Code != viewModel.Code)
					{
						if (await _sponsorProgramService.ExistCode(viewModel.Code))
							throw new Exception($"Exist code {viewModel.Code}");
					}

					sponsorProgram.EditDataModel(viewModel);

					var resultUpdate = await _sponsorProgramService.Update(sponsorProgram);

					if (resultUpdate > 0)
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
				return Json(new ResponseJsonResult()
				{
					Succeeded = false,
					Message = "Input not vaild!",
				});

		}
		[HttpGet]
		public async Task<IActionResult> GetProgramCodeAsync(Guid? parentId)
		{
			if (parentId.HasValue) // has parent
			{
				try
				{
					var parentProgram = _sponsorProgramService.Get(parentId.Value).FirstOrDefault();
					if (parentProgram.InverseParent.Count > 0) // had children
					{
						var LastCustomers = parentProgram.InverseParent
							.Select(a => {
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
						return Json(parentProgram.Code + ".1"); // start by 1
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
					var rootLastProgram = await _sponsorProgramService.GetAll()
						.Where(a => !a.Code.Contains('.')).Select(a => new CodeViewModel
						{
							Id = a.Id,
							Code = int.Parse(a.Code),
							StringCode = (int.Parse(a.Code) + 1).ToString(),
						}).OrderByDescending(a => a.Code).FirstOrDefaultAsync();

					return Json(rootLastProgram.StringCode);

				}
				catch (Exception ex)
				{

					return Json(1);
				}

			}
		}

		[HttpGet]
		public async Task<IActionResult> GetDefaultAnnexContractTypeOfSponsorProgram(Guid sponsorProgramId)
		{
			try
			{
				if (!sponsorProgramId.Equals(Guid.Empty))
				{
					var sponsorProgram = await _sponsorProgramService.Get(sponsorProgramId).FirstOrDefaultAsync();

					if (sponsorProgram.DefaultContractTypeId.HasValue)
					{
						return Json(sponsorProgram.DefaultContractTypeId);
					}
				}
				return Json(0);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}