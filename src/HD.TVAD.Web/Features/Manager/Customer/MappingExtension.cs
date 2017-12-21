using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.CustomerPartners
{
    public static class MappingExtension
	{
		public static CustomerViewModel ToViewModel(this CustomerPartner item)
		{
			return new CustomerViewModel()
			{
				Id = item.Id,
				AccountNumber = item.AccountNumber,
				Address = item.Customer.Address,
				Code = item.Code,
				FaxNumber = item.FaxNumber,
				Name = item.Customer.Name,
				ParentId = item.ParentId,
				PhoneNumber = item.PhoneNumber,
				PositionOfRepresentivePerson = item.PositionOfRepresentivePerson,
				RepresentivePerson = item.RepresentivePerson,
				TaxNumber = item.TaxNumber,
				TypeId = item.Customer.TypeId,
				TypeName = item.Customer.Type.Name,				
			};
		}
		public static IEnumerable<CustomerViewModel> ToViewModel(this IQueryable<CustomerPartner> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static CustomerPartner ToDataModel(this CustomerCreateViewModel item)
		{
			return new CustomerPartner()
			{
				 Id = Guid.NewGuid(),
				 AccountNumber = item.AccountNumber,
				 Code = item.Code,
				 FaxNumber = item.FaxNumber,
				 ParentId = item.ParentId,
				 PhoneNumber = item.PhoneNumber,
				 PositionOfRepresentivePerson = item.PositionOfRepresentivePerson,
				 RepresentivePerson = item.RepresentivePerson,
				 TaxNumber = item.TaxNumber,
				 Customer = new Customer() {
					 Address = item.Address,
					 Name = item.Name,
					 TypeId = item.TypeId,					 
				 }
			};
		}
		public static void EditDataModel(this CustomerPartner item, CustomerEditViewModel viewModel)
		{
			item.AccountNumber = viewModel.AccountNumber;
			item.Code = viewModel.Code;
			item.PhoneNumber = viewModel.PhoneNumber;
			item.AccountNumber = viewModel.AccountNumber;
			item.FaxNumber = viewModel.FaxNumber;
			item.TaxNumber = viewModel.TaxNumber;
			item.ParentId = viewModel.ParentId;
			item.PhoneNumber = viewModel.PhoneNumber;
			item.PositionOfRepresentivePerson = viewModel.PositionOfRepresentivePerson;
			item.RepresentivePerson = viewModel.RepresentivePerson;
			item.Customer.Address = viewModel.Address;
			item.Customer.Name = viewModel.Name;
			item.Customer.TypeId = viewModel.TypeId;
		}
	}
}
