using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class Origin
    {
        public Origin()
        {
            Scenes = new HashSet<Scene>();
        }

        public Guid Id { get; set; }
        public Guid FileId { get; set; }
        public long? TimeCodeOfFirstFrame { get; set; }
        public long? Duration { get; set; }
        public int? FrameRateNumerator { get; set; }
        public int? FrameRateDenominator { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual ICollection<Scene> Scenes { get; set; }
        public virtual File File { get; set; }
    }
}
