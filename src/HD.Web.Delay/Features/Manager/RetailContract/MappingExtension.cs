using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.RetailContracts
{
    public static class MappingExtension
	{
		public static RetailContractViewModel ToViewModel(this RetailContract item)
		{
			return new RetailContractViewModel()
			{
				AnnexContractTypeId = item.AnnexContract.AnnexContractTypeId,
				BookingTypeId = item.AnnexContract.BookingTypeId,
				Code = item.AnnexContract.Code,
				ContractId = item.AnnexContract.ContractId,
				CustomerId = item.AnnexContract.CustomerId,
				CustomerName = item.AnnexContract.Customer.Name,
				CustomerAddress = item.AnnexContract.Customer.Address,
				Id = item.Id,
				ReceiveDate = item.AnnexContract.ReceiveDate,
			};
		}
		public static IEnumerable<RetailContractViewModel> ToViewModel(this IQueryable<RetailContract> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}

		public static RetailContract ToDataModel(this RetailContractCreateViewModel item)
		{
			return new RetailContract()
			{
				Id = Guid.NewGuid(),
				AnnexContract = new AnnexContract() {
					CustomerId = item.CustomerId,
					Code = item.Code,
					ContractId = item.ContractId,
					BookingTypeId = item.BookingTypeId,
					ReceiveDate = item.ReceiveDate,
				//	AnnexContractTypeId = item.AnnexContractTypeId,
				}
			};
		}
		public static RetailContract ToDataModel(this RetailContractForAPICreateViewModel item, Guid customerId)
		{
			return new RetailContract()
			{
				Id = Guid.NewGuid(),
				AnnexContract = new AnnexContract()
				{
					CustomerId = customerId,
					Code = item.Code,
					ContractId = item.ContractId,
					BookingTypeId = item.BookingTypeId,
					ReceiveDate = item.ReceiveDate,
				//	AnnexContractTypeId = item.AnnexContractTypeId,
				}
			};
		}
		public static RetailContract ToDataModel(this RetailContractCreateModalViewModel item, Guid customerId)
		{
			return new RetailContract()
			{
				Id = Guid.NewGuid(),
				AnnexContract = new AnnexContract()
				{
					CustomerId = customerId,
					Code = item.Code,
					ContractId = item.ContractId,
					BookingTypeId = item.BookingTypeId,
					ReceiveDate = item.ReceiveDate,
					//	AnnexContractTypeId = item.AnnexContractTypeId,
				}
			};
		}
		public static RetailContract ToDataModel(this RetailContractForAPIEditViewModel item, Guid customerId)
		{
			return new RetailContract()
			{
				Id = Guid.NewGuid(),
				AnnexContract = new AnnexContract()
				{
					CustomerId = customerId,
					Code = item.Code,
					ContractId = item.ContractId,
					BookingTypeId = item.BookingTypeId,
					ReceiveDate = item.ReceiveDate,
				//	AnnexContractTypeId = item.AnnexContractTypeId,
				}
			};
		}
		public static void EditDataModel(this RetailContract item, RetailContractViewModel viewModel)
		{
		//	item.AnnexContract.CustomerId = viewModel.CustomerId;
		//	item.AnnexContract.ContractId = viewModel.ContractId;
		//	item.AnnexContract.BookingTypeId = viewModel.BookingTypeId;
			item.AnnexContract.ReceiveDate = viewModel.ReceiveDate;
		//	item.AnnexContract.AnnexContractTypeId = viewModel.AnnexContractTypeId;
		}
	}
}
