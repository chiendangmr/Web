using System;
using System.Collections.Generic;
using System.Text;
using HD.TVAD.ApplicationCore.Entities.MediaAsset;
using HD.TVAD.ApplicationCore.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HD.Station;


namespace HD.TVAD.Web.Services
{
	[Service(ServiceType = typeof(IAssetService))]
	public class AssetService : Service<Asset, IAssetRepository>, IAssetService
	{
		public AssetService(IAssetRepository repository) : base(repository)
		{
		}
	}    
}
