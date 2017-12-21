using HD.TVAD.Web.Services;
using HD.TVAD.ReportLibrary;
using HD.TVAD.ReportLibrary.SimplySpotSchedule;
using System;
using System.Collections.Generic;
using System.Linq;
using HD.TVAD.ApplicationCore.Entities.Booking;

namespace HD.TVAD.ReportLibrary
{
	public class SimplySpotScheduleDataSource : DataSource<SpotScheduleViewModel>
	{

		public SimplySpotScheduleDataSource(IServiceProvider serviceProvider,
			SimplySpotScheduleParameter parameter)
		{
			var spotService = serviceProvider.GetService(typeof(ISpotService)) as ISpotService;
			var timeBandService = serviceProvider.GetService(typeof(ITimeBandService)) as ITimeBandService;
			var timeBandSliceService = serviceProvider.GetService(typeof(ITimeBandSliceService)) as ITimeBandSliceService;
			var _timeBandSliceForTypeService = serviceProvider.GetService(typeof(ITimeBandSliceForTypeService)) as ITimeBandSliceForTypeService;

			var timeBandSliceForSimplySpot = _timeBandSliceForTypeService.GetAll()
				.Where(s => s.TypeId == (int)BookingTypeEnum.Retail)
				.ToList();

			var spots = spotService.GetAll()
				.Where(s => timeBandSliceForSimplySpot.Any(t => t.TimeBandSliceId == s.TimeBandSliceId))
				.Where(s => parameter.BroadcastDate.HasValue ? s.BroadcastDate == parameter.BroadcastDate : true);

			foreach (var spot in spots)
			{
				var timeBandDescription = timeBandService.GetTimeBandDescriptionByDate(spot.TimeBandId, spot.BroadcastDate);
				var timeBandSliceDescription = timeBandSliceService.GetTimeBandSliceDescriptionByDate(spot.TimeBandSliceId, spot.BroadcastDate);

				foreach (var spotBooking in spot.SpotBookings
					.Where(s => parameter.IsApproved ? s.IsApproved : true))
				{
					Data.Add(new SpotScheduleViewModel()
					{
						BroadcastDate = spot.BroadcastDate,
						ChannelName = spot.ChannelName,
						TimeBandName = spot.TimeBandName,
						TimeBandSlice = spot.TimeBandSlice.Name,
						TimeBandDescription = timeBandDescription,
						TimeBandSliceDescription = timeBandSliceDescription,
						AssetCode = spotBooking.AssetCode,
						Duration = spotBooking.AssetDuration,
						Content = spotBooking.AnnexContractAsset.Content.ProductName,
						//	Order = spotBooking.SpotAssetByBookings.SpotAsset.Index,
						FreeDuration = spotBooking.IsFreeBooking ? spotBooking.AssetDuration : 0,
						NotePage = "",
						Page = 0,
						CutOrder = 0,
						OnAirIndex = spotBooking.IsApproved ? spotBooking.SpotAssetByBookings.SpotAsset.Index : spotBooking.Position.GetValueOrDefault(),
					});
				}

				int page = 1;
				for (int i = 0; i < Data.Count;) // page sort default
				{
					if (Data[i].Page == 0)
					{
						if (i > 0 && Data[i].TimeBandName != Data[i - 1].TimeBandName)
							Data[i++].Page = ++page;
						else
							Data[i++].Page = page;
					}
					else
					{
						int j = i + 1;
						for (; j < Data.Count; j++)
							if (Data[i].Page != Data[j].Page)
								break;
							else
								Data[j].Page = page;
						Data[i].Page = page++;
						i = j;
					}
				}
				// Tách ghi chú
				for (int i = 0; i < Data.Count;)
				{
					SpotScheduleViewModel rBegin = Data[i];
					int j = i + 1;
					for (; j < Data.Count; j++)
					{
						SpotScheduleViewModel rIndex = Data[j];
						if (rIndex.BroadcastDate != rBegin.BroadcastDate ||
							rIndex.ChannelName.ToUpper() != rBegin.ChannelName.ToUpper() ||
							rIndex.Page != rBegin.Page)
							break;
					}
					TachGhiChu((List<SpotScheduleViewModel>)Data, i, j);
					i = j;
				}
			}
		}
		private void TachGhiChu(List<SpotScheduleViewModel> dtLichPS, int rowbegin, int rowend)
		{
			string GhiChuKenh = "";
			for (int i = rowbegin; i < rowend;)
			{
				int k = i + 1;
				for (; k < rowend; k++)
					if (dtLichPS[i].TimeBandName != dtLichPS[k].TimeBandName ||
						dtLichPS[i].TimeBandSlice != dtLichPS[k].TimeBandSlice)
						break;

				if (dtLichPS[i].TimeBandSliceDescription.Trim() != "")
				{
					string[] lines = dtLichPS[i].TimeBandSliceDescription.ToUpper().Split('\n');

					if (lines.Length > 0)
					{
						int index = 0;
						if (lines[index].Trim() == GhiChuKenh) index++;
						if (lines.Length - index >= 3)
							if (GhiChuKenh == "")
								GhiChuKenh = lines[index++].Trim();
						string GhiChuGio = "";
						if (lines.Length - index > 1)
						{
							GhiChuGio = lines[index++].Trim();
							for (int j = index; j < lines.Length - 1; j++)
								GhiChuGio += "\n" + lines[j].Trim();
						}
						if (GhiChuGio != "")
							for (int j = i; j < rowend; j++)
								if (dtLichPS[j].TimeBandName == dtLichPS[j].TimeBandName)
									dtLichPS[j].TimeBandDescription = GhiChuGio;
								else break;
						for (int j = i; j < k; j++)
							dtLichPS[j].TimeBandSliceDescription = lines[lines.Length - 1];
					}
				}
				i = k;
			}

			for (int i = rowbegin; i < rowend; i++)
				dtLichPS[i].NotePage = GhiChuKenh;

			for (int i = rowbegin; i < rowend;)
			{
				int k = i + 1;
				for (; k < rowend; k++)
					if (dtLichPS[i].TimeBandName != dtLichPS[k].TimeBandName ||
						dtLichPS[i].TimeBandSlice != dtLichPS[k].TimeBandSlice)
						break;

				string GhiChuGio = dtLichPS[i].TimeBandDescription;
				string GhiChuCut = dtLichPS[i].TimeBandSliceDescription;
				if (GhiChuGio != "")
				{
					if (GhiChuKenh == "")
					{
						for (int j = i; j < rowend; j++)
						{
							if (dtLichPS[i].TimeBandName.ToUpper() == dtLichPS[j].TimeBandName.ToUpper() &&
								dtLichPS[i].TimeBandDescription == GhiChuGio)
								dtLichPS[j].TimeBandDescription = GhiChuCut;
							else
								break;
						}
						for (int l = i; l < k; l++)
						{
							dtLichPS[i].NotePage = GhiChuGio;
							dtLichPS[l].TimeBandSliceDescription = "";
						}
					}
					else
					{
						string[] lines = dtLichPS[i].TimeBandDescription.Split('\n');
						if (lines[0] == GhiChuKenh)
						{
							if (lines.Length > 1)
							{
								GhiChuGio = lines[1];
								for (int j = 1; j < lines.Length; j++)
									GhiChuGio += "\n" + lines[j];
							}
							else GhiChuGio = "";
							dtLichPS[i].TimeBandDescription = GhiChuGio;
						}
					}
				}
				if (dtLichPS[i].TimeBandDescription == "")
				{
					for (int j = i; j < rowend; j++)
					{
						if (dtLichPS[i].TimeBandName.ToUpper() == dtLichPS[j].TimeBandName.ToUpper() &&
							dtLichPS[j].TimeBandDescription == "")
							dtLichPS[j].TimeBandDescription = GhiChuCut;
						else
							break;
					}
					for (int l = i; l < k; l++)
						dtLichPS[l].TimeBandSliceDescription = "";
				}
				i = k;
			}
		}
	}
}