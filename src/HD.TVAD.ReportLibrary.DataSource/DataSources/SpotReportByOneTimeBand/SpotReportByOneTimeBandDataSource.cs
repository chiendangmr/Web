using HD.TVAD.Services.PriceCalculation;
using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotReportByOneTimeBand
{
	public class SpotReportByOneTimeBandDataSource : DataSourceCalculationPrice<SpotReportByOneTimeBandViewModel>
	{
		public SpotReportByOneTimeBandDataSource(ISpotService spotService,
			IPriceCalculationService priceCalculationService,
			SpotReportByOneTimeBandParameter parameter)
			: base(priceCalculationService)
		{

			var parameterHelper = new ParameterHelper<SpotReportByOneTimeBandParameter>(parameter);

			var spots = spotService.GetAll()
				.Where(s => parameterHelper.IsAllTime ? true : s.BroadcastDate >= parameterHelper.FromDate && s.BroadcastDate <= parameterHelper.ToDate)
				.Where(s => s.TimeBandSlice.TimeBand.TimeBandBase.Id == parameter.TimeBandId)
				.ToList();
			foreach (var spot in spots)
			{
				foreach (var spotBooking in spot.SpotBookings
					.Where(s => parameter.IsApproved ? s.IsApproved : true))
				{
					Data.Add(new SpotReportByOneTimeBandViewModel()
					{
						ContractType = spotBooking.BookingTypeName,
						TimeBandSlice = spot.TimeBandSlice.Name,
						Price = _priceCalculationService.GetRateCard(spotBooking),

					});
				}

			}
		}
	}
}
