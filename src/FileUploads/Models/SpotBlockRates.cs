using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class SpotBlockRates
    {
        public Guid Id { get; set; }
        public Guid SpotBlockId { get; set; }
        public decimal Rate { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }

        public virtual SpotBlocks SpotBlock { get; set; }
    }
}
