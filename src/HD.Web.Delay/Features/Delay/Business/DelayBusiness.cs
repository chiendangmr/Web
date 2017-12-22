using HD.Station.MediaAssets;
using HD.Station.MediaAssets.Data;
using HD.Station.MediaAssets.Models;
using HD.TVAD.ApplicationCore.Entities;
using HD.TVAD.Web.Models;
using HD.TVAD.Web.Services;
using HD.Workflow.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Delay.Business
{
    public class DelayBusiness
    {               
        private readonly IHostingEnvironment _hostingEnvironment;
        private WorkflowDataProvider _workflowDataProvider;
        private Station.MediaAssets.IMediaAssetService _mediaAssetService;

        public DelayBusiness(IHostingEnvironment hostingEnvironment, WorkflowDataProvider workflowDataProvider, Station.MediaAssets.IMediaAssetService mediaAssetService)
        {
            _workflowDataProvider = workflowDataProvider;
            _mediaAssetService = mediaAssetService;            
            _hostingEnvironment = hostingEnvironment;            
        }
        public async Task<Guid> GetWorkflowId(Guid contentId)
        {
            var workflow = await _workflowDataProvider.GetMainWorkflowByExternalIdAsync(contentId);
            var workflowId = workflow != null ? workflow.Id : Guid.Empty;
            return workflowId;
        }
        public async Task<List<AssetVM>> GetLstAssetVM(Guid contentId, Guid AssetTypeId)
        {
            return await _mediaAssetService.LstAssetByTypeIdAsync(contentId, AssetTypeId);
        }
        public async Task<List<string>> GetLstPreviewUrl(Guid assetId)
        {
            return await _mediaAssetService.LstPreviewUrlAsync(assetId);
        }
        public async Task<MediaAssetVM> GetMediaAssetVM(Guid assetId)
        {
            return await _mediaAssetService.GetMediaAssetAsync(assetId);
        }
        public async Task<List<string>> GetLstDocsUrl(Guid assetId)
        {
            return await _mediaAssetService.LstDocsUrlAsync(assetId);
        }
        public async Task<OperationResult> SetAssetActive(ContentActiveAsset contentActiveAsset)
        {
            return await _mediaAssetService.ActiveAssetAsync(contentActiveAsset);
        }
    }
}
