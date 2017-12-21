using HD.TVAD.ApplicationCore.Entities;
using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities.MediaAsset
{
    public partial class Asset
    {
        public Asset()
        {
            Scenes = new HashSet<Scene>();
            AssetLocators = new HashSet<AssetLocator>();
            Evidences = new HashSet<Evidence>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ContentId { get; set; }
        public Guid? AssetTypeId { get; set; }
        public Guid? MediaAssetId { get; set; }
        public string FileName { get; set; }
        public string OriginFileName { get; set; }
        public string MimeType { get; set; }
        public long? PackageSize { get; set; }
        public DateTimeOffset? UploadedDate { get; set; }
        public Byte[] Revision { get; set; }
        public Guid? ReferenceAssetId { get; set; }
        public int? ReferenceIndex { get; set; }
        public int Status { get; set; }

        public virtual Asset ReferenceAsset { get; set; }
        public virtual AssetType AssetType { get; set; }
        public virtual MediaAsset MediaAsset { get; set; }
        public virtual MimeType MimeTypeObj { get; set; }
        public virtual ICollection<Scene> Scenes { get; set; } 
        public virtual ICollection<AssetLocator> AssetLocators { get; set; }
        public virtual ICollection<Evidence> Evidences { get; set; }
    }
}
