using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class AnnexContract
    {
        public AnnexContract()
        {
            AnnexContractAssets = new HashSet<AnnexContractAsset>();
        }

        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Code { get; set; }
        public Guid? ContractId { get; set; }
        public int BookingTypeId { get; set; }
        public DateTime ReceiveDate { get; set; }
		public Guid? AnnexContractTypeId { get; set; }

		public virtual ICollection<AnnexContractAsset> AnnexContractAssets { get; set; }
        public virtual AnnexContractPartner AnnexContractPartners { get; set; }
		public virtual RetailContract RetailContract { get; set; }
		public virtual BookingType BookingType { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual Customer Customer { get; set; }
		public virtual AnnexContractType AnnexContractType { get; set; }
		public bool IsPartnerContract { get {
				return AnnexContractPartners != null;
			} }

	}
}
