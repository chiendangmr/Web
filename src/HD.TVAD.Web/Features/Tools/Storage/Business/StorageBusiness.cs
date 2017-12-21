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
    public class StorageBusiness
    {
        private IStorageService _storageService;        
        private IStorageLocationAccessTypeService _storageLocationAccessTypeService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private IAssetTypeService _assetTypeService;        
        private IAssetLocatorService _assetLocatorService;
        public StorageBusiness(IStorageService storageService, 
            IHostingEnvironment hostingEnvironment, IAssetTypeService assetTypeService, IAssetLocatorService assetLocatorService, IStorageLocationAccessTypeService storageLocationAccessTypeService)
        {
            _storageService = storageService;           
            _hostingEnvironment = hostingEnvironment;
            _assetTypeService = assetTypeService;            
            _assetLocatorService = assetLocatorService;
            _storageLocationAccessTypeService = storageLocationAccessTypeService;
        }
        #region AssetType        
        public async Task<List<AssetTypeViewModel>> GetAllAssetType()
        {
            var data = await _assetTypeService.GetAll().ToListAsync();
            var vM = new List<AssetTypeViewModel>();
            foreach (var temp in data)
            {
                vM.Add(new AssetTypeViewModel
                {
                    Id = temp.Id,
                    Name = temp.Name,
                    Description = temp.Description,
                    DefaultPath = temp.DefaultPath,
                    Revision = temp.Revision,
                    Editable = temp.Editable
                });
            }
            return vM;
        }
        public async Task<AssetTypeViewModel> GetAssetType(Guid id)
        {
            var data = await _assetTypeService.Get(id).FirstOrDefaultAsync();
            var vM = new AssetTypeViewModel()
            {
                Id = data.Id,
                Name = data.Name,
                Description = data.Description,
                DefaultPath = data.DefaultPath,
                Revision = data.Revision,
                Editable = data.Editable
            };

            return vM;
        }
        public async Task<bool> CreateAssetTypeAsync(AssetTypeViewModel viewModel)
        {
            var dataModel = new AssetType()
            {
                Name = viewModel.Name,
                DefaultPath = viewModel.DefaultPath,
                Description = viewModel.Description,
                Revision = viewModel.Revision,
                Editable = viewModel.Editable
            };

            try
            {
                var result = await _assetTypeService.Create(dataModel);

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

        public async Task<bool> EditAssetTypeAsync(AssetTypeViewModel viewModel)
        {
            var dataModel = await _assetTypeService.Get(viewModel.Id).FirstOrDefaultAsync();

            dataModel.Name = viewModel.Name;
            dataModel.DefaultPath = viewModel.DefaultPath;
            dataModel.Description = viewModel.Description;
            dataModel.Revision = viewModel.Revision;
            dataModel.Editable = viewModel.Editable;
            try
            {
                var result = await _assetTypeService.Update(dataModel);

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
        public async Task<bool> DeleteAssetTypeAsync(Guid id)
        {
            try
            {
                var dataModel = await _assetTypeService.Get(id).FirstOrDefaultAsync();

                var result = await _assetTypeService.Delete(dataModel);

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

        #region Storage
        public async Task<List<StorageViewModel>> GetAllStorage()
        {
            var data = await _storageService.GetAll().ToListAsync();
            var vM = new List<StorageViewModel>();
            foreach (var temp in data)
            {
                vM.Add(new StorageViewModel
                {
                    Id = temp.Id,
                    Name = temp.Name,
                    Description = temp.Description
                });
            }
            return vM;
        }
        public async Task<StorageViewModel> GetStorage(Guid id)
        {
            var data = await _storageService.Get(id).FirstOrDefaultAsync();
            var vM = new StorageViewModel()
            {
                Id = data.Id,
                Name = data.Name,
                Description = data.Description
            };
            return vM;
        }
        public async Task<bool> CreateStorageAsync(StorageViewModel viewModel)
        {
            var dataModel = new ApplicationCore.Entities.MediaAsset.Storage()
            {
                Name = viewModel.Name,
                Description = viewModel.Description
            };

            try
            {
                var result = await _storageService.Create(dataModel);

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

        public async Task<bool> EditStorageAsync(StorageViewModel viewModel)
        {
            var dataModel = await _storageService.Get(viewModel.Id).FirstOrDefaultAsync();

            dataModel.Name = viewModel.Name;
            dataModel.Description = viewModel.Description;
            try
            {
                var result = await _storageService.Update(dataModel);

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
        public async Task<bool> DeleteStorageAsync(Guid id)
        {
            try
            {
                var dataModel = await _storageService.Get(id).FirstOrDefaultAsync();

                var result = await _storageService.Delete(dataModel);

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

        #region StorageLocationAccessType
        public async Task<List<StorageLocationAccessTypeViewModel>> GetAllStorageLocationAccessType()
        {
            var data = await _storageLocationAccessTypeService.GetAll().ToListAsync();
            var vM = new List<StorageLocationAccessTypeViewModel>();
            foreach (var temp in data)
            {
                vM.Add(new StorageLocationAccessTypeViewModel
                {
                    Id = temp.Id,
                    Name = temp.Name,
                    Description = temp.Description
                });
            }
            return vM;
        }
        public async Task<StorageLocationAccessTypeViewModel> GetStorageLocationAccessType(Guid id)
        {
            var data = await _storageLocationAccessTypeService.Get(id).FirstOrDefaultAsync();
            var vM = new StorageLocationAccessTypeViewModel()
            {
                Id = data.Id,
                Name = data.Name,
                Description = data.Description
            };

            return vM;
        }
        public async Task<bool> CreateStorageLocationAccessTypeAsync(StorageLocationAccessTypeViewModel viewModel)
        {
            var dataModel = new StorageLocationAccessType()
            {
                Name = viewModel.Name,
                Description = viewModel.Description
            };

            try
            {
                var result = await _storageLocationAccessTypeService.Create(dataModel);

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

        public async Task<bool> EditStorageLocationAccessTypeAsync(StorageLocationAccessTypeViewModel viewModel)
        {
            var dataModel = await _storageLocationAccessTypeService.Get(viewModel.Id).FirstOrDefaultAsync();

            dataModel.Name = viewModel.Name;
            dataModel.Description = viewModel.Description;
            try
            {
                var result = await _storageLocationAccessTypeService.Update(dataModel);

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
        public async Task<bool> DeleteStorageLocationAccessTypeAsync(Guid id)
        {
            try
            {
                var dataModel = await _storageLocationAccessTypeService.Get(id).FirstOrDefaultAsync();

                var result = await _storageLocationAccessTypeService.Delete(dataModel);

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

        #region AssetLocator
        public async Task<List<AssetLocatorViewModel>> GetAllAssetLocator()
        {
            var data = await _assetLocatorService.GetAll().ToListAsync();
            var vM = new List<AssetLocatorViewModel>();
            foreach (var temp in data)
            {
                vM.Add(new AssetLocatorViewModel
                {
                    Id = temp.Id,
                    ContainerMineType = temp.ContainerMimeType,
                    UploadedDate = temp.UploadedDate,
                    Path = temp.Path,
                    Revision = temp.Revision,
                    AssetId = temp.AssetId,
                    AssetName = temp.AssetId == null ? "" : temp.Asset.Name,
                    StorageLocationId = temp.StorageLocationId,
                    StorageLocationName = temp.StorageLocationId == null ? "" : temp.StorageLocation.Name
                });
            }
            return vM;
        }
        public async Task<AssetLocatorViewModel> GetAssetLocator(Guid id)
        {
            var data = await _assetLocatorService.Get(id).FirstOrDefaultAsync();
            var vM = new AssetLocatorViewModel
            {
                Id = data.Id,
                ContainerMineType = data.ContainerMimeType,
                UploadedDate = data.UploadedDate,
                Path = data.Path,
                Revision = data.Revision,
                AssetId = data.AssetId,
                AssetName = data.AssetId == null ? "" : data.Asset.Name,
                StorageLocationId = data.StorageLocationId,
                StorageLocationName = data.StorageLocationId == null ? "" : data.StorageLocation.Name
            };

            return vM;
        }
        public async Task<bool> CreateAssetLocatorAsync(AssetLocatorViewModel viewModel)
        {
            var dataModel = new AssetLocator()
            {
                AssetId = viewModel.AssetId,
                ContainerMimeType = viewModel.ContainerMineType,
                StorageLocationId = viewModel.StorageLocationId,
                UploadedDate = viewModel.UploadedDate,
                Path = viewModel.Path,
                Revision = viewModel.Revision
            };

            try
            {
                var result = await _assetLocatorService.Create(dataModel);

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

        public async Task<bool> EditAssetLocatorAsync(AssetLocatorViewModel viewModel)
        {
            var dataModel = await _assetLocatorService.Get(viewModel.Id).FirstOrDefaultAsync();

            dataModel.AssetId = viewModel.AssetId;
            dataModel.ContainerMimeType = viewModel.ContainerMineType;
            dataModel.StorageLocationId = viewModel.StorageLocationId;
            dataModel.UploadedDate = viewModel.UploadedDate;
            dataModel.Path = viewModel.Path;
            dataModel.Revision = viewModel.Revision;
            try
            {
                var result = await _assetLocatorService.Update(dataModel);

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
        public async Task<bool> DeleteAssetLocatorAsync(Guid id)
        {
            try
            {
                var dataModel = await _assetLocatorService.Get(id).FirstOrDefaultAsync();

                var result = await _assetLocatorService.Delete(dataModel);

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

