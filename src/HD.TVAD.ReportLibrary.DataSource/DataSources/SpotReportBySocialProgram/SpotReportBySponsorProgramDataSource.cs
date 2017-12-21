using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotReportBySocialProgram
{
	public class SpotReportBySocialProgramDataSource : DataSource<SpotReportBySocialProgramViewModel>
	{
		public SpotReportBySocialProgramDataSource(ISpotService spotService, SpotReportBySocialProgramParameter parameter)
		{
			var parameterHelper = new ParameterHelper<SpotReportBySocialProgramParameter>(parameter);

			var spots = spotService.GetAll()
				.Where(s => parameterHelper.IsAllTime ? true : s.BroadcastDate >= parameterHelper.FromDate && s.BroadcastDate <= parameterHelper.ToDate)
				.ToList();

			foreach (var spot in spots)
			{
				foreach (var spotBooking in spot.SpotBookings
					.Where(s => s.IsNormalBooking)
					.Where(s => s.HasSponsorProgram) // booking with sponsor
					.Where(s => parameter.SponsorProgramId.HasValue? s.SponsorProgramId == parameter.SponsorProgramId: true))   
				{
					Data.Add(new SpotReportBySocialProgramViewModel()
					{
						BroadcastDate = spot.BroadcastDate,
						TimeBandName = spot.TimeBandName,
						IntroDuration = 2,
						FreePanelDuration = 4,
						SoldOtherDuration = 6,
						SoldSponsorDuration = 1,
						SponsorProgramName = spotBooking.SponsorProgramName,					
						AssetDuration = spotBooking.AssetDuration,
					});
				}

			}
		}
	}
}
