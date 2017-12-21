using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.RetailCustomers
{
    public static class MappingExtension
	{
		public static RetailCustomerViewModel ToViewModel(this RetailCustomer item)
		{
			return new RetailCustomerViewModel()
			{
				Id = item.Id,
				Address = item.Customer.Address,
				Name = item.Customer.Name,
				TypeId = item.Customer.TypeId,
			};
		}
		public static IEnumerable<RetailCustomerViewModel> ToViewModel(this IQueryable<RetailCustomer> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static RetailCustomer ToDataModel(this RetailCustomerCreateViewModel item)
		{
			return new RetailCustomer()
			{
				 Id = Guid.NewGuid(),
				 Customer = new Customer() {
					 Address = item.Address,
					 Name = item.Name,
					 TypeId = item.TypeId,					 
				 }
			};
		}
		public static void EditDataModel(this RetailCustomer item, RetailCustomerEditViewModel viewModel)
		{
			item.Customer.Address = viewModel.Address;
			item.Customer.Name = viewModel.Name;
		//	item.Customer.TypeId = viewModel.TypeId;			
		}
	}
}
