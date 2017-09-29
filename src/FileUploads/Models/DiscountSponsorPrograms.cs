using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class DiscountSponsorPrograms
    {
        public Guid Id { get; set; }
        public Guid ProgramId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Rate { get; set; }
        public string Description { get; set; }

        public virtual SponsorPrograms Program { get; set; }
    }
}
