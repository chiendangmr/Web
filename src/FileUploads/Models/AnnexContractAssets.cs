using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class AnnexContractAssets
    {
        public AnnexContractAssets()
        {
            SpotBookings = new HashSet<SpotBookings>();
        }

        public Guid Id { get; set; }
        public Guid AnnexContractId { get; set; }
        public Guid AssetId { get; set; }
        public Guid PriceTypeDetailId { get; set; }
        public string Content { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<SpotBookings> SpotBookings { get; set; }
        public virtual AnnexContracts AnnexContract { get; set; }
        public virtual Content Asset { get; set; }
        public virtual TypeDetails PriceTypeDetail { get; set; }
    }
}
