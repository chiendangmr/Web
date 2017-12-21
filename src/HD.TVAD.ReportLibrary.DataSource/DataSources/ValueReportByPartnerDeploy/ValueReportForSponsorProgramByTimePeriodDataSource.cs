using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.ValueReportByPartnerDeploy
{
 	public class ValueReportByPartnerDeployDataSource : DataSource<ValueReportByPartnerDeployViewModel>
	{
		public ValueReportByPartnerDeployDataSource(ISpotService spotService, ValueReportByPartnerDeployParameter parameter)
		{
			var parameterHelper = new ParameterHelper<ValueReportByPartnerDeployParameter>(parameter);

			var spots = spotService.GetAll()
				.Where(s => parameterHelper.IsAllTime ? true : s.BroadcastDate >= parameterHelper.FromDate && s.BroadcastDate <= parameterHelper.ToDate)
				.ToList();

			foreach (var spot in spots)
			{
				foreach (var spotBooking in spot.SpotBookings
					.Where(s => s.IsApproved)
					.Where(s => s.IsNormalBooking)
					.Where(s => s.HasSponsorProgram))
				{
					Data.Add(new ValueReportByPartnerDeployViewModel()
					{
						BroadcastDate = spot.BroadcastDate,
					});
				}
			}
		}
	}
}
