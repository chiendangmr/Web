using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            AnnexContracts = new HashSet<AnnexContract>();
            DiscountCustomers = new HashSet<DiscountCustomer>();
        }

        public Guid Id { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<AnnexContract> AnnexContracts { get; set; }
        public virtual CustomerPartner CustomerPartners { get; set; }
		public virtual RetailCustomer RetailCustomer { get; set; }
		public virtual ICollection<DiscountCustomer> DiscountCustomers { get; set; }
        public virtual CustomerType Type { get; set; }

		public bool IsRetailCustomer
		{
			get
			{
				return this.CustomerPartners == null;
			}
		}
		public bool IsPartnerCustomer
		{
			get
			{
				return this.CustomerPartners != null;
			}
		}
	}
}
