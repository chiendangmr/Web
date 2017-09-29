using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class SponsorTypes
    {
        public SponsorTypes()
        {
            AnnexContractPartners = new HashSet<AnnexContractPartners>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AnnexContractPartners> AnnexContractPartners { get; set; }
    }
}
