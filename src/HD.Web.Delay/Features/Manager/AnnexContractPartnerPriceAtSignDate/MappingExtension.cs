using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.AnnexContractPartnerPriceAtSignDates
{
    public static class MappingExtension
	{
		public static AnnexContractPartnerPriceAtSignDateViewModel ToViewModel(this AnnexContractPartnerPriceAtSignDate item)
		{
			return new AnnexContractPartnerPriceAtSignDateViewModel()
			{
				Id = item.Id,
				AnnexContractCode = item.AnnexContract.AnnexContract.Code,
				AnnexContractId = item.AnnexContractId,
				EndDate = item.EndDate,
				StartDate = item.StartDate,
			};
		}
		public static IEnumerable<AnnexContractPartnerPriceAtSignDateViewModel> ToViewModel(this IQueryable<AnnexContractPartnerPriceAtSignDate> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static AnnexContractPartnerPriceAtSignDate ToDataModel(this AnnexContractPartnerPriceAtSignDateCreateViewModel viewModel)
		{
			return new AnnexContractPartnerPriceAtSignDate()
			{
				 Id = Guid.NewGuid(),
				AnnexContractId = viewModel.AnnexContractId,
				StartDate = viewModel.StartDate,
				EndDate = viewModel.EndDate
			};
		}
		public static void EditDataModel(this AnnexContractPartnerPriceAtSignDate annexContractPartnerPriceAtSignDate, AnnexContractPartnerPriceAtSignDateEditViewModel viewModel)
		{
			annexContractPartnerPriceAtSignDate.EndDate = viewModel.EndDate;
		//	annexContractPartnerPriceAtSignDate.AnnexContractId = viewModel.AnnexContractId;
		}
	}
}
