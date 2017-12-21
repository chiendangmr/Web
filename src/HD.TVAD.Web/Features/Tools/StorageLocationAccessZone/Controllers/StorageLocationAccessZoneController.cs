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
    public class StorageLocationAccessZoneController : TVADController
    {
        private StorageLocationAccessZoneBusiness _storageBussiness;
        public StorageLocationAccessZoneController(IStorageLocationAccessZoneService locationAccessZoneService,
            IHostingEnvironment hostingEnvironment)
        {
            _storageBussiness = new StorageLocationAccessZoneBusiness(locationAccessZoneService, hostingEnvironment);
        }
        #region View
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }       
        
        #region Create
                
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }        
        #endregion

        #region Edit
        
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var vM = _storageBussiness.Get(id).Result;
            return View(vM);
        }       
        
        #endregion
        
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var vM = _storageBussiness.Get(id).Result;
            return View(vM);
        }       
        #endregion

        #region Create Action
        
        [HttpPost]
        public async Task<IActionResult> Create(StorageLocationAccessZoneViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _storageBussiness.CreateAsync(viewModel);

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
        public async Task<IActionResult> Edit(StorageLocationAccessZoneViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _storageBussiness.EditAsync(viewModel);

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
        public async Task<IActionResult> Delete(StorageLocationAccessZoneViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _storageBussiness.DeleteAsync(viewModel.Id);

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
        public IActionResult GetAll([DataSourceRequest]DataSourceRequest request)
        {
            var data = _storageBussiness.GetAll().Result;
            return Json(data.ToDataSourceResult(request));
        }        
        #endregion
    }
}