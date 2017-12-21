using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.SponsorPrograms
{
    public static class MappingExtension
	{
		public static SponsorProgramViewModel ToViewModel(this SponsorProgram item)
		{
			return new SponsorProgramViewModel()
			{
				Id = item.Id,
				Name = item.Name,
				Code = item.Code,
				EndDate = item.EndDate,
				ParentId = item.ParentId,
				Description = item.Description,
				DefaultContractTypeId = item.DefaultContractTypeId,
				DefaultContractTypeName = item.AnnexContractType != null ? item.AnnexContractType.Name : "",
			};
		}
		public static IEnumerable<SponsorProgramViewModel> ToViewModel(this IQueryable<SponsorProgram> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static SponsorProgram ToDataModel(this SponsorProgramCreateViewModel viewModel)
		{
			return new SponsorProgram()
			{
				Code = viewModel.Code,
				Description = viewModel.Description,
				EndDate = viewModel.EndDate,
				Name = viewModel.Name,
				ParentId = viewModel.ParentId,
				DefaultContractTypeId = viewModel.DefaultContractTypeId,
			};
		}
		public static void EditDataModel(this SponsorProgram sponsorProgram, SponsorProgramEditViewModel viewModel)
		{
			sponsorProgram.ParentId = viewModel.ParentId;
			sponsorProgram.Name = viewModel.Name;
			sponsorProgram.Code = viewModel.Code;
			sponsorProgram.EndDate = viewModel.EndDate;
			sponsorProgram.Description = viewModel.Description;
			sponsorProgram.DefaultContractTypeId = viewModel.DefaultContractTypeId;
		}
	}
}
