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
	[Service(ServiceType = typeof(IMediaAssetService))]
	public class MediaAssetService : Service<MediaAsset, IMediaAssetRepository>, IMediaAssetService
    {
		public MediaAssetService(IMediaAssetRepository repository) : base(repository)
		{
		}
	}    
}
