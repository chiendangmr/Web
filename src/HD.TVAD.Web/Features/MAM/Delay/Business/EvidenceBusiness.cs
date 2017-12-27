using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.ApplicationCore.Entities.MediaAsset;
using HD.TVAD.Web.Models;
using HD.TVAD.Web.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.MAM.Content.Business
{
    public class DelayBusiness
    {
        private readonly IOptions<Settings> _settings;
        private IChannelService _channelService;
        private IAssetService _assetService;
        private IStorageService _storageService;
        private IEvidenceService _evidenceService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private IAssetTypeService _assetTypeService;
        private IStorageLocationService _storageLocationService;
        public DelayBusiness(IChannelService channelService, IAssetService assetService, IStorageService storageService, IEvidenceService evidenceService,
             IAssetTypeService assetTypeService, IStorageLocationService storageLocationService,IHostingEnvironment hostingEnvironment, IOptions<Settings> settings)
        {
            _channelService = channelService;
            _assetService = assetService;
            _assetTypeService = assetTypeService;
            _storageService = storageService;
            _evidenceService = evidenceService;
            _storageLocationService = storageLocationService;
            _hostingEnvironment = hostingEnvironment;
            _settings = settings;
        }        
        public async Task<List<EvidenceViewModel>> GetEvidences(Guid channelId, DateTimeOffset recordTime)
        {
            var channel = await _channelService.Get(channelId).FirstOrDefaultAsync();
            var lstEnvidence = await _evidenceService.GetAll().Where(a => a.ChannelId == channelId && a.RecordTime.Date == recordTime.Date).ToListAsync();
            var lstAssetId = lstEnvidence.Select(a => a.AssetId).ToList();
            var lstAssetIsEvidence = new List<EvidenceViewModel>();
            var rootEvidencePath = await GetEvidencePath(_settings.Value.AppSettings.AssetTypeEvidenceId);
            foreach (var evidence in lstEnvidence)
            {
                if (evidence.Asset.AssetTypeId == _settings.Value.AppSettings.AssetTypeEvidenceId)
                {
                    var asset = await _assetService.Get(evidence.AssetId).FirstOrDefaultAsync();
                    lstAssetIsEvidence.Add(new EvidenceViewModel
                    {
                        Id = evidence.Id,
                        ChannelId = channelId,
                        ChannelName = channel.TimeBandBase.Name,
                        AssetId = evidence.Asset.Id,
                        MediaAssetId = asset.MediaAssetId,
                        AssetName = evidence.Asset.Name,
                        FileName = evidence.Asset.FileName,
                        Path = Path.Combine(rootEvidencePath, asset.AssetLocators.FirstOrDefault().Path),
                        RecordTime = evidence.RecordTime,
                        UploadedDate = asset.AssetLocators.FirstOrDefault().UploadedDate
                    });
                }
            }
            return lstAssetIsEvidence;
        }

        public async Task<List<StorageLocation>> GetStorageLocationFromAssetType(Guid assetTypeId)
        {
            var lstStorageLocation = (await _assetTypeService.Get(assetTypeId).FirstOrDefaultAsync()).StorageLocations.ToList();            

            return lstStorageLocation;
        }
        public async Task<List<StorageLocationAccess>> GetStorageLocationAccessFromStorageLocation(Guid storageLocationId)
        {
            var lstStorageLocationAccess = (await _storageLocationService.Get(storageLocationId).FirstOrDefaultAsync()).StorageLocationAccesses.ToList();
            return lstStorageLocationAccess;
        }
        public async Task<string> GetEvidencePath(Guid assetTypeId)
        {
            var assetTypePath = (await _assetTypeService.Get(assetTypeId).FirstOrDefaultAsync()).DefaultPath;
            assetTypePath = assetTypePath == null ? "" : assetTypePath;
            var _storageLocationId = (await GetStorageLocationFromAssetType(assetTypeId)).FirstOrDefault().Id;
            var storageLocationAccessPath = (await GetStorageLocationAccessFromStorageLocation(_storageLocationId)).FirstOrDefault().Path;
            return Path.Combine(storageLocationAccessPath, assetTypePath);
        }
    }
}
