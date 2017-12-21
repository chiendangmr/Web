using HD.TVAD.Web.Services;
using HD.TVAD.ReportLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Services.PriceCalculation;

namespace HD.TVAD.ReportLibrary
{
	public class DoiChieuKiemNhanNoDataSource : DataSourceCalculationPrice<DoiChieuKiemNhanNoViewModel>
	{
		public DoiChieuKiemNhanNoDataSource(ISpotService spotService,
			IPriceCalculationService priceCalculationService,
			DoiChieuKiemNhanNoParameter parameter)
			: base(priceCalculationService)
		{
			var parameterHelper = new ParameterHelper<DoiChieuKiemNhanNoParameter>(parameter);

			var spots = spotService.GetAll()
				.Where(s => parameterHelper.IsAllTime ? true : s.BroadcastDate >= parameterHelper.FromDate && s.BroadcastDate <= parameterHelper.ToDate)
				.ToList();

			foreach (var spot in spots)
			{
				foreach (var spotBooking in spot.SpotBookings
					.Where(s => parameter.IsApproved ? s.IsApproved : true)
					.Where(s => s.IsNormalBooking)
					.Where(s => s.CustomerId == parameter.CustomerId))
				{
					Data.Add(new DoiChieuKiemNhanNoViewModel()
					{
						AnnexContractCode = spotBooking.ContractCode,
						Duration = spotBooking.AssetDuration,
						CustomerName = spotBooking.CustomerName,
						Content = spotBooking.AnnexContractAsset.AnnexContract.AnnexContractPartners.Content,
						SpotId = spotBooking.Id.ToString(),
						DiscountRate = _priceCalculationService.GetDiscountRate(spotBooking),
						Price = _priceCalculationService.GetRateCard(spotBooking),
						PositionCost = _priceCalculationService.GetPositionCost(spotBooking),
						DiscountValue = _priceCalculationService.GetDiscountValue(spotBooking),
						PositionChoose = spotBooking.IsPositionCost.HasValue? (spotBooking.IsPositionCost.Value? 1: 0 ): 0,						
					});
				}

			}
		}
	}
}