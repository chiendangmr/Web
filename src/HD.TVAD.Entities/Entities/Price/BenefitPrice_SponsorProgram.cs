using HD.TVAD.Entities.Entities.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Price
{
    [Table("BenefitPrice_SponsorPrograms", Schema = "Price")]
    public class BenefitPrice_SponsorProgram
    {
        public Guid SponsorProgramId { get; set; }

        [ForeignKey(nameof(SponsorProgramId))]
        public SponsorProgram SponsorProgram { get; set; }

        public Guid BenefitPriceId { get; set; }

        [ForeignKey(nameof(BenefitPriceId))]
        public BenefitPrice BenefitPrice { get; set; }
    }
}
