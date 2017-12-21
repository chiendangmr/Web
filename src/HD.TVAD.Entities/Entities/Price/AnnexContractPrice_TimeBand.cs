using HD.TVAD.Entities.Entities.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Price
{
    [Table("AnnexContractPrice_TimeBands", Schema = "Price")]
    public class AnnexContractPrice_TimeBand
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid PriceId { get; set; }

        [ForeignKey(nameof(PriceId))]
        public AnnexContractPrice AnnexContractPrice { get; set; }

        public Guid? TimeBandId { get; set; }

        [ForeignKey(nameof(TimeBandId))]
        public TimeBand TimeBand { get; set; }

        public decimal? PositionRateUnit { get; set; }

        [ForeignKey(nameof(AnnexContractPrice_SpotBlock.PriceTimeBandId))]
        public ICollection<AnnexContractPrice_SpotBlock> Prices { get; } = new HashSet<AnnexContractPrice_SpotBlock>();
    }
}
