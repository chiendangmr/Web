using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class TemplateItemAssetTypeRequest
	{
		public Guid Id { get; set; }
		public Guid TemplateItemId { get; set; }
        public Guid AssetTypeId { get; set; }
        public int? MinCount { get; set; }
        public int? MaxCount { get; set; }

        public virtual ContentType AssetType { get; set; }
        public virtual TemplateItem TemplateItem { get; set; }
    }
}
