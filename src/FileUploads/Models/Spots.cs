using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Spots
    {
        public Spots()
        {
            SpotAssets = new HashSet<SpotAssets>();
            SpotBookings = new HashSet<SpotBookings>();
        }

        public Guid Id { get; set; }
        public DateTime BroadcastDate { get; set; }
        public Guid TimeBandSliceId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SpotAssets> SpotAssets { get; set; }
        public virtual ICollection<SpotBookings> SpotBookings { get; set; }
        public virtual TimeBandSlices TimeBandSlice { get; set; }
    }
}
