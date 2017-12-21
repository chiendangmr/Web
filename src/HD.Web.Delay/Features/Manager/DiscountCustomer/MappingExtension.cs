using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Util;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.DiscountCustomers
{
    public static class MappingExtension
	{
		public static DiscountCustomerViewModel ToViewModel(this DiscountCustomer item)
		{
			return new DiscountCustomerViewModel()
			{
				Id = item.Id,
				CustomerCode = item.Customer.CustomerPartners.Code,
				CustomerId = item.CustomerId,
				CustomerName = $"{item.Customer.CustomerPartners.Code} - {item.Customer.Name}",
				EndDate = item.EndDate,
				Rate = item.Rate.ToDisplayPercent(),
				StartDate = item.StartDate,
				Description = item.Description,
			};
		}
		public static IEnumerable<DiscountCustomerViewModel> ToViewModel(this IQueryable<DiscountCustomer> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static DiscountCustomer ToDataModel(this DiscountCustomerCreateViewModel viewModel)
		{
			return new DiscountCustomer()
			{
				 Id = Guid.NewGuid(),
				CustomerId = viewModel.CustomerId,
				Description = viewModel.Description,
				StartDate = viewModel.StartDate,
				EndDate = viewModel.EndDate,
				Rate = viewModel.Rate.ToPercent()
			};
		}
		public static void EditDataModel(this DiscountCustomer discountCustomer, DiscountCustomerEditViewModel viewModel)
		{
			var rate = Decimal.Parse(viewModel.Rate);
			
			discountCustomer.Description = viewModel.Description;
			discountCustomer.Rate = rate.ToPercent();
			discountCustomer.StartDate = viewModel.StartDate;
			discountCustomer.EndDate = viewModel.EndDate;
		}
	}
}
