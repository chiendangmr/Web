using HD.TVAD.ApplicationCore.Entities.Storage;
using HD.TVAD.Services.PriceCalculation;
using HD.TVAD.Web.Reporting.Helper;
using HD.TVAD.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.ReportLibrary.SpotValueReportSponsorByAssetType
{
	public class SpotValueReportSponsorByAssetTypeDataSource : DataSource<SpotValueReportSponsorByAssetTypeViewModel>
	{
		public SpotValueReportSponsorByAssetTypeDataSource(IServiceProvider serviceProvider, SpotValueReportSponsorByAssetTypeParameter parameter)
		{
			var parameterHelper = new ParameterHelper<SpotValueReportSponsorByAssetTypeParameter>(parameter);

			var spotService = serviceProvider.GetService(typeof(ISpotService)) as ISpotService;
			var contentService = serviceProvider.GetService(typeof(IContentService)) as IContentService;
			var priceCalculationService = serviceProvider.GetService(typeof(IPriceCalculationService)) as IPriceCalculationService;

			var spots = spotService.GetAll().ToList()
				.Where(s => parameterHelper.IsAllTime ? true : s.BroadcastDate >= parameterHelper.FromDate && s.BroadcastDate <= parameterHelper.ToDate)
				.Where(s=> parameter.ChannelId.HasValue? s.ChannelId == parameter.ChannelId: true)
				.ToList();

			var spotBookings = spots.SelectMany(s => s.SpotBookings)
					.Where(s => s.IsNormalBooking)
					.Where(s => s.HasSponsorProgram)
					.Where(s => parameter.IsApproved ? s.IsApproved : true);
			foreach (var spotBooking in spotBookings)
			{
				var asset = contentService.Get(spotBooking.ContentId).FirstOrDefault();
				var freeDuration = 0;
				var freeValue = 0;
				var intoValue = 0M;
				var introDuration = 0;
				var panelDuration = 0;
				var panelValue = 0M;
				var TVCDuration = 0;
				var TVCValue = 0M;
				if (spotBooking.IsFreeBooking)
				{
					freeDuration = spotBooking.AssetDuration;					
				}
				else
				{
					switch (asset.Type.FileTypeId.Value)
					{
						case (int)FileTypeEnum.TVC:
							TVCDuration = spotBooking.AssetDuration;
							TVCValue = priceCalculationService.GetTotalAfterDiscount(spotBooking).GetValueOrDefault();
							break;
						case (int)FileTypeEnum.Popup:
							panelDuration = spotBooking.AssetDuration;
							panelValue = priceCalculationService.GetTotalAfterDiscount(spotBooking).GetValueOrDefault();
							break;
						default:
							break;
					}
				}
				Data.Add(new SpotValueReportSponsorByAssetTypeViewModel()
				{
					AssetCode = spotBooking.AssetCode,
					BookingId = spotBooking.Id,
					SponsorProgramName = spotBooking.SponsorProgramName,
					SponsorProgramCode = spotBooking.SponsorProgramCode,
					ChannelName = spotBooking.Spot.ChannelName,
					CustomerName = spotBooking.CustomerName,
					SpotId = spotBooking.Spot.Id,
					FreeDuration = freeDuration,
					FreeValue = freeValue,
					IntoValue = intoValue,
					IntroDuration = introDuration,
					PanelDuration = panelDuration,
					PanelValue = panelValue,
					TVCDuration = TVCDuration,
					TVCValue = TVCValue,
				});
			}			
		}
	}
}
