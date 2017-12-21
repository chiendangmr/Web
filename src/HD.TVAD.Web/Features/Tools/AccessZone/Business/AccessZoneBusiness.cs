using HD.TVAD.ApplicationCore.Entities.MediaAsset;
using HD.TVAD.Web.Storage.Models;
using HD.TVAD.Web.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Features.Manage.MAM.Services
{
    public class AccessZoneBusiness
    {        
        private readonly IHostingEnvironment _hostingEnvironment;        
        private IAcessZoneService _acessZoneService;        
        public AccessZoneBusiness(IHostingEnvironment hostingEnvironment, IAcessZoneService originService)
        {           
            _hostingEnvironment = hostingEnvironment;           
            _acessZoneService = originService;            
        }       

        #region AccessZone
        public async Task<List<AcessZoneViewModel>> GetAll()
        {
            var data = await _acessZoneService.GetAll().ToListAsync();
            var vM = new List<AcessZoneViewModel>();
            foreach (var temp in data)
            {
                vM.Add(new AcessZoneViewModel
                {
                    Id = temp.Id,
                    Name = temp.Name,
                    Description = temp.Description
                });
            }
            return vM;
        }
        public async Task<AcessZoneViewModel> Get(Guid id)
        {
            var data = await _acessZoneService.Get(id).FirstOrDefaultAsync();
            var vM = new AcessZoneViewModel
            {
                Id = data.Id,
                Name = data.Name,
                Description = data.Description
            };

            return vM;
        }
        public async Task<bool> CreateAsync(AcessZoneViewModel viewModel)
        {
            var dataModel = new AccessZone()
            {
                Name = viewModel.Name,
                Description = viewModel.Description
            };

            try
            {
                var result = await _acessZoneService.Create(dataModel);

                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> EditAsync(AcessZoneViewModel viewModel)
        {
            var dataModel = await _acessZoneService.Get(viewModel.Id).FirstOrDefaultAsync();

            dataModel.Name = viewModel.Name;
            dataModel.Description = viewModel.Description;
            try
            {
                var result = await _acessZoneService.Update(dataModel);

                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var dataModel = await _acessZoneService.Get(id).FirstOrDefaultAsync();

                var result = await _acessZoneService.Delete(dataModel);

                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion        
    }
}

