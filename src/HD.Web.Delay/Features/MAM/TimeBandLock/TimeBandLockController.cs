using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HD.TVAD.Web.Services;
using HD.TVAD.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using HD.TVAD.ApplicationCore.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using HD.TVAD.Web.Features.Manager;

namespace HD.TVAD.Web.Features.MAM
{
    [Area("MAM")]
    [Authorize]
    public class TimeBandLockController : TVADController
    {
        private IContentTimeBandLockService _contentTimeBandLockService;
        private ITimeBandService _TimeBandService;        
        public TimeBandLockController(IContentTimeBandLockService contentTimeBandLockService, ITimeBandService TimeBandService)
        {

            _contentTimeBandLockService = contentTimeBandLockService;
            _TimeBandService = TimeBandService;            
        }
        [HttpGet]
        public IActionResult Index(Guid contentId)
        {
            var model = new TimeBandLockViewModel
            {
                ContentId = contentId
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([DataSourceRequest]DataSourceRequest request, Guid contentId)
        {
            var data = await _contentTimeBandLockService.GetAll().Where(a => a.ContentId == contentId).ToListAsync();
            var vM = new List<TimeBandLockViewModel>();
            data.Each(a =>
            {
                vM.Add(new TimeBandLockViewModel
                {
                    Id=a.Id,
                    ContentId = contentId,
                    TimeBandId = a.TimeBandId,
                    TimeBandName = _TimeBandService.Get(a.TimeBandId).FirstOrDefault().TimeBandBase.Name,
                    StartDate = a.StartDate,
                    EndDate = a.EndDate
                });
            });

            return Json(await vM.ToDataSourceResultAsync(request));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(TimeBandLockViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dataModel = new ContentTimeBandLock
                {
                    ContentId = (Guid)viewModel.ContentId,
                    TimeBandId = (Guid)viewModel.TimeBandId,
                    StartDate = viewModel.StartDate,
                    EndDate = viewModel.EndDate                    
                };
                try
                {
                    var result = await _contentTimeBandLockService.Create(dataModel);
                    return JsonResponse(result, ActionType.Create);
                }
                catch (Exception ex)
                {

                    return Json(new JsonResponse("ERROR", ex.Message));
                }
            }
            else
            {
                return Json(ModelState);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(TimeBandLockViewModel viewModel)
        {
            try
            {
                var producer = await _contentTimeBandLockService.Get((Guid)viewModel.Id).FirstOrDefaultAsync();
                var result = await _contentTimeBandLockService.Delete(producer);

                return JsonResponse(result, ActionType.Delete);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(TimeBandLockViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var producer = await _contentTimeBandLockService.Get((Guid)viewModel.Id).FirstOrDefaultAsync();
                    producer.TimeBandId = (Guid)viewModel.TimeBandId;
                    producer.ContentId = (Guid)viewModel.ContentId;
                    producer.StartDate = viewModel.StartDate;
                    producer.EndDate = viewModel.EndDate;

                    var result = await _contentTimeBandLockService.Update(producer);

                    return JsonResponse(result, ActionType.Edit);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return Json(ModelState);
            }
        }
        [HttpGet]
        public async Task<List<TimeBandViewModel>> GetAllTimeBand()
        {
            var data = await _TimeBandService.GetAll().ToListAsync();
            var vM = new List<TimeBandViewModel>();
            data.Each(a => vM.Add(new TimeBandViewModel
            {
                Id = a.Id,
                Name = a.TimeBandBase.Name
            }));
            return vM;
        }
    }
}