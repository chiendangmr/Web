using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class Contract
    {
        public Contract()
        {
            AnnexContracts = new HashSet<AnnexContract>();
        }

        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Code { get; set; }
        public string Content { get; set; }
        public DateTime? SignDate { get; set; }

        public virtual ICollection<AnnexContract> AnnexContracts { get; set; }
        public virtual CustomerPartner Customer { get; set; }
    }
}
