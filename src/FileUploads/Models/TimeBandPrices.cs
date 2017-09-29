using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class TimeBandPrices
    {
        public Guid Id { get; set; }
        public Guid TimeBandId { get; set; }
        public Guid? SpotBlockId { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Price { get; set; }

        public virtual SpotBlocks SpotBlock { get; set; }
        public virtual TimeBands TimeBand { get; set; }
    }
}
