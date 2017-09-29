using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class TemplateItems
    {
        public TemplateItems()
        {
            TemplateItemAssetTypeRequests = new HashSet<TemplateItemAssetTypeRequests>();
        }

        public Guid Id { get; set; }
        public Guid TemplateId { get; set; }
        public string Name { get; set; }
        public int Index { get; set; }

        public virtual ICollection<TemplateItemAssetTypeRequests> TemplateItemAssetTypeRequests { get; set; }
        public virtual Templates Template { get; set; }
    }
}
