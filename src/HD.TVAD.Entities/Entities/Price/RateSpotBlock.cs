using HD.TVAD.Entities.Entities.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Price
{
    [Table("RateSpotBlocks", Schema = "Price")]
    public class RateSpotBlock
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [ForeignKey(nameof(Id))]
        public PriceTypeDetail BaseType { get; set; }

        public Guid SpotBlockId { get; set; }

        [ForeignKey(nameof(SpotBlockId))]
        public SpotBlock SpotBlock { get; set; }

        public decimal? Rate { get; set; }

        public RateSpotBlock()
        {
            BaseType = new PriceTypeDetail
            {
                Id = this.Id,
                RateSpotBlock = this
            };
        }
    }
}
