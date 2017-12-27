using Microsoft.AspNetCore.Mvc;
using HD.TVAD.Web.Services;
using System.Linq;
using System;
using HD.TVAD.Web.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using HD.TVAD.Web.Features.MAM.Content.Business;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Threading.Tasks;
using HD.TVAD.Web.Features.Manager;

namespace HD.TVAD.Web.Features.MAM.Evidence
{
    [Area("MAM")]
    [Authorize]
    public class DelayController : TVADController
    {
        private IEvidenceService _evidenceService;        
        private IAssetService _assetService;
        private DelayBusiness _evidenceBusiness;

        public DelayController(IAssetService assetService, IStorageService storageService, IEvidenceService evidenceService,
             IAssetTypeService assetTypeService, IStorageLocationService storageLocationService,IHostingEnvironment hostingEnvironment, IOptions<Settings> settings)
        {
            _evidenceService = evidenceService;            
            _assetService = assetService;
            _evidenceBusiness = new DelayBusiness(assetService, storageService, evidenceService,
                assetTypeService, storageLocationService, hostingEnvironment, settings);
        }
        public IActionResult Index()
        {            
            return View();
        }
        [HttpGet]
        public async Task<List<EvidenceViewModel>> GetAllEvidenceAsync(Guid channelId, DateTimeOffset date)
        {
            var vM = await _evidenceBusiness.GetEvidences(channelId, date);
            return vM;
        }        
    }
}