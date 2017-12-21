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
    public class StorageLocationAccessBusiness
    {               
        private IStorageLocationAccessService _storageLocationAccessService;        
        private readonly IHostingEnvironment _hostingEnvironment;
        
        public StorageLocationAccessBusiness(IStorageLocationAccessService storageLocationAccessService, IHostingEnvironment hostingEnvironment)
        {                     
            _storageLocationAccessService = storageLocationAccessService;            
            _hostingEnvironment = hostingEnvironment;            
        }       

        #region StorageLocationAccess
        public async Task<List<StorageLocationAccessViewModel>> GetAll()
        {
            var data = await _storageLocationAccessService.GetAll().ToListAsync();
            var vM = new List<StorageLocationAccessViewModel>();
            foreach (var temp in data)
            {
                vM.Add(new StorageLocationAccessViewModel
                {
                    Id = temp.Id,
                    Name = temp.Name,
                    Description = temp.Description,
                    Path = temp.Path,
                    Identity = temp.Identity,
                    Port = temp.Port,
                    Host = temp.Host,
                    Readable = temp.Readable,
                    Password = temp.Password,
                    Writeable = temp.Writeable,
                    StorageLocationId = temp.StorageLocationId,
                    StorageLocationName = temp.StorageLocationId == null ? "" : temp.StorageLocation.Name,
                    StorageLocationAccessTypeId = temp.StorageLocationAccessTypeId,
                    StorageLocationAccessTypeName = temp.StorageLocationAccessTypeId == null ? "" : temp.StorageLocationAccessType.Name                    
                });
            }
            return vM;
        }
        public async Task<StorageLocationAccessViewModel> Get(Guid id)
        {
            var data = await _storageLocationAccessService.Get(id).FirstOrDefaultAsync();
            var vM = new StorageLocationAccessViewModel()
            {
                Id = data.Id,
                Name = data.Name,
                Description = data.Description,
                Path = data.Path,
                Identity = data.Identity,
                Port = data.Port,
                Host = data.Host,
                Readable = data.Readable,
                Password = data.Password,
                Writeable = data.Writeable,
                StorageLocationId = data.StorageLocationId,
                StorageLocationName = data.StorageLocationId == null ? "" : data.StorageLocation.Name,
                StorageLocationAccessTypeId = data.StorageLocationAccessTypeId,
                StorageLocationAccessTypeName = data.StorageLocationAccessTypeId == null ? "" : data.StorageLocationAccessType.Name
            };

            return vM;
        }
        public async Task<bool> CreateAsync(StorageLocationAccessViewModel viewModel)
        {
            var dataModel = new StorageLocationAccess()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Path = viewModel.Path,
                StorageLocationId = viewModel.StorageLocationId,
                StorageLocationAccessTypeId = viewModel.StorageLocationAccessTypeId,
                Readable = viewModel.Readable,
                Writeable = viewModel.Writeable,
                Password = viewModel.Password,
                Host = viewModel.Host,
                Port = viewModel.Port,
                Identity = viewModel.Identity
            };

            try
            {
                var result = await _storageLocationAccessService.Create(dataModel);

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

        public async Task<bool> EditAsync(StorageLocationAccessViewModel viewModel)
        {
            var dataModel = await _storageLocationAccessService.Get(viewModel.Id).FirstOrDefaultAsync();

            dataModel.Name = viewModel.Name;
            dataModel.Description = viewModel.Description;
            dataModel.Path = viewModel.Path;
            dataModel.StorageLocationId = viewModel.StorageLocationId;
            dataModel.Readable = viewModel.Readable;
            dataModel.Writeable = viewModel.Writeable;
            dataModel.Password = viewModel.Password;
            dataModel.Host = viewModel.Host;
            dataModel.Port = viewModel.Port;
            dataModel.Identity = viewModel.Identity;
            try
            {
                var result = await _storageLocationAccessService.Update(dataModel);

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
                var dataModel = await _storageLocationAccessService.Get(id).FirstOrDefaultAsync();

                var result = await _storageLocationAccessService.Delete(dataModel);

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

