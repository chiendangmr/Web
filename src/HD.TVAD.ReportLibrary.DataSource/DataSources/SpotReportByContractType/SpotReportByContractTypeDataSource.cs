using HD.TVAD.Services.PriceCalculation;
using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotReportByContractType
{
	public class SpotReportByContractTypeDataSource : DataSourceCalculationPrice<SpotReportByContractTypeViewModel>
	{
		public SpotReportByContractTypeDataSource(ISpotService spotService,
			IPriceCalculationService priceCalculationService,
			SpotReportByContractTypeParameter parameter)
			: base(priceCalculationService)
		{
			var parameterHelper = new ParameterHelper<SpotReportByContractTypeParameter>(parameter);

			var spots = spotService.GetAll()
				.Where(s => parameterHelper.IsAllTime ? true : s.BroadcastDate >= parameterHelper.FromDate && s.BroadcastDate <= parameterHelper.ToDate)
				.ToList();

			foreach (var spot in spots)
			{
				foreach (var spotBooking in spot.SpotBookings
					.Where(s => parameter.IsApproved ? s.IsApproved : true))
				{
					Data.Add(new SpotReportByContractTypeViewModel()
					{
						ContractType = spotBooking.AnnexContractAsset.AnnexContract.BookingType.Name,
						AssetDuration = spotBooking.AnnexContractAsset.Content.BlockDuration,
						AreaType = "Trong nước",
						PositionCost = _priceCalculationService.GetPositionCost(spotBooking),
						DiscountValue = _priceCalculationService.GetDiscountValue(spotBooking),
						Price = _priceCalculationService.GetRateCard(spotBooking),

					});
				}

			}
		}
	}
}
