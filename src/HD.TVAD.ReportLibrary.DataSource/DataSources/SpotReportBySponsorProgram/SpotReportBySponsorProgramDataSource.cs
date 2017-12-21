using HD.TVAD.Services.PriceCalculation;
using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotReportBySponsorProgram
{
	public class SpotReportBySponsorProgramDataSource : DataSourceCalculationPrice<SpotReportBySponsorProgramViewModel>
	{
		public SpotReportBySponsorProgramDataSource(ISpotService spotService,
			IPriceCalculationService priceCalculationService,
			SpotReportBySponsorProgramParameter parameter): base(priceCalculationService)
		{
			var parameterHelper = new ParameterHelper<SpotReportBySponsorProgramParameter>(parameter);

			var spots = spotService.GetAll()
				.Where(s => parameterHelper.IsAllTime ? true : s.BroadcastDate >= parameterHelper.FromDate && s.BroadcastDate <= parameterHelper.ToDate)
				.ToList();

			foreach (var spot in spots)
			{
				foreach (var spotBooking in spot.SpotBookings
					.Where(s => parameter.IsApproved ? s.IsApproved : true)
					.Where(s => s.IsNormalBooking)
					.Where(s => s.HasSponsorProgram) // booking with sponsor
					.Where(s => parameter.SponsorProgramId.HasValue? s.SponsorProgramId == parameter.SponsorProgramId: true))   
				{
					var discountValue = _priceCalculationService.GetDiscountValue(spotBooking).HasValue ? _priceCalculationService.GetDiscountValue(spotBooking).Value : 0;
					var price = _priceCalculationService.GetRateCard(spotBooking).HasValue ? _priceCalculationService.GetRateCard(spotBooking).Value : 0;
					var positionCost = _priceCalculationService.GetPositionCost(spotBooking).HasValue ? _priceCalculationService.GetPositionCost(spotBooking).Value : 0;

					Data.Add(new SpotReportBySponsorProgramViewModel()
					{
						CustomerCode = spotBooking.CustomerCode,
						SponsorProgramName = spotBooking.SponsorProgramName,						
						SponsorProgramCode = spotBooking.SponsorProgramCode,
						CustomerName = spotBooking.CustomerName,
						ContractCode = spotBooking.ContractCode,
						AssetDuration = spotBooking.AssetDuration,
						PositionCost = positionCost,
						DiscountValue = discountValue,
						Price = price,
					});
				}

			}
		}
	}
}
