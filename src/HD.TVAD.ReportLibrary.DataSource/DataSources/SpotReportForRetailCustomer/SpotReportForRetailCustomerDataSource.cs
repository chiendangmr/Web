using HD.TVAD.Services.PriceCalculation;
using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotReportForRetailCustomer
{
	public class SpotReportForRetailCustomerDataSource : DataSourceCalculationPrice<SpotReportForRetailCustomerViewModel>
	{

		public SpotReportForRetailCustomerDataSource(ISpotService spotService,
			IPriceCalculationService priceCalculationService,
			SpotReportForRetailCustomerParameter parameter): base(priceCalculationService)
		{
			var parameterHelper = new ParameterHelper<SpotReportForRetailCustomerParameter>(parameter);

			var spots = spotService.GetAll()
				.Where(s => parameterHelper.IsAllTime ? true : s.BroadcastDate >= parameterHelper.FromDate && s.BroadcastDate <= parameterHelper.ToDate)
				.ToList();

			foreach (var spot in spots)
			{
				foreach (var spotBooking in spot.SpotBookings
					.Where(s => s.IsRetailBooking)// retaiil customer
					.Where(s => s.AnnexContractAsset.AnnexContract.Customer.TypeId == 0)) // retaiil customer
				{
					Data.Add(new SpotReportForRetailCustomerViewModel()
					{
						CustomerName = spotBooking.AnnexContractAsset.AnnexContract.Customer.Name,
						ContractCode = spotBooking.AnnexContractAsset.AnnexContract.Code,
						AssetDuration = spotBooking.AnnexContractAsset.Content.BlockDuration,
						DiscountRate = 2,
						PositionCost = _priceCalculationService.GetPositionCost(spotBooking),
						DiscountValue = _priceCalculationService.GetDiscountValue(spotBooking),
						Price = _priceCalculationService.GetRateCard(spotBooking),

					});
				}

			}
		}
	}
}
