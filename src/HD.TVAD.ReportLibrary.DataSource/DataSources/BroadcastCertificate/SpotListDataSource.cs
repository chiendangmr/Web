using HD.TVAD.Web.Services;
using HD.TVAD.ReportLibrary;
using HD.TVAD.ReportLibrary.BroadcastCertificate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HD.TVAD.ReportLibrary.BroadcastCertificate
{
    public class SpotListDataSource : DataSource<SpotListViewModel>
    {
		public int SpotBookingCount;
		public int TotalDuration;
		public SpotListDataSource(IServiceProvider serviceProvider, SpotListParameter parameter)
		{
			var _spotBookingService = serviceProvider.GetService(typeof(ISpotBookingService)) as ISpotBookingService;

			var _spotBookings = _spotBookingService.GetAll()
				.Where(s => parameter.IsAllTime ? true : s.Spot.BroadcastDate >= parameter.FromDate && s.Spot.BroadcastDate <= parameter.ToDate)
				.Where(s => parameter.AnnexContractId.Equals(Guid.Empty) ? true 
						: s.AnnexContractAsset.AnnexContractId == parameter.AnnexContractId)
				.Where(s => parameter.AnnexContractAssetId.Equals(Guid.Empty) ? true 
						: s.AnnexContractAssetId == parameter.AnnexContractAssetId)
				.ToList();

			var spotBookings = _spotBookings
				.Where(s => parameter.IsApproved ? s.IsApproved : true);

			SpotBookingCount = spotBookings.Count();
			TotalDuration = spotBookings.Sum(b => b.AssetDuration);

			var bookings = new List<SpotBookingViewModel>();

			foreach (var spotBooking in spotBookings)
				{
					bookings.Add(new SpotBookingViewModel() {
						IsPositionChoose = spotBooking.IsPositionCost.GetValueOrDefault(),
						AssetCode = spotBooking.AssetCode,
						AssetDuration = spotBooking.AssetDuration,
						AssetNote = spotBooking.AnnexContractAsset.Content.ProductName,
						ProductName = spotBooking.AnnexContractAsset.Content.ProductName,
						TimeBandName = spotBooking.Spot.TimeBandName,
						TimeBandSliceName = spotBooking.Spot.TimeBandSliceName,
						Month = spotBooking.Spot.BroadcastDate.Month,
						Year = spotBooking.Spot.BroadcastDate.Year,
						Day = spotBooking.Spot.BroadcastDate.Day,
						Position = parameter.IsShowPosition && spotBooking.IsApproved ?
						spotBooking.Spot.SpotAssets.Where(s=> s.Id == spotBooking.Id).FirstOrDefault().Index.ToString() + "/" + spotBooking.Spot.SpotAssets.Count.ToString()
						: "",
					});
				}
			

			var result = bookings.GroupBy(t => new { t.Year, t.Month, t.AssetCode, t.TimeBandName, t.TimeBandSliceName, t.Position })
				.Select((g) => new SpotListViewModel {
					Year = g.Key.Year,
					Month = g.Key.Month,
					AssetCode = g.Key.AssetCode,
					TimeBandName = g.Key.TimeBandName,
					TimeBandSliceName = g.Key.TimeBandSliceName,
					Position = g.Key.Position,
					ProductName = g.Select(a => a.ProductName).FirstOrDefault(),
					AssetDuration = g.Select(a => a.AssetDuration).FirstOrDefault(),
					D01 = GetSpotOfDay(g.Where(a => a.Day == 1).Count(), g.Where(a => a.Day == 1 && a.IsPositionChoose).Count() > 0),
					D02 = GetSpotOfDay(g.Where(a => a.Day == 2).Count(), g.Where(a => a.Day == 2 && a.IsPositionChoose).Count() > 0),
					D03 = GetSpotOfDay(g.Where(a => a.Day == 3).Count(), g.Where(a => a.Day == 3 && a.IsPositionChoose).Count() > 0),
					D04 = GetSpotOfDay(g.Where(a => a.Day == 4).Count(), g.Where(a => a.Day == 4 && a.IsPositionChoose).Count() > 0),
					D05 = GetSpotOfDay(g.Where(a => a.Day == 5).Count(), g.Where(a => a.Day == 5 && a.IsPositionChoose).Count() > 0),
					D06 = GetSpotOfDay(g.Where(a => a.Day == 6).Count(), g.Where(a => a.Day == 6 && a.IsPositionChoose).Count() > 0),
					D07 = GetSpotOfDay(g.Where(a => a.Day == 7).Count(), g.Where(a => a.Day == 7 && a.IsPositionChoose).Count() > 0),
					D08 = GetSpotOfDay(g.Where(a => a.Day == 8).Count(), g.Where(a => a.Day == 8 && a.IsPositionChoose).Count() > 0),
					D09 = GetSpotOfDay(g.Where(a => a.Day == 9).Count(), g.Where(a => a.Day == 9 && a.IsPositionChoose).Count() > 0),
					D10 = GetSpotOfDay(g.Where(a => a.Day == 10).Count(), g.Where(a => a.Day == 10 && a.IsPositionChoose).Count() > 0),
					D11 = GetSpotOfDay(g.Where(a => a.Day == 11).Count(), g.Where(a => a.Day == 11 && a.IsPositionChoose).Count() > 0),
					D12 = GetSpotOfDay(g.Where(a => a.Day == 12).Count(), g.Where(a => a.Day == 12 && a.IsPositionChoose).Count() > 0),
					D13 = GetSpotOfDay(g.Where(a => a.Day == 13).Count(), g.Where(a => a.Day == 13 && a.IsPositionChoose).Count() > 0),
					D14 = GetSpotOfDay(g.Where(a => a.Day == 14).Count(), g.Where(a => a.Day == 14 && a.IsPositionChoose).Count() > 0),
					D15 = GetSpotOfDay(g.Where(a => a.Day == 15).Count(), g.Where(a => a.Day == 15 && a.IsPositionChoose).Count() > 0),
					D16 = GetSpotOfDay(g.Where(a => a.Day == 16).Count(), g.Where(a => a.Day == 16 && a.IsPositionChoose).Count() > 0),
					D17 = GetSpotOfDay(g.Where(a => a.Day == 17).Count(), g.Where(a => a.Day == 17 && a.IsPositionChoose).Count() > 0),
					D18 = GetSpotOfDay(g.Where(a => a.Day == 18).Count(), g.Where(a => a.Day == 18 && a.IsPositionChoose).Count() > 0),
					D19 = GetSpotOfDay(g.Where(a => a.Day == 19).Count(), g.Where(a => a.Day == 19 && a.IsPositionChoose).Count() > 0),
					D20 = GetSpotOfDay(g.Where(a => a.Day == 20).Count(), g.Where(a => a.Day == 20 && a.IsPositionChoose).Count() > 0),
					D21 = GetSpotOfDay(g.Where(a => a.Day == 21).Count(), g.Where(a => a.Day == 21 && a.IsPositionChoose).Count() > 0),
					D22 = GetSpotOfDay(g.Where(a => a.Day == 22).Count(), g.Where(a => a.Day == 22 && a.IsPositionChoose).Count() > 0),
					D23 = GetSpotOfDay(g.Where(a => a.Day == 23).Count(), g.Where(a => a.Day == 23 && a.IsPositionChoose).Count() > 0),
					D24 = GetSpotOfDay(g.Where(a => a.Day == 24).Count(), g.Where(a => a.Day == 24 && a.IsPositionChoose).Count() > 0),
					D25 = GetSpotOfDay(g.Where(a => a.Day == 25).Count(), g.Where(a => a.Day == 25 && a.IsPositionChoose).Count() > 0),
					D26 = GetSpotOfDay(g.Where(a => a.Day == 26).Count(), g.Where(a => a.Day == 26 && a.IsPositionChoose).Count() > 0),
					D27 = GetSpotOfDay(g.Where(a => a.Day == 27).Count(), g.Where(a => a.Day == 27 && a.IsPositionChoose).Count() > 0),
					D28 = GetSpotOfDay(g.Where(a => a.Day == 28).Count(), g.Where(a => a.Day == 28 && a.IsPositionChoose).Count() > 0),
					D29 = GetSpotOfDay(g.Where(a => a.Day == 29).Count(), g.Where(a => a.Day == 29 && a.IsPositionChoose).Count() > 0),
					D30 = GetSpotOfDay(g.Where(a => a.Day == 30).Count(), g.Where(a => a.Day == 30 && a.IsPositionChoose).Count() > 0),
					D31 = GetSpotOfDay(g.Where(a => a.Day == 31).Count(), g.Where(a => a.Day == 31 && a.IsPositionChoose).Count() > 0),
				});
			Data = result.ToList();

		}
		public string GetSpotOfDay(int count, bool IsPositionChoose) {

			var PositionChooseSymbol = "*";

			if (count > 0)
			{
				if (IsPositionChoose)
				{
					return count.ToString() + PositionChooseSymbol;
				}
				else return count.ToString();

			}
			else
			{
				return "";
			}
		}
    }
}
