using HD.TVAD.Services.PriceCalculation;
using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.ValueReportByTimeBands
{
	public class ValueReportByTimeBandsDataSource: DataSourceCalculationPrice<ValueReportByTimeBandsViewModel>
	{
		public ValueReportByTimeBandsDataSource(ISpotService spotService,
			IPriceCalculationService priceCalculationService, 
			ValueReportByTimeBandsParameter parameter)
			: base(priceCalculationService)
		{
			var parameterHelper = new ParameterHelper<ValueReportByTimeBandsParameter>(parameter);

			var spots = spotService.GetAll()
				.Where(s => parameterHelper.IsAllTime ? true : s.BroadcastDate >= parameterHelper.FromDate && s.BroadcastDate <= parameterHelper.ToDate)
				.ToList();

			foreach (var spot in spots)
			{
				foreach (var spotBooking in spot.SpotBookings
					.Where(s => parameter.IsApproved ? s.IsApproved : true))
				{
					Data.Add(new ValueReportByTimeBandsViewModel()
					{
						SponsorProgramName = spotBooking.IsNormalBooking? spotBooking.HasSponsorProgram? spotBooking.SponsorProgramName: "" : "",
						TimeBandName = spot.TimeBandName,
						TimeBandTimeFrame = "22-20h", // demo
						BookingTypeName = spotBooking.AnnexContractAsset.AnnexContract.BookingType.Description,
						DiscountValue = _priceCalculationService.GetDiscountValue(spotBooking),
						Price = _priceCalculationService.GetRateCard(spotBooking),
					});
				}
			}
		}
	}
}
