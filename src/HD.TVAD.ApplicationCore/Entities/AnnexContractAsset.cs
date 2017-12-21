using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class AnnexContractAsset
    {
        public AnnexContractAsset()
        {
            SpotBookings = new HashSet<SpotBooking>();
        }

        public Guid Id { get; set; }
        public Guid AnnexContractId { get; set; }
        public Guid ContentId { get; set; }
        public Guid PriceTypeDetailId { get; set; }
        public string Contents { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<SpotBooking> SpotBookings { get; set; }
        public virtual AnnexContract AnnexContract { get; set; }
        public virtual Content Content { get; set; }
        public virtual TypeDetail PriceTypeDetail { get; set; }
    }
}
