using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class AssetTypes
    {
        public AssetTypes()
        {
            Content = new HashSet<Content>();
            TemplateItemAssetTypeRequests = new HashSet<TemplateItemAssetTypeRequests>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsBroadcast { get; set; }
        public bool IsIndexing { get; set; }
        public int Index { get; set; }
        public int? FileTypeId { get; set; }

        public virtual ICollection<Content> Content { get; set; }
        public virtual ICollection<TemplateItemAssetTypeRequests> TemplateItemAssetTypeRequests { get; set; }
        public virtual FileTypes FileType { get; set; }
    }
}
