using HD.TVAD.Entities.Entities.Price;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.System
{
    /// <summary>
    /// Block for calculator money
    /// </summary>
    [Table("SpotBlocks", Schema = "System")]
    public class SpotBlock
    {
        /// <summary>
        /// Id of block
        /// </summary>
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Duration of block
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Prices
        /// </summary>
        [ForeignKey(nameof(TimeBandPrice.SpotBlockId))]
        public ICollection<TimeBandPrice> Prices { get; } = new HashSet<TimeBandPrice>();

        [ForeignKey(nameof(RateSpotBlock.SpotBlockId))]
        public ICollection<RateSpotBlock> RateSpotBlocks { get; } = new HashSet<RateSpotBlock>();

        [ForeignKey(nameof(AnnexContractPrice_SpotBlock.SpotBlockId))]
        public ICollection<AnnexContractPrice_SpotBlock> AnnexContractPrices { get; set; }
    }
}
