using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities.MediaAsset
{
    public partial class MediaAsset
    {
        public MediaAsset()
        {
            Assets = new HashSet<Asset>();
        }
        public Guid Id { get; set; }        
        public long? Duration { get; set; }
        public long? Timecode { get; set; }
        public int? Framerate_Numerator { get; set; }
        public int? Framerate_Demoniator { get; set; }
        public string ContainerFormat { get; set; }
        public long? MarkIn { get; set; }
        public long? MarkOut { get; set; }
        public string Content { get; set; }

        public virtual ICollection<Asset> Assets { get; set; }
    }
}
