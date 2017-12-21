using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotReportForTimeBandByAssetDuration
{
	public class SpotReportForTimeBandByAssetDurationDataSource: DataSource<SpotReportForTimeBandByAssetDurationViewModel>
	{
		public SpotReportForTimeBandByAssetDurationDataSource(ISpotService spotService, SpotReportForTimeBandByAssetDurationParameter parameter)
		{
			var spots = spotService.GetAll()
				.Where(s => s.HasBooking)
				.ToList();
			foreach (var spot in spots)
			{
				foreach (var spotBooking in spot.SpotBookings)
				{

					switch (spotBooking.AssetDuration)
					{
						case 5:
								Data.Add(new SpotReportForTimeBandByAssetDurationViewModel() {
									BroadcastDate = spot.BroadcastDate,
									TimeBandName = spot.TimeBandName,
									_5s = 500,
							});
						break;

						case 10:
							Data.Add(new SpotReportForTimeBandByAssetDurationViewModel()
							{
								BroadcastDate = spot.BroadcastDate,
								TimeBandName = spot.TimeBandName,
								_10s = 600,
							});
							break;
						case 15:
							Data.Add(new SpotReportForTimeBandByAssetDurationViewModel()
							{
								BroadcastDate = spot.BroadcastDate,
								TimeBandName = spot.TimeBandName,
								_15s = 600,
							});
							break;
						case 20:
							Data.Add(new SpotReportForTimeBandByAssetDurationViewModel()
							{
								BroadcastDate = spot.BroadcastDate,
								TimeBandName = spot.TimeBandName,
								_20s = 60,
							});
							break;
						case 30:
							Data.Add(new SpotReportForTimeBandByAssetDurationViewModel()
							{
								BroadcastDate = spot.BroadcastDate,
								TimeBandName = spot.TimeBandName,
								_30s = 6000,
							});
							break;
						default:
							break;
					}
				}
			}
		}
	}
}
