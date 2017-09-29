using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Asset
    {
        public Asset()
        {
            AssetLocator = new HashSet<AssetLocator>();
            Scene = new HashSet<Scene>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ContentId { get; set; }
        public Guid? AssetTypeId { get; set; }
        public Guid? MediaAssetId { get; set; }
        public string FileName { get; set; }
        public string OriginFileName { get; set; }
        public string MineType { get; set; }
        public long? PackageSize { get; set; }
        public DateTimeOffset? UploadedDate { get; set; }
        public byte[] Revision { get; set; }
        public Guid? ReferenceAssetId { get; set; }
        public int? ReferenceIndex { get; set; }

        public virtual ICollection<AssetLocator> AssetLocator { get; set; }
        public virtual ICollection<Scene> Scene { get; set; }
        public virtual AssetType AssetType { get; set; }
        public virtual MediaAsset MediaAsset { get; set; }
        public virtual MineType MineTypeNavigation { get; set; }
    }
}
