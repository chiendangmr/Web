using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Entities.Booking;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.AnnexContracts
{
    public static class MappingExtension
	{
		public static AnnexContractViewModel ToViewModel(this AnnexContract item)
		{
			return new AnnexContractViewModel()
			{
				AnnexContractTypeId = item.AnnexContractTypeId,
				AnnexContractTypeName = item.AnnexContractTypeId.HasValue ? item.AnnexContractType.Name : null,
				BookingTypeId = (BookingTypeEnum)item.BookingTypeId,
				BookingTypeName = item.BookingType.Name,
				Code = item.Code,
				ContractId = item.ContractId,
				CustomerId = item.CustomerId,
				CustomerName = item.Customer.Name,
				Id = item.Id,
				ReceiveDate = item.ReceiveDate,
			};
		}
		public static AnnexContractViewModel ToViewModel(this AnnexContractPartner item)
		{
			return new AnnexContractViewModel()
			{
				AnnexContractTypeId = item.AnnexContract.AnnexContractTypeId,
				AnnexContractTypeName = item.AnnexContract.AnnexContractTypeId.HasValue? item.AnnexContract.AnnexContractType.Name : null,
				BookingTypeId = (BookingTypeEnum)item.AnnexContract.BookingTypeId,
				BookingTypeName = item.AnnexContract.BookingType.Name,
				Code = item.AnnexContract.Code,
				Content = item.Content,
				ContractId = item.AnnexContract.ContractId,
				CustomerId = item.AnnexContract.CustomerId,
				CustomerName = item.AnnexContract.Customer.Name,
				Id = item.Id,
				ReceiveDate = item.AnnexContract.ReceiveDate,
				ScheduleCampaign = item.ScheduleCampaign,
				SignDate = item.SignDate,
				SponsorProgramId = item.SponsorProgramId,
				SponsorProgramName = item.SponsorProgramId.HasValue ? item.SponsorProgram.Name : null,
				SponsorTypeId = item.SponsorTypeId,
				SponsorTypeName = item.SponsorTypeId.HasValue ? item.SponsorType.Name : null,
			};
		}
		public static IEnumerable<AnnexContractViewModel> ToViewModel(this IQueryable<AnnexContractPartner> items)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel();
			}
		}
		public static IQueryable<AnnexContractViewModel> ToQueryableViewModel(this IQueryable<AnnexContractPartner> items)
		{
			return items.Select(item => new AnnexContractViewModel()
			{
				AnnexContractTypeId = item.AnnexContract.AnnexContractTypeId,
				AnnexContractTypeName = item.AnnexContract.AnnexContractTypeId.HasValue ? item.AnnexContract.AnnexContractType.Name : null,
				BookingTypeId = (BookingTypeEnum)item.AnnexContract.BookingTypeId,
				BookingTypeName = item.AnnexContract.BookingType.Name,
				Code = item.AnnexContract.Code,
				Content = item.Content,
				ContractId = item.AnnexContract.ContractId,
				CustomerId = item.AnnexContract.CustomerId,
				CustomerName = item.AnnexContract.Customer.Name,
				Id = item.Id,
				ReceiveDate = item.AnnexContract.ReceiveDate,
				ScheduleCampaign = item.ScheduleCampaign,
				SignDate = item.SignDate,
				SponsorProgramId = item.SponsorProgramId,
				SponsorProgramName = item.SponsorProgramId.HasValue ? item.SponsorProgram.Name : null,
				SponsorTypeId = item.SponsorTypeId,
				SponsorTypeName = item.SponsorTypeId.HasValue ? item.SponsorType.Name : null,
			});
		}

		public static AnnexContractPartner ToDataModel(this AnnexContractCreateViewModel item)
		{
			return new AnnexContractPartner()
			{
				Id = Guid.NewGuid(),
				SignDate = item.SignDate,
				ScheduleCampaign = item.ScheduleCampaign,
				Content = item.Content,
				SponsorProgramId = item.SponsorProgramId,
				SponsorTypeId = item.SponsorTypeId,
				AnnexContract = new AnnexContract() {
					CustomerId = item.CustomerId,
					Code = item.Code,
					ContractId = item.ContractId,
					BookingTypeId = (int)item.BookingTypeId,
					ReceiveDate = item.ReceiveDate,
					AnnexContractTypeId = item.AnnexContractTypeId,
				}
			};
		}
		public static AnnexContractPartner ToDataModelFromCreateFromEditForm(this AnnexContractCreateViewModel item)
		{
			return new AnnexContractPartner()
			{
				Id = Guid.NewGuid(),
				SignDate = item.SignDate,
			//	ScheduleCampaign = item.ScheduleCampaign,
			//	Content = item.Content,
				SponsorProgramId = item.SponsorProgramId,
				SponsorTypeId = item.SponsorTypeId,
				AnnexContract = new AnnexContract()
				{
					CustomerId = item.CustomerId,
					Code = item.Code,
					ContractId = item.ContractId,
					BookingTypeId = (int)item.BookingTypeId,
					ReceiveDate = item.ReceiveDate,
					AnnexContractTypeId = item.AnnexContractTypeId,
				}
			};
		}
		public static void EditDataModel(this AnnexContractPartner item, AnnexContractEditViewModel viewModel)
		{
			item.SignDate = viewModel.SignDate;
			item.ScheduleCampaign = viewModel.ScheduleCampaign;
			item.Content = viewModel.Content;
			item.SponsorProgramId = viewModel.SponsorProgramId;
			item.SponsorTypeId = viewModel.SponsorTypeId;
			item.AnnexContract.CustomerId = viewModel.CustomerId;
		//	item.AnnexContract.ContractId = viewModel.ContractId;
		//	item.AnnexContract.BookingTypeId = (int)viewModel.BookingTypeId;
			item.AnnexContract.ReceiveDate = viewModel.ReceiveDate;
			item.AnnexContract.AnnexContractTypeId = viewModel.AnnexContractTypeId;
		}
		public static void EditDataModel(this AnnexContractPartner item, ChangeToBookingOutViewModel viewModel)
		{
			item.SponsorProgramId = viewModel.SponsorProgramId;
			item.SponsorTypeId = viewModel.SponsorTypeId;
			item.AnnexContract.AnnexContractTypeId = viewModel.AnnexContractTypeId;
			item.AnnexContract.BookingTypeId = (int)BookingTypeEnum.Contract_Sponsor_OutProgram;
		}
		public static void EditDataModel(this AnnexContractPartner item, ChangeCustomerViewModel viewModel)
		{
			item.AnnexContract.CustomerId = viewModel.CustomerId;
		}
		public static void EditDataModel(this AnnexContractPartner item, ChangeToBookingOutFromBookingInViewModel viewModel)
		{
			item.AnnexContract.BookingTypeId = (int)BookingTypeEnum.Contract_Sponsor_OutProgram;
		}
		public static void EditDataModel(this AnnexContractPartner item, ChangeToBookingInFromBookingOutViewModel viewModel)
		{
			item.AnnexContract.BookingTypeId = (int)BookingTypeEnum.Contract_Sponsor_InProgram;
		}
		public static void EditDataModel(this AnnexContractPartner item, ChangeToNormalBookingViewModel viewModel)
		{
			item.AnnexContract.BookingTypeId = (int)BookingTypeEnum.Contract_Booking;
		}
	}
}
