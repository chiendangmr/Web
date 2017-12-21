using HD.Station.MediaAssets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HD.Station.MediaAssets.Data;
using HD.Station.MediaAssets.Models;

namespace HD.TVAD.Web.Features.Booking
{

	public class MediaAssetServiceTest : IMediaAssetService
	{
		public Task<OperationResult> ActiveAsset(ContentActiveAsset contentActiveAsset)
		{
			throw new NotImplementedException();
		}

        public Task<OperationResult> ActiveAssetAsync(ContentActiveAsset contentActiveAsset)
        {
            throw new NotImplementedException();
        }

        public Task AddAssetAsync(AssetVM assetVM, List<Guid> lstStorageLocationId)
        {
            throw new NotImplementedException();
        }

        public Task AddMediaAssetAsync(MediaAsset mediaAsset, Guid assetId)
        {
            throw new NotImplementedException();
        }

        public Task<AssetWithLocationAccessVM> GetAssetWithLocationAsync(Guid assetId)
        {
            throw new NotImplementedException();
        }

        public Task<AssetType> GetDocsAssetTypeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MediaAssetVM> GetMediaAssetAsync(Guid assetId)
        {
            throw new NotImplementedException();
        }

        public Task<AssetType> GetPreviewAssetType()
		{
			throw new NotImplementedException();
		}

        public Task<AssetType> GetPreviewAssetTypeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<StorageLocationWithLocationAccessVM> GetStorageLocationAsync(Guid storageLocationId)
        {
            throw new NotImplementedException();
        }

        public Task<List<AssetVM>> LstAssetByTypeId(Guid externalId, Guid assetTypeId)
		{
			var assets = new List<AssetVM>();
			assets.Add(new AssetVM() {
				Id = Guid.NewGuid(),
			});
			return Task.FromResult(assets);
		}

        public Task<List<AssetVM>> LstAssetByTypeIdAsync(Guid externalId, Guid assetTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<AssetPartVM>> LstAssetPartByAssetId(Guid assetId)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> LstDocsUrlAsync(Guid assetId)
        {
            throw new NotImplementedException();
        }

        public Task<List<AssetType>> LstMainAssetTypeAsync()
		{
			throw new NotImplementedException();
		}

		public Task<List<string>> LstPreviewUrlAsync(Guid assetId)
		{
			var previewUrls = new List<string>();
			previewUrls.Add("Videos/TVC/placeHolder.mp4");
			previewUrls.Add("Videos/Evidence/testEvidence.mp4");
			return Task.FromResult(previewUrls);
		}

        public Task<List<StorageLocationVM>> LstStorageLocationAsync(Guid assetTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> LstUncPathAsync(Guid assetId)
        {
            throw new NotImplementedException();
        }
    }
}
