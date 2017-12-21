using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Entities.Booking;
using HD.TVAD.Services.PriceCalculation;
using HD.TVAD.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manager.SpotBookings
{
    public static class MappingExtension
	{
		public static SpotBookingViewModel ToViewModel(this SpotBooking item, IPriceCalculationService priceCalculationService)
		{
			return new SpotBookingViewModel()
			{
				Id = item.Id,
				AnnexContractAssetId = item.AnnexContractAssetId,
				BookingDate = item.BookingDate,
				BroadcastDate = item.Spot.BroadcastDate,
				TimeBandSliceId = item.Spot.TimeBandSliceId,
				TimeBandId = item.Spot.TimeBandSlice.TimeBandId,
				TimeBandSliceName = item.Spot.TimeBandSlice.Name,
				TimeBandName = item.Spot.TimeBandSlice.TimeBand.TimeBandBase.Name,
				Position = item.Position,
				IsPositionCost = item.IsPositionCost.HasValue ? item.IsPositionCost.Value : false,
				AssetCode = item.AnnexContractAsset.Content.Code,
				//	CardRateSet = item.CardRateSet,
				CardRateSet = priceCalculationService.GetRateCard(item),
				DiscountRateSet = priceCalculationService.GetDiscountValue(item),
				PositionRateSet = priceCalculationService.GetPositionCost(item),
				ApprovedOnAir = item.IsApproved, // check if approved onair
			};
		}
		public static IEnumerable<SpotBookingViewModel> ToViewModel(this IQueryable<SpotBooking> items, IPriceCalculationService priceCalculationService)
		{
			foreach (var item in items)
			{
				yield return item.ToViewModel(priceCalculationService);
			}
		}

		public static SpotBookingContractIndexViewModel ToViewModel(this RetailContract retailContract)
		{
			return new SpotBookingContractIndexViewModel()
			{
				AnnexContractId = retailContract.Id,
				Code = retailContract.AnnexContract.Code,
				BookingTypeId = (BookingTypeEnum)retailContract.AnnexContract.BookingTypeId,
				CustomerName = retailContract.AnnexContract.Customer.Name,
				BookingTypeName = retailContract.AnnexContract.BookingType.Name,
				ReceiveDate = retailContract.AnnexContract.ReceiveDate,
			};
		}
		public static SpotBookingContractIndexViewModel ToViewModel(this AnnexContractPartner annexContractPartner)
		{
			return new SpotBookingContractIndexViewModel()
			{
				AnnexContractId = annexContractPartner.Id,
				Code = annexContractPartner.AnnexContract.Code,
				CustomerName = annexContractPartner.AnnexContract.Customer.Name,
				BookingTypeId = (BookingTypeEnum)annexContractPartner.AnnexContract.BookingTypeId,
				BookingTypeName = annexContractPartner.AnnexContract.BookingType.Name,
				ReceiveDate = annexContractPartner.AnnexContract.ReceiveDate,
				AnnexContractTypeName = annexContractPartner.AnnexContract.AnnexContractType != null? annexContractPartner.AnnexContract.AnnexContractType.Name: "" ,

				SignDate = annexContractPartner.SignDate,
				ScheduleCampaign = annexContractPartner.ScheduleCampaign,
				Content = annexContractPartner.Content,
				SponsorProgramName = annexContractPartner.SponsorProgram != null ? annexContractPartner.SponsorProgram.Name : ""

			};
		}
		public static SpotBooking ToDataModel(this SpotBookingCreateIndexViewModel viewModel)
		{
			var spotId = Guid.NewGuid();
			return new SpotBooking()
			{
				Id = Guid.NewGuid(),
				AnnexContractAssetId = viewModel.AnnexContractAssetId,
				SpotId = spotId,
				Position = viewModel.Position,
				IsPositionCost = viewModel.IsPositionCost,				
				Spot = new Spot() {
					BroadcastDate = viewModel.BroadcastDate,
					TimeBandSliceId = viewModel.TimeBandSliceId,
					Description = viewModel.Description,
					Id = spotId,
				},
			};
		}
		public static SpotBooking ToDataModel(this SpotBookingCreateIndexViewModel viewModel, Spot spot)
		{
			return new SpotBooking()
			{
				Id = Guid.NewGuid(),
				AnnexContractAssetId = viewModel.AnnexContractAssetId,
				SpotId = spot.Id,
				Position = viewModel.Position,
				IsPositionCost = viewModel.IsPositionCost,
			};
		}
		public static void EditDataModel(this SpotBooking spotBooking, SpotBookingCreateIndexViewModel viewModel)
		{
			spotBooking.Position = viewModel.Position;
			spotBooking.IsPositionCost = viewModel.IsPositionCost;
		}
		public static void EditDataModel(this SpotBooking spotBooking, SpotBookingForNormalBookingEditViewModel viewModel, Guid spotId)
		{
			spotBooking.Position = viewModel.Position;
			spotBooking.IsPositionCost = viewModel.IsPositionCost;
			spotBooking.SpotId = spotId;
			//	spotBooking.Spot.BroadcastDate = viewModel.BroadcastDate;
			//	spotBooking.Spot.TimeBandSliceId = viewModel.TimeBandSliceId;
		}
		public static void EditDataModel(this SpotBooking spotBooking, SpotBookingForNormalBookingEditViewModel viewModel)
		{
			spotBooking.Position = viewModel.Position;
			spotBooking.IsPositionCost = viewModel.IsPositionCost;
		//	spotBooking.SpotId = spotId;
			spotBooking.Spot.BroadcastDate = viewModel.BroadcastDate;
			spotBooking.Spot.TimeBandSliceId = viewModel.TimeBandSliceId;
		}
	}
}
