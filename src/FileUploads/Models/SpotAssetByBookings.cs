using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class SpotAssetByBookings
    {
        public Guid Id { get; set; }

        public virtual SpotAssets IdNavigation { get; set; }
        public virtual SpotBookings Id1 { get; set; }
    }
}
