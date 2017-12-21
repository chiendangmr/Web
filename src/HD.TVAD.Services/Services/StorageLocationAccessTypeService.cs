using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HD.Station;
using HD.TVAD.ApplicationCore.Entities.MediaAsset;

namespace HD.TVAD.Web.Services
{
	[Service(ServiceType = typeof(IStorageLocationAccessTypeService))]
	public class StorageLocationAccessTypeService : Service<StorageLocationAccessType, IStorageLocationAccessTypeRepository>, IStorageLocationAccessTypeService
    {
		public StorageLocationAccessTypeService(IStorageLocationAccessTypeRepository repository) : base(repository)
		{
		}        
    }    
}
