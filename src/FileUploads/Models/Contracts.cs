using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Contracts
    {
        public Contracts()
        {
            AnnexContracts = new HashSet<AnnexContracts>();
        }

        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Code { get; set; }
        public string Content { get; set; }
        public DateTime? SignDate { get; set; }

        public virtual ICollection<AnnexContracts> AnnexContracts { get; set; }
        public virtual CustomerPartners Customer { get; set; }
    }
}
