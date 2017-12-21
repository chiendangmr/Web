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

namespace HD.TVAD.Web.Features.Manager.ProductGroups
{
	[Area("MAM")]
	[Authorize]
	public class ProductGroupController : TVADController
	{
		private IProductGroupService _productGroupService;
		public ProductGroupController(IProductGroupService productGroupService) {

			_productGroupService = productGroupService;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync([DataSourceRequest]DataSourceRequest request)
		{
			var productGroups = _productGroupService.GetAll()
				.ToViewModel();
			var dataSourceResult = await productGroups.ToDataSourceResultAsync(request);

			foreach (ProductGroupViewModel productGroup in dataSourceResult.Data)
			{
				if (!dataSourceResult.Data.Cast<ProductGroupViewModel>().Any(a => a.Id == productGroup.ParentId))
				{
					productGroup.ParentId = null;
				}
			}
			return Json(dataSourceResult);
		}

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
		public async Task<IActionResult> CreateAsync(ProductGroupCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dataModel = viewModel.ToDataModel();
				try
				{
					var result = await _productGroupService.Create(dataModel);

					return JsonResponse(result, ActionType.Create, dataModel.Id);
				}
				catch (Exception)
				{
					throw;
				}	
			}
			else
			{
				return Json(ModelState);
			}
		}

		[HttpGet]
		public async Task<IActionResult> DeleteAsync(Guid id)
		{
			try
			{
				var product = await _productGroupService.Get(id).FirstOrDefaultAsync();
				var viewModel = product.ToDeleteViewModel();

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
				var productGroup = await _productGroupService.Get(viewModel.Id).FirstOrDefaultAsync();
				var result = await _productGroupService.Delete(productGroup);

				return JsonResponse(result, ActionType.Delete);
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
				var product = await _productGroupService.Get(id).FirstOrDefaultAsync();
				var viewModel = product.ToViewModel();

				return View(viewModel);
			}
			catch (Exception)
			{

				throw;
			}
		}
		[HttpPost]
		public async Task<IActionResult> EditAsync(ProductGroupEditViewModel viewModel)
		{

			if (ModelState.IsValid)
			{
				try
				{
					var productGroup = await _productGroupService.Get(viewModel.Id).FirstOrDefaultAsync();
					productGroup.EditDataModel(viewModel);

					var result = await _productGroupService.Update(productGroup);
					return JsonResponse(result, ActionType.Edit, productGroup.Id);
				}
				catch (Exception)
				{
					throw;
				}
			}
			else
			{
				return Json(ModelState);
			}
		}
		[HttpGet]
		public async Task<IActionResult> GetProductGroupCodeAsync(Guid? parentId)
		{
			if (parentId.HasValue) // has parent
			{
				try
				{
					var parentProductGroup = _productGroupService.Get(parentId.Value).FirstOrDefault();
					if (parentProductGroup.InverseParent.Count > 0) // had children
					{
						var LastProductGroups = parentProductGroup.InverseParent
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

						return Json(LastProductGroups.StringCode);
					}
					else // no children
					{
						return Json(parentProductGroup.Code + ".1"); // start by 1
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
					var rootLastProductGroups = await _productGroupService.GetAll()
						.Where(a => !a.Code.Contains('.')).Select(a => new CodeViewModel
						{
							Id = a.Id,
							Code = int.Parse(a.Code),
							StringCode = (int.Parse(a.Code) + 1).ToString(),
						}).OrderByDescending(a => a.Code).FirstOrDefaultAsync();

					return Json(rootLastProductGroups.StringCode);

				}
				catch (Exception ex)
				{

					return Json(1);
				}

			}
		}
	}
}