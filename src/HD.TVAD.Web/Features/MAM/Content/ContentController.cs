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
using HD.TVAD.Web.Features.MAM.Content.Business;
using HD.Workflow.Data;
using HD.Station.MediaAssets;
using Microsoft.AspNetCore.Identity;
using HD.TVAD.Entities.Entities.Security;
using System.Text.RegularExpressions;
using HD.Station.MediaAssets.Data;
using HD.TVAD.Web.Infrastructure;
using HD.TVAD.Web.StartData;

namespace HD.TVAD.Web.Features.MAM.Assets
{
    [Area("MAM")]
    [Authorize]
	public class ContentController : TVADController
    {
        private readonly IOptions<Settings> _settings;
        private IContentService _contentService;
        private IRegisterService _registerService;
        private Services.IMediaAssetService _mediaAssetService;
        private FileBusiness _fileBusiness;

        private MetadataServiceProvider DataProvider;
        private readonly INotificationService _notificationService;
        private readonly UserManager<User> _userManager;

        public ContentController(
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
            _fileBusiness = new FileBusiness(hostingEnvironment, workflowDataProvider, mediaAssetService);
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
        [HttpGet]
        public async Task<IActionResult> GetAllAssetForGridAsync([DataSourceRequest]DataSourceRequest request)
        {
            var assets = _contentService.GetAll()
				.ToIQueryableViewModel();

            var dataSourceResult = await assets.ToDataSourceResultAsync(request);

            return Json(dataSourceResult);
        }
        [HttpGet]
        public async Task<IActionResult> GetAssetByCodeAPIAsync(string assetCode)
        {
            try
            {
                var asset = await _contentService.FindByCodeAsync(assetCode);
                if (asset != null)
                {
                    var assetViewModel = asset.ToViewModel();

                    return Json(new ResponseJsonResult()
                    {
                        Succeeded = true,
                        Data = assetViewModel,
                        Message = "",
                    });

                }
                else
                {
                    throw new Exception("Not exist code!");
                }


            }
            catch (Exception ex)
            {
                return Json(new ResponseJsonResult()
                {
                    Succeeded = false,
                    Message = ex.Message,
                });
            }
        }
        [HttpGet]
        public async Task<IActionResult> PreviewAndApproveAsync(Guid contentId)
        {
            try
            {
                var content = await _contentService.Get(contentId).FirstOrDefaultAsync();
                if (content != null)
                {
                    var model = new PreviewAndApproveViewModel()
                    {
                        ContentId = contentId,
                        AssetVMs = await GetAllAssetForContentAsync(contentId, _settings.Value.AppSettings.AssetTypeTVCId),
                        ProviderId = _settings.Value.AppSettings.ProviderId,
                        WorkflowId = await _fileBusiness.GetWorkflowId(contentId)
                    };

                    return View(model);
                }
                else
                {
                    throw new NullReferenceException();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
		[RequiresPermission(UserPermissions.ImportData_Asset_CRUD)]
		public IActionResult Create(Guid lastContentId)
        {
            var assetCreateViewModel = new ContentCreateViewModel()
            {
                LastAssetId = lastContentId,
            };
            return View(assetCreateViewModel);
        }
        [HttpGet]
		public IActionResult Detail(Guid id)
        {
            var viewModel = new ContentViewModel()
            {
                Id = id,
            };
            return View(viewModel);
        }
        [HttpGet]
		[RequiresPermission(UserPermissions.ImportData_Asset_CRUD)]
		public IActionResult Edit(Guid id)
        {
            var viewModel = new ContentViewModel
            {
                Id = id,
            };
            return View(viewModel);
        }
        [HttpPost]
		[RequiresPermission(UserPermissions.ImportData_Asset_CRUD)]
		public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var asset = await _contentService.Get(id).FirstOrDefaultAsync();
                if (asset.HasBooking)
                {
                    return Json(new JsonResponse("ERROR", "This content was booked!"));
                }
                else
                {
                    var result = await _contentService.Delete(asset);
                    return JsonResponse(result, ActionType.Delete);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateMetadata([FromForm]Guid? id)
        {
            try
            {
                var profileId = _settings.Value.AppSettings.ProfileId;

                var start = DateTime.Now;
                var formData = HttpContext.Request.Form;
                var contentCode = formData["Code"].FirstOrDefault();
                if (contentCode == null)
                    throw new Exception("Code is empty!");

                if (!id.HasValue) // create
                {
                    if (await _contentService.ExistCodeAsync(contentCode))
                        throw new Exception($"Exist code {contentCode}!");

                    var sqlOperationResult = await DataProvider.SetValuesAsync(Guid.Parse(profileId), Guid.Empty, formData);
                    var result = sqlOperationResult["Main"];
                    if (result.Succeeded)
                    {
                        var user = await _userManager.GetUserAsync(User);
                        var notifi = new ApplicationCore.Entities.Notification($"{user.UserName} {ActionType.Create.GetDisplayName()} a content");
                        await _notificationService.MakeNotificationAsync(notifi);

                        return Json(new UpdateContentJsonResult()
                        {
                            Id = result.Id,
                            Succeeded = result.Succeeded,
                            Message = "Created",
                            DebugMessage = result.Message,
                        });
                    }
                    else
                    {
                        return Json(new UpdateContentJsonResult()
                        {
                            Id = result.Id,
                            Succeeded = result.Succeeded,
                            Message = "Something wrong!",
                            DebugMessage = result.Message,
                        });

                    }
                }
                else // update
                {

                    var content = await _contentService.Get(id.Value).FirstOrDefaultAsync();
                    if (content == null)
                        throw new Exception("Not exist content!");
                    if (content.Code != contentCode) // change code
                    {
                        if (await _contentService.ExistCodeAsync(contentCode))
                            throw new Exception($"Exist code {contentCode}!");
                    }

                    var sqlOperationResult = await DataProvider.SetValuesAsync(Guid.Parse(profileId), id.Value, formData);
                    var result = sqlOperationResult["Main"];
                    if (result.Succeeded)
                    {
                        return Json(new UpdateContentJsonResult()
                        {
                            Id = result.Id,
                            Succeeded = result.Succeeded,
                            Message = "Updated",
                            DebugMessage = result.Message,
                        });
                    }
                    else
                    {
                        return Json(new UpdateContentJsonResult()
                        {
                            Id = result.Id,
                            Succeeded = result.Succeeded,
                            Message = "Something wrong!",
                            DebugMessage = result.Message,
                        });

                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new UpdateContentJsonResult()
                {
                    Succeeded = false,
                    Message = ex.Message,
                });
            }

        }

        [HttpGet]
        public async Task<ActionResult> ViewDoc(Guid contentId)
        {
            try
            {
                var content = await _contentService.Get(contentId).FirstOrDefaultAsync();
                if (content != null)
                {
                    var model = new PreviewAndApproveViewModel()
                    {
                        ContentId = contentId,
                        AssetVMs = await _fileBusiness.GetLstAssetVM(contentId, _settings.Value.AppSettings.AssetTypeDocsId),
                        ProviderId = _settings.Value.AppSettings.ProviderId,
                        WorkflowId = await _fileBusiness.GetWorkflowId(contentId)
                    };

                    return View(model);
                }
                else
                {
                    throw new NullReferenceException();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public async Task<List<Station.MediaAssets.Models.AssetVM>> GetAllAssetForContentAsync(Guid contentId, Guid assetTypeId)
        {
            if (assetTypeId == _settings.Value.AppSettings.AssetTypeDocsId || assetTypeId == _settings.Value.AppSettings.AssetTypeLowresId)
            {
                return await _fileBusiness.GetLstAssetVM(contentId, assetTypeId);
            }
            else
            {
                var lstSD = await _fileBusiness.GetLstAssetVM(contentId, _settings.Value.AppSettings.AssetTypeTVCId);
                var lstHD = await _fileBusiness.GetLstAssetVM(contentId, _settings.Value.AppSettings.AssetTypeTVCHDId);
                return lstSD.Concat(lstHD).ToList();
            }

        }
        [HttpPost]
        public async Task<PreviewViewModel> GetLstPreviewObj(Guid assetId)
        {
            var lstPreviewUrl = await _fileBusiness.GetLstPreviewUrl(assetId);
            var vM = await _fileBusiness.GetMediaAssetVM(assetId);
            return new PreviewViewModel
            {
                LstPreviewUrl = lstPreviewUrl,
                MarkIn = vM.MarkIn,
                MarkOut = vM.MarkOut
            };
        }
        [HttpPost]
        public async Task<List<string>> GetLstDocsUrl(Guid assetId)
        {
            return await _fileBusiness.GetLstDocsUrl(assetId);
        }
        [HttpPost]
        public async Task<OperationResult> SetAssetActive(ContentActiveAsset contentActiveAsset)
        {
            return await _fileBusiness.SetAssetActive(contentActiveAsset);
        }
        [HttpPost]
        public async Task<string> GenerateProductCode(Guid registerId)
        {
            var result = "";
            var register = await _registerService.Get(registerId).FirstOrDefaultAsync();
            var lstCode = await _contentService.GetAll().Where(a => a.Code.StartsWith(register.Code)).Select(a => a.Code).ToListAsync();
            var lstNumber = new List<int>();
            if (lstCode.Count > 0)
            {
                foreach (var code in lstCode)
                {
                    var number = getNumber(code);
                    if (number != "")
                        lstNumber.Add(int.Parse(number));
                }
                result = register.Code + (lstNumber.Max() + 1).ToString();
            }
            else result = register.Code + "1";
            return result;
        }
        [HttpPost]
        public async Task<OperationResult> SaveVideoCut(MediaAssetViewModel viewModel)
        {
            try
            {
                var data = await _mediaAssetService.Get(viewModel.Id).FirstOrDefaultAsync();
                data.MarkIn = viewModel.MarkIn;
                data.MarkOut = viewModel.MarkOut;
                var result = await _mediaAssetService.Update(data);
                return OperationResult.Success;
            }
            catch
            {
                //return OperationResult.Failed();
                throw;
            }
        }
        private string getNumber(string str)
        {
            var number = Regex.Match(str, @"\d+").Value;

            return number;
        }
    }
}