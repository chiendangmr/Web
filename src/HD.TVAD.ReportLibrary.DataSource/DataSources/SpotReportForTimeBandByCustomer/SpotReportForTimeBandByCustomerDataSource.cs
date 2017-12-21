using HD.TVAD.Services.PriceCalculation;
using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotReportForTimeBandByCustomer
{
	public class SpotReportForTimeBandByCustomerDataSource: DataSourceCalculationPrice<SpotReportForTimeBandByCustomerViewModel>
	{
		public SpotReportForTimeBandByCustomerDataSource(ISpotService spotService,
			IPriceCalculationService priceCalculationService,
			SpotReportForTimeBandByCustomerParameter parameter)
			: base(priceCalculationService)
		{
			var parameterHelper = new ParameterHelper<SpotReportForTimeBandByCustomerParameter>(parameter);

			var spots = spotService.GetAll()
				.Where(s => parameterHelper.IsAllTime ? true : s.BroadcastDate >= parameterHelper.FromDate && s.BroadcastDate <= parameterHelper.ToDate)
				.ToList();
			foreach (var spot in spots)
			{
				foreach (var spotBooking in spot.SpotBookings
					.Where(s => parameter.IsApproved ? s.IsApproved : true)
					.Where(s => s.IsNormalBooking))
				{
					Data.Add(new SpotReportForTimeBandByCustomerViewModel() {
						TimeBandName = spot.TimeBandName,
						AssetDuration = spotBooking.AssetDuration,
						CustomerCode = spotBooking.CustomerCode,
						CustomerName = spotBooking.CustomerName,
						Price = _priceCalculationService.GetTotalBeforeDiscount(spotBooking),
						TotalValue = _priceCalculationService.GetTotalAfterDiscount(spotBooking)
					});
				}
			}
		}
	}
}
