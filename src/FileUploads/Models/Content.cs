using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Content
    {
        public Content()
        {
            AnnexContractAssets = new HashSet<AnnexContractAssets>();
            AssetChannelLocks = new HashSet<AssetChannelLocks>();
            AssetDocuments = new HashSet<AssetDocuments>();
            AssetTimeBandLocks = new HashSet<AssetTimeBandLocks>();
            DiscountAnnexContractAssets = new HashSet<DiscountAnnexContractAssets>();
            SpotAssetByAssets = new HashSet<SpotAssetByAssets>();
            Versions = new HashSet<Versions>();
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
        public Guid AreaId { get; set; }
        public Guid? ProductGroupId { get; set; }
        public int? Approve { get; set; }
        public DateTime? ApproveEndDate { get; set; }
        public Guid? LastProductModel { get; set; }

        public virtual ICollection<AnnexContractAssets> AnnexContractAssets { get; set; }
        public virtual ICollection<AssetChannelLocks> AssetChannelLocks { get; set; }
        public virtual ICollection<AssetDocuments> AssetDocuments { get; set; }
        public virtual ICollection<AssetTimeBandLocks> AssetTimeBandLocks { get; set; }
        public virtual ICollection<DiscountAnnexContractAssets> DiscountAnnexContractAssets { get; set; }
        public virtual ICollection<SpotAssetByAssets> SpotAssetByAssets { get; set; }
        public virtual ICollection<Versions> Versions { get; set; }
        public virtual Areas Area { get; set; }
        public virtual Content LastProductModelNavigation { get; set; }
        public virtual ICollection<Content> InverseLastProductModelNavigation { get; set; }
        public virtual Producers Producer { get; set; }
        public virtual ProductGroups ProductGroup { get; set; }
        public virtual Registers Register { get; set; }
        public virtual AssetTypes Type { get; set; }
    }
}
