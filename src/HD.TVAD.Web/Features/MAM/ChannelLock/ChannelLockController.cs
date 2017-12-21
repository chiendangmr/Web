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
    public class ChannelLockController : TVADController
    {
        private IContentChannelLockService _contentChannelLockService;
        private IChannelService _channelService;
        private ITimeBandService _timeBandService;
        private IContentChannelLockTimeBandBaseNoLockService _contentChannelLockTimeBandBaseNoLockService;
        public ChannelLockController(IContentChannelLockService contentChannelLockService, IChannelService channelService, ITimeBandService timeBandService, IContentChannelLockTimeBandBaseNoLockService contentChannelLockTimeBandBaseNoLockService)
        {

            _contentChannelLockService = contentChannelLockService;
            _channelService = channelService;
            _timeBandService = timeBandService;
            _contentChannelLockTimeBandBaseNoLockService = contentChannelLockTimeBandBaseNoLockService;
        }
        [HttpGet]
        public IActionResult Index(Guid contentId)
        {
            var model = new ChannelLockViewModel
            {
                ContentId = contentId
            };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([DataSourceRequest]DataSourceRequest request, Guid contentId)
        {
            var data = await _contentChannelLockService.GetAll().Where(a => a.ContentId == contentId).ToListAsync();
            var vM = new List<ChannelLockViewModel>();
            data.Each(a =>
            {
                vM.Add(new ChannelLockViewModel
                {
                    Id = a.Id,
                    ContentId = contentId,
                    ChannelId = a.ChannelId,
                    ChannelName = _channelService.Get(a.ChannelId).FirstOrDefault().TimeBandBase.Name,
                    StartDate = a.StartDate,
                    EndDate = a.EndDate,
                    LstTimeBandBaseNoLockId = a.ContentChannelLockTimeBandBaseNoLocks == null ? null : a.ContentChannelLockTimeBandBaseNoLocks.Select(b => b.TimeBandBaseId).ToList(),
                    LstTimeBandBaseNoLockName = a.ContentChannelLockTimeBandBaseNoLocks == null ? null : a.ContentChannelLockTimeBandBaseNoLocks.Select(c =>
                        _timeBandService.Get(c.TimeBandBaseId).FirstOrDefault().TimeBandBase.Name).ToList()
                });
            });

            return Json(await vM.ToDataSourceResultAsync(request));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ChannelLockViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var lstTimebandNoLock = new List<ContentChannelLockTimeBandBaseNoLock>();
                if (viewModel.LstTimeBandBaseNoLockId != null)
                    foreach (var temp in viewModel.LstTimeBandBaseNoLockId)
                    {
                        lstTimebandNoLock.Add(new ContentChannelLockTimeBandBaseNoLock
                        {
                            TimeBandBaseId = temp
                        });
                    }
                var dataModel = new ContentChannelLock
                {
                    ContentId = (Guid)viewModel.ContentId,
                    ChannelId = (Guid)viewModel.ChannelId,
                    StartDate = viewModel.StartDate,
                    EndDate = viewModel.EndDate,
                    ContentChannelLockTimeBandBaseNoLocks = lstTimebandNoLock
                };
                try
                {
                    var result = await _contentChannelLockService.Create(dataModel);
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
        public async Task<IActionResult> DeleteAsync(ChannelLockViewModel viewModel)
        {
            try
            {
                var producer = await _contentChannelLockService.Get((Guid)viewModel.Id).FirstOrDefaultAsync();
                var result = await _contentChannelLockService.Delete(producer);

                return JsonResponse(result, ActionType.Delete);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(ChannelLockViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var producer = await _contentChannelLockService.Get((Guid)viewModel.Id).FirstOrDefaultAsync();
                    producer.ChannelId = (Guid)viewModel.ChannelId;
                    producer.ContentId = (Guid)viewModel.ContentId;
                    producer.StartDate = viewModel.StartDate;
                    producer.EndDate = viewModel.EndDate;
                    
                    var lstTimebandNoLock = new List<ContentChannelLockTimeBandBaseNoLock>();
                    if (viewModel.LstTimeBandBaseNoLockId != null)
                    {
                        if (producer.ContentChannelLockTimeBandBaseNoLocks != null)
                        {
                            foreach (var temp in producer.ContentChannelLockTimeBandBaseNoLocks.ToList())
                            {
                                await _contentChannelLockTimeBandBaseNoLockService.Delete(temp);
                            }
                        }
                        foreach (var temp in viewModel.LstTimeBandBaseNoLockId)
                        {
                            var item = new ContentChannelLockTimeBandBaseNoLock
                            {
                                LockId = producer.Id,
                                TimeBandBaseId = temp
                            };
                            await _contentChannelLockTimeBandBaseNoLockService.Create(item);
                        }
                    }                       
                    
                    var result = await _contentChannelLockService.Update(producer);

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
        public async Task<List<ChannelViewModel>> GetAllChannel()
        {
            var data = await _channelService.GetAll().ToListAsync();
            var vM = new List<ChannelViewModel>();
            data.Each(a => vM.Add(new ChannelViewModel
            {
                Id = a.Id,
                Name = a.TimeBandBase.Name
            }));
            return vM;
        }
        [HttpGet]
        public async Task<List<TimeBandViewModel>> GetAllTimeBand()
        {
            var data = await _timeBandService.GetAll().ToListAsync();
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