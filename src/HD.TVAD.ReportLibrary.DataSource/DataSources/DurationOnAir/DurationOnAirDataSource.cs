using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.DurationOnAir
{
	public class DurationOnAirDataSource: DataSource<DurationOnAirViewModel>
	{
		public DurationOnAirDataSource(ISpotService spotService, DurationOnAirParameter parameter)
		{
			var parameterHelper = new ParameterHelper<DurationOnAirParameter>(parameter);

			var spots = spotService.GetAll()
				.Where(s => parameterHelper.IsAllTime ? true : s.BroadcastDate >= parameterHelper.FromDate && s.BroadcastDate <= parameterHelper.ToDate)
				.ToList();

			for (int i = 1; i <= 31; i++)
			{
				Data.Add(new DurationOnAirViewModel()
				{
					ChannelName = "",
					Day = i,
					DiscountValue = 0,
					Price = 0,
				});
			}

			foreach (var spot in spots)
			{
				foreach (var spotBooking in spot.SpotBookings
					.Where(s => parameter.IsApproved ? s.IsApproved : true))
				{
					Data.Add(new DurationOnAirViewModel()
					{
						ChannelName = spot.ChannelName,
						Day = spot.BroadcastDate.Day,
						DiscountValue = 2,
						Price = 20,
					});
				}
			}
		}
	}
}