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
    public class StorageLocationBusiness
    {        
        private IStorageLocationService _storageLocationService;        
        private readonly IHostingEnvironment _hostingEnvironment;        
        public StorageLocationBusiness(IStorageLocationService locationService, 
            IHostingEnvironment hostingEnvironment)
        {
           
            _storageLocationService = locationService;           
            _hostingEnvironment = hostingEnvironment;            
        }     

        #region StorageLocation
        public async Task<List<StorageLocationViewModel>> GetAll()
        {
            var data = await _storageLocationService.GetAll().ToListAsync();
            var vM = new List<StorageLocationViewModel>();
            foreach (var temp in data)
            {
                vM.Add(new StorageLocationViewModel
                {
                    Id = temp.Id,
                    Name = temp.Name,
                    Description = temp.Description,
                    Path = temp.Path,
                    UncPath = temp.UncPath,
                    StorageType = (int)temp.StorageType,
                    StorageTypeDescription = temp.StorageTypeDescription,
                    StorageId = temp.StorageId,
                    StorageName = temp.StorageId == null ? "" : temp.Storage.Name,
                    AssetTypeId = temp.AssetTypeId,
                    AssetTypeName = temp.AssetTypeId == null ? "" : temp.AssetType.Name
                });
            }
            return vM;
        }
        public async Task<StorageLocationViewModel> Get(Guid id)
        {
            var data = await _storageLocationService.Get(id).FirstOrDefaultAsync();
            var vM = new StorageLocationViewModel()
            {
                Id = data.Id,
                Name = data.Name,
                Description = data.Description,
                Path = data.Path,
                UncPath = data.UncPath,
                StorageType = (int)data.StorageType,
                StorageTypeDescription = data.StorageTypeDescription,
                StorageId = data.StorageId,
                StorageName = data.StorageId == null ? "" : data.Storage.Name,
                AssetTypeId = data.AssetTypeId,
                AssetTypeName = data.AssetTypeId == null ? "" : data.AssetType.Name
            };

            return vM;
        }
        public async Task<bool> CreateAsync(StorageLocationViewModel viewModel)
        {
            var dataModel = new StorageLocation()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Path = viewModel.Path,
                UncPath = viewModel.UncPath,
                StorageId = viewModel.StorageId,
                StorageType = viewModel.StorageType,
                StorageTypeDescription = viewModel.StorageTypeDescription,
                AssetTypeId = viewModel.AssetTypeId
            };

            try
            {
                var result = await _storageLocationService.Create(dataModel);

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

        public async Task<bool> EditAsync(StorageLocationViewModel viewModel)
        {
            var dataModel = await _storageLocationService.Get(viewModel.Id).FirstOrDefaultAsync();

            dataModel.Name = viewModel.Name;
            dataModel.Description = viewModel.Description;
            dataModel.Path = viewModel.Path;
            dataModel.UncPath = viewModel.UncPath;
            dataModel.StorageId = viewModel.StorageId;
            dataModel.StorageType = viewModel.StorageType;
            dataModel.StorageTypeDescription = viewModel.StorageTypeDescription;
            dataModel.AssetTypeId = viewModel.AssetTypeId;
            try
            {
                var result = await _storageLocationService.Update(dataModel);

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
                var dataModel = await _storageLocationService.Get(id).FirstOrDefaultAsync();

                var result = await _storageLocationService.Delete(dataModel);

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

