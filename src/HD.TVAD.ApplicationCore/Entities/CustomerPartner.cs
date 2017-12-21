using System;
using System.Collections.Generic;

namespace HD.TVAD.ApplicationCore.Entities
{
    public partial class CustomerPartner
    {
        public CustomerPartner()
        {
            Contracts = new HashSet<Contract>();
        }

        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string Code { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string RepresentivePerson { get; set; }
        public string PositionOfRepresentivePerson { get; set; }
        public string AccountNumber { get; set; }
        public string TaxNumber { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual CustomerPartner Parent { get; set; }
        public virtual ICollection<CustomerPartner> InverseParent { get; set; }
    }
}
