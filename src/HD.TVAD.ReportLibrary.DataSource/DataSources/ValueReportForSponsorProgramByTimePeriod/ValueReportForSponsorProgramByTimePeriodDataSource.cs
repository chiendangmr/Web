using HD.TVAD.Services.PriceCalculation;
using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.ValueReportForSponsorProgramByTimePeriod
{
 	public class ValueReportForSponsorProgramByTimePeriodDataSource : DataSourceCalculationPrice<ValueReportForSponsorProgramByTimePeriodViewModel>
	{
		public ValueReportForSponsorProgramByTimePeriodDataSource(ISpotService spotService,
			IPriceCalculationService priceCalculationService,
			ValueReportForSponsorProgramByTimePeriodParameter parameter)
			: base(priceCalculationService)
		{
			var parameterHelper = new ParameterHelper<ValueReportForSponsorProgramByTimePeriodParameter>(parameter);

			var spots = spotService.GetAll()
				.Where(s => parameterHelper.IsAllTime ? true : s.BroadcastDate >= parameterHelper.FromDate && s.BroadcastDate <= parameterHelper.ToDate)
				.ToList();

			foreach (var spot in spots)
			{
				foreach (var spotBooking in spot.SpotBookings
					.Where(s => parameter.IsApproved ? s.IsApproved : true)
					.Where(s => s.IsNormalBooking)
					.Where(s => s.HasSponsorProgram))
				{
					Data.Add(new ValueReportForSponsorProgramByTimePeriodViewModel()
					{
						TimeBandName = spot.TimeBandName,
						SponsorProgramName = spotBooking.SponsorProgramName,
						TimeBandSliceName = spot.TimeBandSliceName,
						Price = _priceCalculationService.GetTotalBeforeDiscount(spotBooking),
						TotalValue = _priceCalculationService.GetTotalAfterDiscount(spotBooking)
					});
				}
			}
		}
	}
}
