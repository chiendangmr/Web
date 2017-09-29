using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class RateSpotBlocks
    {
        public Guid Id { get; set; }
        public Guid SpotBlockId { get; set; }
        public decimal? Rate { get; set; }

        public virtual TypeDetails IdNavigation { get; set; }
        public virtual SpotBlocks SpotBlock { get; set; }
    }
}
