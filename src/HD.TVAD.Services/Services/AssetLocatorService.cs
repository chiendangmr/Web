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
	[Service(ServiceType = typeof(IAssetLocatorService))]
	public class AssetLocatorService : Service<AssetLocator, IAssetLocatorRepository>, IAssetLocatorService
    {
		public AssetLocatorService(IAssetLocatorRepository repository) : base(repository)
		{
		}        
    }    
}
