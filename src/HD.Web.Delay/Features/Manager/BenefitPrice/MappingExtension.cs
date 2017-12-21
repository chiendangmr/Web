using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.BenefitPrices
{
	public static class MappingExtension
	{
		public static BenefitPriceViewModel ToViewModel(this BenefitPrice item)
		{
			return new BenefitPriceViewModel()
			{
				Id = item.Id,
				Price = item.Price,
				StartDate = item.StartDate,
				BenefitTypeId = item.BenefitTypeId,
				BenefitTypeCode = item.BenefitType.Code,
				SponsorProgramIds = item.BenefitPriceSponsorPrograms.Select(a => a.SponsorProgramId),
				TimeBandIds = item.BenefitPriceTimeBands.Select(a => a.TimeBandId),
			};
		}
		public static IEnumerable<BenefitPriceViewModel> ToViewModel(this IQueryable<BenefitPrice> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static BenefitPrice ToDataModel(this BenefitPriceCreateViewModel viewModel)
		{
			var benefitPriceId = Guid.NewGuid();
			var benefitPriceTimeBands = new List<BenefitPriceTimeBand>();
			var benefitPriceSponsorPrograms = new List<BenefitPriceSponsorProgram>();
			if (viewModel.TimeBandIds != null)
			{
				foreach (var timeBandId in viewModel.TimeBandIds)
				{
					benefitPriceTimeBands.Add(new BenefitPriceTimeBand()
					{
						BenefitPriceId = benefitPriceId,
						TimeBandId = timeBandId
					});
				}

			}
			if (viewModel.SponsorProgramIds != null)
			{
				foreach (var sponsorProgramId in viewModel.SponsorProgramIds)
				{
					benefitPriceSponsorPrograms.Add(new BenefitPriceSponsorProgram()
					{
						BenefitPriceId = benefitPriceId,
						SponsorProgramId = sponsorProgramId
					});
				}

			}
			return new BenefitPrice()
			{
				Id = benefitPriceId,
				Price = viewModel.Price,
				StartDate = viewModel.StartDate,
				BenefitTypeId = viewModel.BenefitTypeId,
				BenefitPriceTimeBands = benefitPriceTimeBands,
				BenefitPriceSponsorPrograms = benefitPriceSponsorPrograms,
			};
		}
		public static void EditDataModel(this BenefitPrice item, BenefitPriceEditViewModel viewModel)
		{
			item.Price = viewModel.Price;
			item.StartDate = viewModel.StartDate;
		}
	}
}
