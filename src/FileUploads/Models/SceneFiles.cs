using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class SceneFiles
    {
        public Guid Id { get; set; }
        public Guid SceneId { get; set; }
        public Guid FileId { get; set; }
        public long? Duration { get; set; }
        public int? FrameRateNumerator { get; set; }
        public int? FrameRateDenominator { get; set; }

        public virtual Files File { get; set; }
        public virtual Scenes Scene { get; set; }
    }
}
