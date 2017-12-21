using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class SpotAssetByBooking
    {
        public Guid Id { get; set; }

        public virtual SpotAsset SpotAsset { get; set; }
        public virtual SpotBooking SpotBooking { get; set; }
    }
}
