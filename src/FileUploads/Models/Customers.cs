using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class Customers
    {
        public Customers()
        {
            AnnexContracts = new HashSet<AnnexContracts>();
            DiscountCustomers = new HashSet<DiscountCustomers>();
        }

        public Guid Id { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<AnnexContracts> AnnexContracts { get; set; }
        public virtual CustomerPartners CustomerPartners { get; set; }
        public virtual CustomerRetails CustomerRetails { get; set; }
        public virtual ICollection<DiscountCustomers> DiscountCustomers { get; set; }
        public virtual CustomerTypes Type { get; set; }
    }
}
