using HD.TVAD.Entities.Entities.Booking;
using HD.TVAD.Entities.Entities.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HD.TVAD.Entities.Entities.Price
{
    [Table("DiscountSponsorPrograms", Schema = "Price")]
    public class DiscountSponsorProgram
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ProgramId { get; set; }

        [ForeignKey(nameof(ProgramId))]
        public SponsorProgram SponsorProgram { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal Rate { get; set; }

        public string Description { get; set; }
    }
}
