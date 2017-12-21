using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class Content
    {
        public Content()
        {
            AnnexContractAssets = new HashSet<AnnexContractAsset>();
            ContentChannelLocks = new HashSet<ContentChannelLock>();
            AssetDocuments = new HashSet<AssetDocument>();
            ContentTimeBandLocks = new HashSet<ContentTimeBandLock>();
            DiscountAnnexContractAssets = new HashSet<DiscountAnnexContractAsset>();
            Versions = new HashSet<Version>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string ProductName { get; set; }
        public string ProductModel { get; set; }
        public int BlockDuration { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid TypeId { get; set; }
        public Guid? RegisterId { get; set; }
        public Guid? ProducerId { get; set; }        
        public Guid? ProductGroupId { get; set; }
        public bool? Approve { get; set; }
        public DateTime? ApproveEndDate { get; set; }
        public Guid? LastProductModel { get; set; }
        public string Text { get; set; }

        public virtual ICollection<AnnexContractAsset> AnnexContractAssets { get; set; }
        public virtual ICollection<ContentChannelLock> ContentChannelLocks { get; set; }
        public virtual ICollection<AssetDocument> AssetDocuments { get; set; }
        public virtual ICollection<ContentTimeBandLock> ContentTimeBandLocks { get; set; }
        public virtual ICollection<DiscountAnnexContractAsset> DiscountAnnexContractAssets { get; set; }
		public virtual ICollection<SpotAssetByAsset> SpotAssetByAssets { get; set; }

		public virtual ICollection<Version> Versions { get; set; }
    //    public virtual Areas Area { get; set; }
        public virtual Content LastProductModelNavigation { get; set; }
        public virtual ICollection<Content> InverseLastProductModelNavigation { get; set; }
		public virtual Producer Producer { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
        public virtual Register Register { get; set; }
        public virtual ContentType Type { get; set; }
		public bool HasBooking {
			get {
				return AnnexContractAssets.Count > 0 || SpotAssetByAssets.Count > 0;
			}
		}

		public bool IsApproved
		{
			get
			{
				return Approve.HasValue ? Approve.Value : false ;
			}
		}
	}
}
