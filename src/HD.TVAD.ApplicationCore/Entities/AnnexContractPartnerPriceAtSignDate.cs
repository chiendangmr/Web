using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class AnnexContractPartnerPriceAtSignDate
    {
        public Guid Id { get; set; }
        public Guid AnnexContractId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual AnnexContractPartner AnnexContract { get; set; }
    }
}
