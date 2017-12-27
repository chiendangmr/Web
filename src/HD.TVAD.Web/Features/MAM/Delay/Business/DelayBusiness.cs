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
        private IAssetService _assetService;
        private IStorageService _storageService;
        private IEvidenceService _evidenceService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private IAssetTypeService _assetTypeService;
        private IStorageLocationService _storageLocationService;
        public DelayBusiness(IAssetService assetService, IStorageService storageService, IEvidenceService evidenceService,
             IAssetTypeService assetTypeService, IStorageLocationService storageLocationService,IHostingEnvironment hostingEnvironment, IOptions<Settings> settings)
        {            
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
            var lstAssetIsEvidence = new List<EvidenceViewModel>();            
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
