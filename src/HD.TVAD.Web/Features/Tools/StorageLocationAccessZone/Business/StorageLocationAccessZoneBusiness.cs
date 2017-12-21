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
    public class StorageLocationAccessZoneBusiness
    {           
        private IStorageLocationAccessZoneService _storageLocationAccessZoneService;        
        private readonly IHostingEnvironment _hostingEnvironment;
        public StorageLocationAccessZoneBusiness(IStorageLocationAccessZoneService locationAccessZoneService,
            IHostingEnvironment hostingEnvironment)
        {                  
            _storageLocationAccessZoneService = locationAccessZoneService;
            _hostingEnvironment = hostingEnvironment;            
        }
        
        #region StorageLocationAccessZone
        public async Task<List<StorageLocationAccessZoneViewModel>> GetAll()
        {
            var data = await _storageLocationAccessZoneService.GetAll().ToListAsync();
            var vM = new List<StorageLocationAccessZoneViewModel>();
            foreach (var temp in data)
            {
                vM.Add(new StorageLocationAccessZoneViewModel
                {
                    Id = temp.Id,
                    StorageLocationAccessId = temp.StorageLocationAccessId,
                    StorageLocationAccessName = temp.StorageLocationAccessId == null ? "" : temp.StorageLocationAccess.Name,
                    AccessZoneId = temp.AccessZoneId,
                    AccessZoneName = temp.AccessZoneId == null ? "" : temp.AccessZone.Name
                });
            }
            return vM;
        }
        public async Task<StorageLocationAccessZoneViewModel> Get(Guid id)
        {
            var data = await _storageLocationAccessZoneService.Get(id).FirstOrDefaultAsync();
            var vM = new StorageLocationAccessZoneViewModel()
            {
                Id = data.Id,
                StorageLocationAccessId = data.StorageLocationAccessId,
                StorageLocationAccessName = data.StorageLocationAccessId == null ? "" : data.StorageLocationAccess.Name,
                AccessZoneId = data.AccessZoneId,
                AccessZoneName = data.AccessZoneId == null ? "" : data.AccessZone.Name
            };

            return vM;
        }
        public async Task<bool> CreateAsync(StorageLocationAccessZoneViewModel viewModel)
        {
            var dataModel = new StorageLocationAccessZone()
            {
                StorageLocationAccessId = viewModel.StorageLocationAccessId,
                AccessZoneId = viewModel.AccessZoneId
            };

            try
            {
                var result = await _storageLocationAccessZoneService.Create(dataModel);

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

        public async Task<bool> EditAsync(StorageLocationAccessZoneViewModel viewModel)
        {
            var dataModel = await _storageLocationAccessZoneService.Get(viewModel.Id).FirstOrDefaultAsync();

            dataModel.StorageLocationAccessId = viewModel.StorageLocationAccessId;
            dataModel.AccessZoneId = viewModel.AccessZoneId;
            try
            {
                var result = await _storageLocationAccessZoneService.Update(dataModel);

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
                var dataModel = await _storageLocationAccessZoneService.Get(id).FirstOrDefaultAsync();

                var result = await _storageLocationAccessZoneService.Delete(dataModel);

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

