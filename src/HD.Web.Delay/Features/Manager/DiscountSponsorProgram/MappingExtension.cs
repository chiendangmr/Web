using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Util;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.DiscountSponsorPrograms
{
    public static class MappingExtension
	{
		public static DiscountSponsorProgramViewModel ToViewModel(this DiscountSponsorProgram item)
		{
			return new DiscountSponsorProgramViewModel()
			{
				Id = item.Id,
				Description = item.Description,
				EndDate = item.EndDate,
				ProgramId = item.ProgramId,
				Rate = item.Rate.ToDisplayPercent(),
				StartDate = item.StartDate,
				ProgramName = item.Program.AnnexContractType != null ?
						$"{item.Program.Code} - {item.Program.Name} - {item.Program.AnnexContractType.Name}"
						: $"{item.Program.Code} - {item.Program.Name} - ",
			};
		}
		public static IEnumerable<DiscountSponsorProgramViewModel> ToViewModel(this IQueryable<DiscountSponsorProgram> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static DiscountSponsorProgram ToDataModel(this DiscountSponsorProgramCreateViewModel viewModel)
		{
			return new DiscountSponsorProgram()
			{
				 Id = Guid.NewGuid(),
				ProgramId = viewModel.ProgramId,
				Description = viewModel.Description,
				StartDate = viewModel.StartDate,
				EndDate = viewModel.EndDate,
				Rate = viewModel.Rate.ToPercent()
			};
		}
		public static void EditDataModel(this DiscountSponsorProgram discountSponsorProgram, DiscountSponsorProgramEditViewModel viewModel)
		{
			var rate = Decimal.Parse(viewModel.Rate);

		//	discountSponsorProgram.ProgramId = viewModel.ProgramId;
			discountSponsorProgram.Description = viewModel.Description;
			discountSponsorProgram.Rate = rate.ToPercent();
			discountSponsorProgram.StartDate = viewModel.StartDate;
			discountSponsorProgram.EndDate = viewModel.EndDate;
		}
	}
}
