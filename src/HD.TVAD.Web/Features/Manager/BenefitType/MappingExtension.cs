using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Entities.Price;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.BenefitTypes
{
	public static class MappingExtension
	{
		public static BenefitTypeViewModel ToViewModel(this BenefitType item)
		{
			return new BenefitTypeViewModel()
			{
				Id = item.Id,
				Code = item.Code,
				Name = item.TypeDetail.Name,
				Description = item.Description
			};
		}
		public static IEnumerable<BenefitTypeViewModel> ToViewModel(this IQueryable<BenefitType> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static BenefitType ToDataModel(this BenefitTypeCreateViewModel viewModel)
		{
			return new BenefitType()
			{
				Id = Guid.NewGuid(),
				Code = viewModel.Code,
				Description = viewModel.Description,
				TypeDetail = new TypeDetail()
				{
					Name = viewModel.Name,
					TypeId = (int)PriceTypeEnum.Benefit,
				}
			};
		}
		public static void EditDataModel(this BenefitType benefitType, BenefitTypeEditViewModel viewModel)
		{
		//	benefitType.Code = viewModel.Code;
			benefitType.Description = viewModel.Description;
			benefitType.TypeDetail.Name = viewModel.Name;
		}
	}
}
