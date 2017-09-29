using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class MediaAsset
    {
        public MediaAsset()
        {
            Asset = new HashSet<Asset>();
        }

        public Guid Id { get; set; }
        public long? Duration { get; set; }
        public long? Timecode { get; set; }
        public int? FramerateNumerator { get; set; }
        public int? FramerateDemoniator { get; set; }
        public string ContainerFormat { get; set; }
        public long? MarkIn { get; set; }
        public long? MarkOut { get; set; }
        public string Content { get; set; }

        public virtual ICollection<Asset> Asset { get; set; }
    }
}
