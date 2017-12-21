using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class SponsorType
    {
        public SponsorType()
        {
            AnnexContractPartners = new HashSet<AnnexContractPartner>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AnnexContractPartner> AnnexContractPartners { get; set; }
    }
}
