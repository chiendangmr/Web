using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Util;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.DiscountAnnexContracts
{
    public static class MappingExtension
	{
		public static DiscountAnnexContractViewModel ToViewModel(this DiscountAnnexContract item)
		{
			return new DiscountAnnexContractViewModel()
			{
				Id = item.Id,
				AnnexContractCode = item.AnnexContract.AnnexContract.Code,
				AnnexContractId = item.AnnexContractId,
				EndDate = item.EndDate,
				Rate = item.Rate.ToDisplayPercent(),
				StartDate = item.StartDate,
				Description = item.Description,
			};
		}
		public static IEnumerable<DiscountAnnexContractViewModel> ToViewModel(this IQueryable<DiscountAnnexContract> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static DiscountAnnexContract ToDataModel(this DiscountAnnexContractCreateViewModel viewModel,Guid annexContractId)
		{
			return new DiscountAnnexContract()
			{
				 Id = Guid.NewGuid(),
				AnnexContractId = annexContractId,
				Description = viewModel.Description,
				StartDate = viewModel.StartDate,
				EndDate = viewModel.EndDate,
				Rate = viewModel.Rate.ToPercent()
			};
		}
		public static void EditDataModel(this DiscountAnnexContract discountCustomer, DiscountAnnexContractEditViewModel viewModel)
		{
			var rate = Decimal.Parse(viewModel.Rate);

		//	discountCustomer.AnnexContractId = viewModel.AnnexContractId;
			discountCustomer.Description = viewModel.Description;
			discountCustomer.Rate = rate.ToPercent();
			discountCustomer.StartDate = viewModel.StartDate;
			discountCustomer.EndDate = viewModel.EndDate;

		}
	}
}
