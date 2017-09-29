using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class TemplateItemAssetTypeRequests
    {
        public Guid Id { get; set; }
        public Guid TemplateItemId { get; set; }
        public Guid AssetTypeId { get; set; }
        public int? MinCount { get; set; }
        public int? MaxCount { get; set; }

        public virtual AssetTypes AssetType { get; set; }
        public virtual TemplateItems TemplateItem { get; set; }
    }
}
