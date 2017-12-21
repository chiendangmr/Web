using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HD.TVAD.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using HD.TVAD.ApplicationCore.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using HD.TVAD.ApplicationCore.Entities.Storage;
using HD.TVAD.Web.Features.Manage.MAM.Services;
using HD.TVAD.Web.Storage.Models;
using HD.TVAD.Web.Models;
using HD.TVAD.Web.Features.Manager;

namespace HD.TVAD.Web.Features.Manage
{
    [Area("Tools")]
    [Authorize]
    public class StorageController : TVADController
    {
        private StorageBusiness _storageBussiness;
        public StorageController(IStorageService storageService,
            IHostingEnvironment hostingEnvironment, IAssetTypeService assetTypeService, IAssetLocatorService assetLocatorService, IStorageLocationAccessTypeService storageLocationAccessTypeService)
        {
            _storageBussiness = new StorageBusiness(storageService, 
                 hostingEnvironment, assetTypeService, assetLocatorService, storageLocationAccessTypeService);
        }
        #region View
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult StorageLocationAccessType()
        {
            return View();
        }        
        
        #region Create


        [HttpGet]
        public ActionResult CreateStorageView()
        {
            return View();
        }      
        
        
        [HttpGet]
        public ActionResult CreateAssetTypeView()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateAssetLocatorView()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateAccessZoneView()
        {
            return View();
        }
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult EditStorageView(Guid id)
        {
            var vM = _storageBussiness.GetStorage(id).Result;
            return View(vM);
        }        
        
        [HttpGet]
        public ActionResult EditAssetTypeView(Guid id)
        {
            var vM = _storageBussiness.GetAssetType(id).Result;
            return View(vM);
        }
        [HttpGet]
        public ActionResult EditAssetLocatorView(Guid id)
        {
            var vM = _storageBussiness.GetAssetLocator(id).Result;
            return View(vM);
        }
        
        #endregion
        [HttpGet]
        public ActionResult DeleteStorageView(Guid id)
        {
            var vM = _storageBussiness.GetStorage(id).Result;
            return View(vM);
        }        
        
        [HttpGet]
        public ActionResult DeleteAssetTypeView(Guid id)
        {
            var vM = _storageBussiness.GetAssetType(id).Result;
            return View(vM);
        }
        [HttpGet]
        public ActionResult DeleteAssetLocatorView(Guid id)
        {
            var vM = _storageBussiness.GetAssetLocator(id).Result;
            return View(vM);
        }
        
        #endregion

        #region Create Action
        [HttpPost]
        public async Task<IActionResult> CreateStorage(StorageViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _storageBussiness.CreateStorageAsync(viewModel);

                if (result)
                    return Json(new JsonResponse("OK", "Created!"));
                else
                    return Json(new JsonResponse("ERROR", "Fail!"));

            }
            else
            {
                return Json(ModelState);
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAssetType(Storage.Models.AssetTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _storageBussiness.CreateAssetTypeAsync(viewModel);

                if (result)
                    return Json(new JsonResponse("OK", "Created!"));
                else
                    return Json(new JsonResponse("ERROR", "Fail!"));

            }
            else
            {
                return Json(ModelState);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateAssetLocator(AssetLocatorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _storageBussiness.CreateAssetLocatorAsync(viewModel);

                if (result)
                    return Json(new JsonResponse("OK", "Created!"));
                else
                    return Json(new JsonResponse("ERROR", "Fail!"));

            }
            else
            {
                return Json(ModelState);
            }
        }
        
        #endregion

        #region Edit Action
        [HttpPost]
        public async Task<IActionResult> EditStorage(StorageViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _storageBussiness.EditStorageAsync(viewModel);

                if (result)
                    return Json(new JsonResponse("OK", "Edited!"));
                else
                    return Json(new JsonResponse("ERROR", "Fail!"));

            }
            else
            {
                return Json(ModelState);
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> EditAssetType(Storage.Models.AssetTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _storageBussiness.EditAssetTypeAsync(viewModel);

                if (result)
                    return Json(new JsonResponse("OK", "Edited!"));
                else
                    return Json(new JsonResponse("ERROR", "Fail!"));

            }
            else
            {
                return Json(ModelState);
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditAssetLocator(AssetLocatorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _storageBussiness.EditAssetLocatorAsync(viewModel);

                if (result)
                    return Json(new JsonResponse("OK", "Edited!"));
                else
                    return Json(new JsonResponse("ERROR", "Fail!"));

            }
            else
            {
                return Json(ModelState);
            }
        }
        
        #endregion

        #region Delete Action
        [HttpPost]
        public async Task<IActionResult> DeleteStorage(StorageViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _storageBussiness.DeleteStorageAsync(viewModel.Id);

                if (result)
                    return Json(new JsonResponse("OK", "Deleted!"));
                else
                    return Json(new JsonResponse("ERROR", "Fail!"));

            }
            else
            {
                return Json(ModelState);
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> DeleteAssetType(Storage.Models.AssetTypeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _storageBussiness.DeleteAssetTypeAsync(viewModel.Id);

                if (result)
                    return Json(new JsonResponse("OK", "Deleted!"));
                else
                    return Json(new JsonResponse("ERROR", "Fail!"));

            }
            else
            {
                return Json(ModelState);
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAssetLocator(AssetLocatorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _storageBussiness.DeleteAssetLocatorAsync(viewModel.Id);

                if (result)
                    return Json(new JsonResponse("OK", "Deleted!"));
                else
                    return Json(new JsonResponse("ERROR", "Fail!"));

            }
            else
            {
                return Json(ModelState);
            }
        }        
        #endregion

        #region GetAll for View
        [HttpGet]
        public IActionResult GetAllStorage([DataSourceRequest]DataSourceRequest request)
        {
            var data = _storageBussiness.GetAllStorage().Result;
            return Json(data.ToDataSourceResult(request));
        }        
        [HttpGet]
        public IActionResult GetAllStorageLocationAccessType([DataSourceRequest]DataSourceRequest request)
        {
            var data = _storageBussiness.GetAllStorageLocationAccessType().Result;
            return Json(data.ToDataSourceResult(request));
        }
        [HttpGet]
        public IActionResult GetAllAssetType([DataSourceRequest]DataSourceRequest request)
        {
            var data = _storageBussiness.GetAllAssetType().Result;
            return Json(data.ToDataSourceResult(request));
        }
        
        [HttpGet]
        public IActionResult GetAllAssetLocator([DataSourceRequest]DataSourceRequest request)
        {
            var data = _storageBussiness.GetAllAssetLocator().Result;
            return Json(data.ToDataSourceResult(request));
        }
        #endregion
    }
}