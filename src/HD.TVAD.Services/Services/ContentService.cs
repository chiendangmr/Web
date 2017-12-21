using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HD.Station;


namespace HD.TVAD.Web.Services
{
	[Service(ServiceType = typeof(IContentService))]
	public class ContentService : Service<Content, IContentRepository>, IContentService
	{
		private readonly IAnnexContractAssetService _annexContractAssetService;
		private readonly ISpotService _spotService;
		private readonly ITimeBandService _timeBandService;
		private readonly IChannelService _channelService;
		private readonly ITimeBandSliceService _timeBandSliceService;
		private readonly IContentTimeBandLockService _contentTimeBandLockService;
		private readonly IContentChannelLockService _contentChannelLockService;
		private readonly IContentChannelLockTimeBandBaseNoLockService _contentChannelLockTimeBandBaseNoLockService;
		public ContentService(IContentRepository repository,
			IAnnexContractAssetService annexContractAssetService,
			ISpotService spotService,
			IContentTimeBandLockService contentTimeBandLockService,
			IContentChannelLockService contentChannelLockService,
			IContentChannelLockTimeBandBaseNoLockService contentChannelLockTimeBandBaseNoLockService,
			ITimeBandService timeBandService,
			IChannelService channelService,
			ITimeBandSliceService timeBandSliceService) : base(repository)
		{
			_annexContractAssetService = annexContractAssetService;
			_spotService = spotService;
			_contentTimeBandLockService = contentTimeBandLockService;
			_contentChannelLockService = contentChannelLockService;
			_contentChannelLockTimeBandBaseNoLockService = contentChannelLockTimeBandBaseNoLockService;
			_timeBandService = timeBandService;
			_timeBandSliceService = timeBandSliceService;
			_channelService = channelService;
		}

		public Task<Content> FindByCodeAsync(string code)
		{
			var result = _repository.List().Where(s => s.Code == code).FirstOrDefaultAsync();
			return result;
		}
		public async Task<bool> ExistCodeAsync(string code)
		{
			var result = await _repository.List()
				.AnyAsync(s => s.Code == code);

			return result;
		}

		public async Task<bool> CheckAllowBookingAsync(SpotBooking spotBooking)
		{
			var annexContractAsset = await _annexContractAssetService.Get(spotBooking.AnnexContractAssetId).FirstOrDefaultAsync();
			if (annexContractAsset == null)
				throw new Exception($"Not found AnnexContractAssetId {spotBooking.AnnexContractAssetId.ToString()}");
			Guid timeBandId;
			DateTime broadcastDate;

			if (spotBooking.Spot != null) // not exist spot in database
			{
				broadcastDate = spotBooking.Spot.BroadcastDate;
				var timebandSlice = await _timeBandSliceService.Get(spotBooking.Spot.TimeBandSliceId).FirstOrDefaultAsync();
				timeBandId = timebandSlice.TimeBandId;
			}
			else //exist spot in database
			{
				var spot = await _spotService.Get(spotBooking.SpotId).FirstOrDefaultAsync();
				if (spot == null)
					throw new Exception($"Not found SpotId {spotBooking.SpotId.ToString()}");
				broadcastDate = spot.BroadcastDate;
				timeBandId = spot.TimeBandId;
			}

			var content = await _repository.Get(annexContractAsset.ContentId).FirstOrDefaultAsync();
			if (content == null)
				throw new Exception($"Not found contentId {annexContractAsset.ContentId.ToString()}");

			if (!content.IsApproved)
				throw new Exception($"Not approve asset yet");

			if (content.ApproveEndDate.HasValue && (content.ApproveEndDate.Value < broadcastDate))
				throw new Exception($"Asset code {content.Code} expiry from {content.ApproveEndDate.Value.ToString("dd/MM/yyyy")}");

			await CheckAllowBookingOnTimeBandAsync(timeBandId, content.Id, broadcastDate);
			await CheckAllowBookingOnChanelAsync(timeBandId, content.Id, broadcastDate);
			return true;
		}
		private async Task<bool> CheckAllowBookingOnTimeBandAsync(Guid timeBandId, Guid contentId, DateTime broadcastDate)
		{
			var timeBand = await _timeBandService.Get(timeBandId).FirstOrDefaultAsync();
			var content = await _repository.Get(contentId).FirstOrDefaultAsync();

			var timbandIdsLock = _contentTimeBandLockService.GetAll()
				.Where(c => c.ContentId == contentId)
				.Where(c => c.StartDate.HasValue ? c.StartDate.Value < broadcastDate : true); // TODO check endate...
			if (timbandIdsLock.Any(t => t.TimeBandId == timeBandId))
				throw new Exception($"Not allow book asset {content.Code} at timeband {timeBand.TimeBandName} on {broadcastDate.ToString("dd/MM/yyyy")}");

			return true;
		}
		private async Task<bool> CheckAllowBookingOnChanelAsync(Guid timeBandId, Guid contentId, DateTime broadcastDate)
		{
			var timeBand = await _timeBandService.Get(timeBandId).FirstOrDefaultAsync();
			var channelId = await _channelService.GetChannelIdOfTimeBandAsync(timeBandId);
			var channel = await _channelService.Get(channelId).FirstOrDefaultAsync();
		//	var parentIs = await _channelService.GetParentIdsOfTimeBandAsync(timeBandId);
			var content = await _repository.Get(contentId).FirstOrDefaultAsync();

			var channelsLock = _contentChannelLockService.GetAll()
				.Where(c => c.ContentId == contentId)
				.Where(c => c.StartDate.HasValue ? c.StartDate.Value < broadcastDate : true); // TODO check endate...

			if (channelsLock.Any(t => t.ChannelId == channelId))
			{
				var channelLock = await channelsLock
				.Where(c => c.ChannelId == channelId)
				.Where(c => c.StartDate.HasValue ? c.StartDate.Value < broadcastDate : true)
				.FirstOrDefaultAsync(); // TODO check endate... , check many startdate

				var timeBandBaseNoLocks = _contentChannelLockTimeBandBaseNoLockService.GetAll()
					.Where(c => c.LockId == channelLock.Id);
				if (!timeBandBaseNoLocks.Any(t => t.TimeBandBaseId == timeBandId)) // TODO check many child of timebandbase
				{
					throw new Exception($"Not allow book asset {content.Code} at channel {channel.TimeBandBase.Name} - timeband {timeBand.TimeBandName} on {broadcastDate.ToString("dd/MM/yyyy")}");

				}
			}

			return true;
		}
	}    
}
