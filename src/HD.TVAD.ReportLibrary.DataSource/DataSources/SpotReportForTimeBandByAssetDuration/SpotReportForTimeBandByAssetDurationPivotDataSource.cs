using HD.TVAD.Services.PriceCalculation;
using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotReportForTimeBandByAssetDuration
{
	public class SpotReportForTimeBandByAssetDurationPivotDataSource: DataSource<SpotReportForTimeBandByAssetDurationPivotViewModel>
	{
		public SpotReportForTimeBandByAssetDurationPivotDataSource(IServiceProvider serviceProvider, SpotReportForTimeBandByAssetDurationParameter parameter)
		{
			var parameterHelper = new ParameterHelper<SpotReportForTimeBandByAssetDurationParameter>(parameter);

			var spotService = serviceProvider.GetService(typeof(ISpotService)) as ISpotService;
			var priceCalculationService = serviceProvider.GetService(typeof(IPriceCalculationService)) as IPriceCalculationService;

			var spots = spotService.GetAll()
				.Where(s => parameterHelper.IsAllTime ? true : s.BroadcastDate >= parameterHelper.FromDate && s.BroadcastDate <= parameterHelper.ToDate)
				.ToList();


			var spotBookings = spots.SelectMany(s => s.SpotBookings)
					.ToList();

			foreach (var spotBooking in spotBookings)
			{
				Data.Add(new SpotReportForTimeBandByAssetDurationPivotViewModel()
				{
					AssetDurationType = spotBooking.AssetDuration.ToString(),
					BroadcastDate = spotBooking.Spot.BroadcastDate,
					Price = priceCalculationService.GetRateCard(spotBooking).GetValueOrDefault(),
					DiscountValue = priceCalculationService.GetDiscountValue(spotBooking).GetValueOrDefault(),
				});
			}
		}
	}
}
