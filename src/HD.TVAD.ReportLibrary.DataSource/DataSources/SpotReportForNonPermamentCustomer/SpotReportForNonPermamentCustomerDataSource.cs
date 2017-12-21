using HD.TVAD.ApplicationCore.Entities.ContractSchema;
using HD.TVAD.Services.PriceCalculation;
using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotReportForNonPermamentCustomer
{
	public class SpotReportForNonPermamentCustomerDataSource : DataSource<SpotReportForNonPermamentCustomerViewModel>
	{
		
		public SpotReportForNonPermamentCustomerDataSource(IServiceProvider serviceProvider, SpotReportForNonPermamentCustomerParameter parameter)
		{
			var spotService = serviceProvider.GetService(typeof(ISpotService)) as ISpotService;
			var _spotBookingService = serviceProvider.GetService(typeof(ISpotBookingService)) as ISpotBookingService;
			var _priceCalculationService = serviceProvider.GetService(typeof(IPriceCalculationService)) as IPriceCalculationService;

			var parameterHelper = new ParameterHelper<SpotReportForNonPermamentCustomerParameter>(parameter);

			var _spotBookings = _spotBookingService.GetAll()
				.Where(s => parameterHelper.IsAllTime ? true : s.Spot.BroadcastDate >= parameterHelper.FromDate && s.Spot.BroadcastDate <= parameterHelper.ToDate)
				.Where(s => parameter.CustomerId.HasValue ?
						 s.AnnexContractAsset.AnnexContract.CustomerId == parameter.CustomerId :
						 s.AnnexContractAsset.AnnexContract.Customer.TypeId == (int)CustomerTypeEnum.NoPermanent)
				.Where(s => s.IsNormalContractBooking)
				.ToList();


			var spotBookings = _spotBookings
				.Where(s => s.IsNormalBooking)
				.Where(s => parameter.IsApproved ? s.IsApproved : true);

			foreach (var spotBooking in spotBookings)
			{
				var price = _priceCalculationService.GetRateCard(spotBooking);
				var positionCost = _priceCalculationService.GetPositionCost(spotBooking);
				var discountValue = _priceCalculationService.GetDiscountValue(spotBooking, price, positionCost);
				Data.Add(new SpotReportForNonPermamentCustomerViewModel()
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
