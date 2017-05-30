using System;
using System.Collections.Generic;

namespace OnAir.Data
{
    public partial class TblAfdtypes
    {
        public TblAfdtypes()
        {
            HdsyncV4TblAfdtypes = new HashSet<HdsyncV4TblAfdtypes>();
        }

        public int AfdId { get; set; }
        public string Description { get; set; }
        public string VideoFormat { get; set; }
        public int? Changed { get; set; }
        public Guid SyncId { get; set; }
        public int? ChangedPcd { get; set; }

        public virtual ICollection<HdsyncV4TblAfdtypes> HdsyncV4TblAfdtypes { get; set; }
    }
}
