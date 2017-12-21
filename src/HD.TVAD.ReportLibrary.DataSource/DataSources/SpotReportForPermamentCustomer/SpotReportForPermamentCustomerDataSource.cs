using HD.TVAD.ApplicationCore.Entities.Booking;
using HD.TVAD.ApplicationCore.Entities.ContractSchema;
using HD.TVAD.Services.PriceCalculation;
using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotReportForPermamentCustomer
{
	public class SpotReportForPermamentCustomerDataSource : DataSource<SpotReportForPermamentCustomerViewModel>
	{
		public SpotReportForPermamentCustomerDataSource(IServiceProvider serviceProvider,
			SpotReportForPermamentCustomerParameter parameter)

		{
			var spotService = serviceProvider.GetService(typeof(ISpotService)) as ISpotService;
			var _spotBookingService = serviceProvider.GetService(typeof(ISpotBookingService)) as ISpotBookingService;
			var _priceCalculationService = serviceProvider.GetService(typeof(IPriceCalculationService)) as IPriceCalculationService;

			var parameterHelper = new ParameterHelper<SpotReportForPermamentCustomerParameter>(parameter);

			var _spotBookings = _spotBookingService.GetAll()
				.Where(s => parameterHelper.IsAllTime ? true : s.Spot.BroadcastDate >= parameterHelper.FromDate && s.Spot.BroadcastDate <= parameterHelper.ToDate)
				.Where(s => parameter.CustomerId.HasValue ?
						 s.AnnexContractAsset.AnnexContract.CustomerId == parameter.CustomerId :
						 s.AnnexContractAsset.AnnexContract.Customer.TypeId == (int)CustomerTypeEnum.Permanent)
				.Where(s => s.AnnexContractAsset.AnnexContract.BookingTypeId == (int)BookingTypeEnum.Contract_Booking);
			//	.ToList();


			var spotBookings = _spotBookings
			//	.Where(s => s.IsNormalBooking)
				.Where(s => parameter.IsApproved ? s.SpotAssetByBookings != null : true);

			foreach (var spotBooking in spotBookings)
			{
				var price = _priceCalculationService.GetRateCard(spotBooking);
				var positionCost = _priceCalculationService.GetPositionCost(spotBooking);
				var discountValue = _priceCalculationService.GetDiscountValue(spotBooking, price, positionCost);
				Data.Add(new SpotReportForPermamentCustomerViewModel()
				{
					CustomerCode = spotBooking.CustomerCode,
					CustomerName = spotBooking.CustomerName,
					ContractCode = spotBooking.ContractCode,
					AssetDuration = spotBooking.AssetDuration,
					DiscountRate = 2,
					PositionCost = positionCost,
					DiscountValue = discountValue,
					Price = price,
				});
			}
		}
	}
}
