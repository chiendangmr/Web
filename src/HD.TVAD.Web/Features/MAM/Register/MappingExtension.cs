using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.Registers
{
    public static class MappingExtension
	{
		public static RegisterViewModel ToViewModel(this Register item)
		{
			return new RegisterViewModel()
			{
				Id = item.Id,
				Description = item.Description,
				Name = item.Name,
				Code = item.Code,
			};
		}
		public static IEnumerable<RegisterViewModel> ToViewModel(this IQueryable<Register> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static DeleteViewModel ToDeleteViewModel(this Register item)
		{
			return new DeleteViewModel()
			{
				Id = item.Id,
				Name = item.Name.ToString(),
			};
		}
		public static Register ToDataModel(this RegisterCreateViewModel viewModel)
		{
			return new Register()
			{
				 Id = Guid.NewGuid(),
				Description = viewModel.Description,
				Name = viewModel.Name,
				Code = viewModel.Code,
			};
		}
		public static void EditDataModel(this Register register, RegisterEditViewModel viewModel)
		{
			register.Name = viewModel.Name;
        //    register.Code = viewModel.Code;
			register.Description = viewModel.Description;
		}
	}
}
