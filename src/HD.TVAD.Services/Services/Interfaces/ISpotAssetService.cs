using HD.TVAD.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Services
{
	public interface ISpotAssetService : IService<SpotAsset>
	{

		IQueryable<SpotAssetByAsset> GetAllSpotAssetByAsset();
		bool ExistSpotAssetByAsset(Guid assetId);
	}
}
