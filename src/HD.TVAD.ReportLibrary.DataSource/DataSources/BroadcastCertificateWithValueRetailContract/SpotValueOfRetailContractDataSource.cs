using HD.TVAD.Web.Services;
using HD.TVAD.ReportLibrary;
using HD.TVAD.ReportLibrary.BroadcastCertificate;
using HD.TVAD.ReportLibrary.BroadcastCertificateWithValueContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HD.TVAD.ReportLibrary.BroadcastCertificateWithValueRetailContract;

namespace HD.TVAD.ReportLibrary.SpotValueOfRetailContract
{
    public class SpotValueOfRetailContractDataSource : DataSource<SpotValueOfRetailContractViewModel>
    {
		public SpotValueOfRetailContractDataSource(ISpotService spotService, SpotValueOfRetailContractParameter parameter)
		{
			var spots = spotService.GetAll()
			//	.Where(s => parameter.IsAllTime ? true : s.BroadcastDate >= parameter.FromDate && s.BroadcastDate <= parameter.ToDate)
				.ToList();

			foreach (var spot in spots)
			{
				foreach (var spotBooking in spot.SpotBookings
					.Where(s=> s.IsApproved)
					.Where(s => s.AnnexContractAsset.AnnexContract.Id == parameter.AnnexContractId))
				{
					Data.Add(new SpotValueOfRetailContractViewModel() {
						AssetCode = spotBooking.AssetCode,
						TimeBandName = spot.TimeBandName,
						Duration = spotBooking.AssetDuration,
						Price = 100,						
						TotalValue = 1000,						
					});
				}
			}
			
		}
    }
}
