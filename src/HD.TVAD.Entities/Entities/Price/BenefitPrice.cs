using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Price
{
    [Table("BenefitPrices", Schema = "Price")]
    public class BenefitPrice
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid BenefitTypeId { get; set; }

        [ForeignKey(nameof(BenefitTypeId))]
        public BenefitType BenefitType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal Price { get; set; }

        /// <summary>
        /// Programs apply
        /// </summary>
        [ForeignKey(nameof(BenefitPrice_SponsorProgram.BenefitPriceId))]
        public ICollection<BenefitPrice_SponsorProgram> SponsorPrograms { get; } = new HashSet<BenefitPrice_SponsorProgram>();

        [ForeignKey(nameof(BenefitPrice_TimeBand.BenefitPriceId))]
        public ICollection<BenefitPrice_TimeBand> TimeBands { get; } = new HashSet<BenefitPrice_TimeBand>();
    }
}
