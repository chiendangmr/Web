using HD.TVAD.Entities.Entities.Booking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Price
{
    [Table("AnnexContractPrices", Schema = "Price")]
    public class AnnexContractPrice
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid AnnexContractId { get; set; }

        [ForeignKey(nameof(AnnexContractId))]
        public AnnexContractPartner AnnexContract { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [ForeignKey(nameof(AnnexContractPrice_TimeBand.PriceId))]
        public ICollection<AnnexContractPrice_TimeBand> Prices { get; } = new HashSet<AnnexContractPrice_TimeBand>();
    }
}
