using HD.TVAD.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HD.TVAD.Web.Services
{
    public interface IAnnexContractAssetService : IService<AnnexContractAsset>
	{
		Task<bool> HasApprovedSpotAsync(Guid annexContractAssetId);
		Task<bool> ExistAsync(Guid annexContractId, Guid assetId);
	}
}
