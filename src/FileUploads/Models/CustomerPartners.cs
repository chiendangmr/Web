using System;
using System.Collections.Generic;

namespace FileUploads.Models
{
    public partial class CustomerPartners
    {
        public CustomerPartners()
        {
            Contracts = new HashSet<Contracts>();
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

        public virtual ICollection<Contracts> Contracts { get; set; }
        public virtual Customers IdNavigation { get; set; }
        public virtual CustomerPartners Parent { get; set; }
        public virtual ICollection<CustomerPartners> InverseParent { get; set; }
    }
}
