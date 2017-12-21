using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class DiscountSponsorProgram
    {
        public Guid Id { get; set; }
        public Guid ProgramId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Rate { get; set; }
        public string Description { get; set; }

        public virtual SponsorProgram Program { get; set; }
    }
}
