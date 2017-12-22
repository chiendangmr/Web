using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HD.TVAD.Web.Services;
using HD.TVAD.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using HD.TVAD.Web.Features.Manager;
using Microsoft.Extensions.Options;
using HD.Station.WebComponents.Fieldset;
using HD.TVAD.Web.Features.Delay.Business;
using HD.Workflow.Data;
using HD.Station.MediaAssets;
using Microsoft.AspNetCore.Identity;
using HD.TVAD.Entities.Entities.Security;
using System.Text.RegularExpressions;
using HD.Station.MediaAssets.Data;
using HD.TVAD.Web.Infrastructure;
using HD.TVAD.Web.StartData;

namespace HD.TVAD.Web.Features.Delay
{
    [Area("MAM")]
    [Authorize]
	public class DelayController : TVADController
    {
        private readonly IOptions<Settings> _settings;
        private IContentService _contentService;
        private IRegisterService _registerService;
        private Services.IMediaAssetService _mediaAssetService;
        private DelayBusiness _fileBusiness;

        private MetadataServiceProvider DataProvider;
        private readonly INotificationService _notificationService;
        private readonly UserManager<User> _userManager;

        public DelayController(
            IOptions<Settings> settings,
            IContentService contentService,
            MetadataServiceProvider contentMetadataDataProvider,
            IHostingEnvironment hostingEnvironment, WorkflowDataProvider workflowDataProvider, Station.MediaAssets.IMediaAssetService mediaAssetService,
            INotificationService notificationService,
            UserManager<User> userManager,
            IRegisterService registerService,
            Services.IMediaAssetService mediaAssetBusiness
            )
        {
            _settings = settings;
            _contentService = contentService;
            DataProvider = contentMetadataDataProvider;
            _fileBusiness = new DelayBusiness(hostingEnvironment, workflowDataProvider, mediaAssetService);
            _notificationService = notificationService;
            _userManager = userManager;
            _registerService = registerService;
            _mediaAssetService = mediaAssetBusiness;
        }
        [HttpGet]
		[RequiresPermission(UserPermissions.ImportData_Asset)]
		public IActionResult Index()
        {
            return View();
        }
        
        private string getNumber(string str)
        {
            var number = Regex.Match(str, @"\d+").Value;

            return number;
        }
    }
}