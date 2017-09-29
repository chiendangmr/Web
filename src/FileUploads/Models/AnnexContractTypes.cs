using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class AnnexContractTypes
    {
        public AnnexContractTypes()
        {
            AnnexContracts = new HashSet<AnnexContracts>();
        }

        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public int BookingTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AnnexContracts> AnnexContracts { get; set; }
        public virtual BookingTypes BookingType { get; set; }
        public virtual AnnexContractTypes Parent { get; set; }
        public virtual ICollection<AnnexContractTypes> InverseParent { get; set; }
    }
}
