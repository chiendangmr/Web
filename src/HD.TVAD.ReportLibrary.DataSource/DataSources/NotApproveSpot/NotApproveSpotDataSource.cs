using HD.TVAD.Web.Services;
using HD.TVAD.ReportLibrary;
using HD.TVAD.ReportLibrary.ImportedTVC;
using HD.TVAD.ReportLibrary.NotApproveSpot;
using HD.TVAD.ReportLibrary.SimplySpotSchedule;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HD.TVAD.ReportLibrary.NotApproveSpot
{
	public class NotApproveSpotDataSource : DataSource<NotApproveSpotViewModel>
	{

		public NotApproveSpotDataSource(ISpotService spotService)
		{
			var spots = spotService.GetAll()
				.ToList();
			foreach (var spot in spots)
			{
				foreach (var spotBooking in spot.SpotBookings
						.Where(s => !s.IsApproved))
				{					
					Data.Add(new NotApproveSpotViewModel()
					{
						AssetCode = spotBooking.AssetCode,
						AssetDuration = spotBooking.AssetDuration,
						BroadcastDate = spot.BroadcastDate,
						ContractCode = spotBooking.AnnexContractAsset.AnnexContract.Code,
						IsRetail = spotBooking.IsRetailBooking,
						Position = spotBooking.Position,
						ProductName = spotBooking.AnnexContractAsset.Content.ProductName,
						SpotBookingId = spotBooking.Id,
						TimeBandName = spot.TimeBandName,
						TimeBandSliceName = spot.TimeBandSliceName,
					});
				}

			}
		}
	}
}