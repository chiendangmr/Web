using HD.TVAD.Entities.Entities.Booking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Price
{
    [Table("DiscountAnnexContracts", Schema = "Price")]
    public class DiscountAnnexContract
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid AnnexContractId { get; set; }

        [ForeignKey(nameof(AnnexContractId))]
        public AnnexContract AnnexContract { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal Rate { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(DiscountAnnexContract_TimeBandBase.DiscountId))]
        public ICollection<DiscountAnnexContract_TimeBandBase> TimeBandBases { get; } = new HashSet<DiscountAnnexContract_TimeBandBase>();
    }
}
