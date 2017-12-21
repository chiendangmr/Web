using HD.TVAD.Services.PriceCalculation;
using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotReportByProducer
{
	public class SpotReportByProducerDataSource : DataSourceCalculationPrice<SpotReportByProducerViewModel>
	{

		public SpotReportByProducerDataSource(ISpotService spotService,
			IPriceCalculationService priceCalculationService,
			SpotReportByProducerParameter parameter)
			: base(priceCalculationService)
		{
			var parameterHelper = new ParameterHelper<SpotReportByProducerParameter>(parameter);

			var spots = spotService.GetAll()
				.Where(s => parameterHelper.IsAllTime ? true : s.BroadcastDate >= parameterHelper.FromDate && s.BroadcastDate <= parameterHelper.ToDate)
				.ToList();

			foreach (var spot in spots)
			{
				foreach (var spotBooking in spot.SpotBookings
					.Where(s=> parameter.IsApproved? s.IsApproved: true))
				{
					Data.Add(new SpotReportByProducerViewModel()
					{
						ContractCode = spotBooking.AnnexContractAsset.AnnexContract.Code,
						Duration = spotBooking.AnnexContractAsset.Content.BlockDuration,
						ProductName = spotBooking.AnnexContractAsset.Content.ProductName,
						ProducerName = spotBooking.AnnexContractAsset.Content.Producer.Name,
						PositionCost = _priceCalculationService.GetPositionCost(spotBooking),
						DiscountValue = _priceCalculationService.GetDiscountValue(spotBooking),
						Price = _priceCalculationService.GetRateCard(spotBooking),

					});
				}

			}
		}
	}
}
