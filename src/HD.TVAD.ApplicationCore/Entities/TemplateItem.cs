using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class TemplateItem
    {
        public TemplateItem()
        {
            TemplateItemAssetTypeRequests = new HashSet<TemplateItemAssetTypeRequest>();
        }

        public Guid Id { get; set; }
        public Guid TemplateId { get; set; }
        public string Name { get; set; }
        public int Index { get; set; }

        public virtual ICollection<TemplateItemAssetTypeRequest> TemplateItemAssetTypeRequests { get; set; }
        public virtual Template Template { get; set; }
    }
}
