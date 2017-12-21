using HD.TVAD.Entities.Entities.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Price
{
    [Table("AnnexContractPrice_SpotBlocks", Schema = "Price")]
    public class AnnexContractPrice_SpotBlock
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid PriceTimeBandId { get; set; }

        [ForeignKey(nameof(PriceTimeBandId))]
        public AnnexContractPrice_TimeBand PriceTimeBand { get; set; }

        public Guid SpotBlockId { get; set; }

        [ForeignKey(nameof(SpotBlockId))]
        public SpotBlock SpotBlock { get; set; }

        public decimal? Price { get; set; }
    }
}
