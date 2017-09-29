using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class AnnexContracts
    {
        public AnnexContracts()
        {
            AnnexContractAssets = new HashSet<AnnexContractAssets>();
        }

        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Code { get; set; }
        public Guid? ContractId { get; set; }
        public int BookingTypeId { get; set; }
        public DateTime ReceiveDate { get; set; }
        public Guid? AnnexContractTypeId { get; set; }

        public virtual ICollection<AnnexContractAssets> AnnexContractAssets { get; set; }
        public virtual AnnexContractPartners AnnexContractPartners { get; set; }
        public virtual AnnexContractTypes AnnexContractType { get; set; }
        public virtual BookingTypes BookingType { get; set; }
        public virtual Contracts Contract { get; set; }
        public virtual Customers Customer { get; set; }
    }
}
