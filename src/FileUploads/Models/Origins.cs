using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Origins
    {
        public Origins()
        {
            Scenes = new HashSet<Scenes>();
        }

        public Guid Id { get; set; }
        public Guid FileId { get; set; }
        public long? TimeCodeOfFirstFrame { get; set; }
        public long? Duration { get; set; }
        public int? FrameRateNumerator { get; set; }
        public int? FrameRateDenominator { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual ICollection<Scenes> Scenes { get; set; }
        public virtual Files File { get; set; }
    }
}
