using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class ContentType
    {
        public ContentType()
        {
            Assets = new HashSet<Content>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsBroadcast { get; set; }
        public bool IsIndexing { get; set; }
        public int Index { get; set; }

        public int? FileTypeId { get; set; }

        [ForeignKey(nameof(FileTypeId))]
        public FileType FileType { get; set; }

        public virtual ICollection<Content> Assets { get; set; }

		public virtual ICollection<TemplateItemAssetTypeRequest> TemplateItemAssetTypeRequests { get; set; }
		
	}
}
