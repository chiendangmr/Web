using HD.TVAD.Services.PriceCalculation;
using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotReportByContractContentOrProduct
{
	public class SpotReportByContractContentOrProductDataSource : DataSourceCalculationPrice<SpotReportByContractContentOrProductViewModel>
	{
		public SpotReportByContractContentOrProductDataSource(ISpotService spotService,
			IPriceCalculationService priceCalculationService,
			SpotReportByContractContentOrProductParameter parameter)
			: base(priceCalculationService)
		{
			var parameterHelper = new ParameterHelper<SpotReportByContractContentOrProductParameter>(parameter);

			var spots = spotService.GetAll()
				.Where(s => parameterHelper.IsAllTime ? true : s.BroadcastDate >= parameterHelper.FromDate && s.BroadcastDate <= parameterHelper.ToDate)
				.ToList();

			foreach (var spot in spots)
			{
				foreach (var spotBooking in spot.SpotBookings
					.Where(s => parameter.IsApproved ? s.IsApproved : true)
					.Where(s => s.AnnexContractAsset.Content.ProductName.ToLower().Contains(parameter.KeyWord == null? "": parameter.KeyWord.ToLower())) // demo empty keyword
					.Where(s => s.AnnexContractAsset.AnnexContract.IsPartnerContract)
					.Where(s => s.IsNormalBooking))
				{
					Data.Add(new SpotReportByContractContentOrProductViewModel()
					{
						CustomerCode = spotBooking.CustomerCode,
						CustomerName = spotBooking.CustomerName,
						AssetDuration = spotBooking.AssetDuration,
						ContractContentAndProductName = spotBooking.AnnexContractAsset.AnnexContract.AnnexContractPartners.Content + " - "
						+ spotBooking.AnnexContractAsset.Content.ProductName,
						PositionCost = _priceCalculationService.GetPositionCost(spotBooking),
						DiscountValue = _priceCalculationService.GetDiscountValue(spotBooking),
						Price = _priceCalculationService.GetRateCard(spotBooking),
					});
				}

			}
		}
	}
}
