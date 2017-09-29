using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class AnnexContractPartnerPriceAtSignDates
    {
        public Guid Id { get; set; }
        public Guid AnnexContractId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual AnnexContractPartners AnnexContract { get; set; }
    }
}
